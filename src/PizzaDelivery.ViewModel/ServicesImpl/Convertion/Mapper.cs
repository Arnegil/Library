using PizzaDelivery.ViewModel.Interfaces.Converiton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PizzaDelivery.ViewModel.ServicesImpl.Converiton
{
    public class Mapper : IMapper
    {
        private readonly List<object> _factories;

        public Mapper()
        {
            _factories = new List<object>();
        }

        public Func<T1, T2> GetMap<T1, T2>() where T1 : class where T2 : class
        {
            var factory = _factories.SingleOrDefault(x => x is Func<T1, T2>);

            if (factory == null)
                throw new Exception($"There is not map from {nameof(T1)} to {nameof(T2)}");

            return factory as Func<T1, T2>;
        }

        public void SetMap<T1, T2>(Func<T1, T2> map) where T1 : class where T2 : class
        {
            int countMaps = _factories.Count(x => x is Func<T1, T2>);
            if (countMaps > 0)
                throw new Exception($"Map {map} already exists");

            _factories.Add(map);
        }

        public void SetAutoMap<T1, T2>() where T1 : class where T2 : class
        {
            Func<T1, T2> func = (obj1) =>
            {
                var obj2 = Activator.CreateInstance<T2>();

                var T1Properties = typeof(T1).GetProperties().Where(x => x.CanRead);
                var T2Properties = typeof(T2).GetProperties().Where(x => x.CanWrite);

                foreach (var prop2 in T2Properties)
                {
                    var prop1 = T1Properties.SingleOrDefault(x => x.Name == prop2.Name && x.PropertyType == prop2.PropertyType);

                    if (prop1 != null)
                    {
                        prop2.SetValue(obj2, prop1.GetValue(obj1), null);
                    }
                }

                return obj2;
            };

            _factories.Add(func);
        }
    }
}