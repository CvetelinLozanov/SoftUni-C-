﻿using SoftuniDI.Attributes;
using SoftuniDI.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftuniDI.Modules
{
    public abstract class AbstractModule : IModule
    {
        private readonly IDictionary<Type, Dictionary<string, Type>> implementations;
        private readonly IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        public object GetInstance(Type type)
        {
            this.instances.TryGetValue(type, out object value);
            return value;
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementation = this.implementations[currentInterface];

            Type type = null;

            if (attribute is InjectAttribute)
            {
                if (currentImplementation.Count == 0)
                {
                    throw new ArgumentException($"No available mappling for class: {currentInterface.FullName}");

                }
                type = implementations[currentInterface].Values.FirstOrDefault();


            }
            else if (attribute is NamedAttribute named)
            {
                string dependencyName = named.Name;
                type = currentImplementation[dependencyName];
            }

            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance);
            }
        }

        protected void CreateMapping<TInterface, TImplementation>()
        {
            if (!this.implementations.ContainsKey(typeof(TInterface)))
            {
                this.implementations[typeof(TInterface)] = new Dictionary<string, Type>();
            }

            this.implementations[typeof(TInterface)].Add(typeof(TImplementation).Name, typeof(TImplementation));
        }
    }
}
