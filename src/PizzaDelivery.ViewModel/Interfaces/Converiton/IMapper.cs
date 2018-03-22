using System;

namespace PizzaDelivery.ViewModel.Interfaces.Converiton
{
    public interface IMapper
    {
        Func<T1, T2> GetMap<T1, T2>() where T1 : class where T2 : class;
        void SetMap<T1, T2>(Func<T1, T2> map) where T1 : class where T2 : class;
    }
}