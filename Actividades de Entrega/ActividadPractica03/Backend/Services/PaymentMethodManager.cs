using ActividadPractica01.Data.Interfaces;
using ActividadPractica01.Data.Repository;
using ActividadPractica01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Services
{
    public class PaymentMethodManager
    {
        private IPaymentMethodRepository _repository;

        public PaymentMethodManager()
        {
            _repository = new PaymentMethodRepository();
        }

        public List<PaymentMethod> GetPaymentMethods()
        {
            return _repository.GetAll();
        }

        public PaymentMethod GetPaymentMethodById(int id)
        {
            return _repository.GetById(id);
        }

        public bool SavePaymentMethod(PaymentMethod oPaymentMethod)
        {
            return _repository.Save(oPaymentMethod);
        }

        public bool DeletePaymentMethod(int id)
        {
            return _repository.Delete(id);
        }
    }
}
