

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponRarity, string weaponType, string name)
        {
            WeaponRarity rarity = (WeaponRarity)Enum.Parse(typeof(WeaponRarity), weaponRarity);

            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == weaponType);

            IWeapon instance = (IWeapon)Activator.CreateInstance(type, new object[] { rarity, name});

            return instance;
        }
    }
