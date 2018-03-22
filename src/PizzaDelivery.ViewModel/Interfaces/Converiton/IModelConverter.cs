namespace PizzaDelivery.ViewModel.Interfaces.Converiton
{
    public interface IModelConverter
    {
        T2 Convert<T1, T2>(T1 obj) where T1 : class where T2 : class;
    }
}