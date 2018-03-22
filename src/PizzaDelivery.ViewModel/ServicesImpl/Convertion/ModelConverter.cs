using System;
using PizzaDelivery.ViewModel.Interfaces.Converiton;

namespace PizzaDelivery.ViewModel.ServicesImpl.Converiton
{
    public class ModelConverter : IModelConverter
    {
        private readonly IMapper _mapper;

        public ModelConverter(IMapper mapper)
        {
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            _mapper = mapper;
        }

        public T2 Convert<T1, T2>(T1 obj) where T1 : class where T2 : class
        {
            var factory = _mapper.GetMap<T1, T2>();
            return factory(obj);
        }
    }
}