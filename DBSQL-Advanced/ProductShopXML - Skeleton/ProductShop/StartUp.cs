using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => 
            {
                x.AddProfile<ProductShopProfile>();
            });

            var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            using (ProductShopContext context = new ProductShopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Sucessfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId
                };
                products.Add(product);
            }
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";

        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                if (categoryDto.Name == null)
                {
                    continue;
                }

                var category = new Category
                {
                    Name = categoryDto.Name
                };

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoriesProductsDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoriesProducts = new List<CategoryProduct>();

            foreach (var categoryProducts in categoriesProductsDto)
            {
                var product = context.Products.Find(categoryProducts.ProductId);
                var category = context.Categories.Find(categoryProducts.CategoryId);

                if (product == null || category == null)
                {
                    continue;
                }

                var categoryProuct = new CategoryProduct
                {
                    ProductId = product.Id,
                    CategoryId = category.Id
                };

                categoriesProducts.Add(categoryProuct);
            }

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();
            return $"Successfully imported {categoriesProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price > 500 && p.Price <= 1000)
                .Select(x => new ExportProductInRangeDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(p => p.ProductsSold.Any())
                .Select(x => new ExportUserSoldProductDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ProductDto = x.ProductsSold.Select(p => new ProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(l => l.LastName)
                .ThenBy(f => f.FirstName)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserSoldProductDto[]), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(x => x.ProductsSold.Any())
                .Select(x => new ExportUserAndProductDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProductDto = new SoldProductDto
                    {
                        Count = x.ProductsSold.Count,
                        ProductDtos = x.ProductsSold.Select(p => new ProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(n => n.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProductDto.Count)
                .Take(10)
                .ToArray();

            var customExport = new ExportCustomUserProductDto
            {
                Count = context
                        .Users
                        .Count(x => x.ProductsSold.Any()),
                ExportUserAndProductDto = users
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomUserProductDto), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), customExport, namespaces);

            return sb.ToString().Trim();
        }
    }
}