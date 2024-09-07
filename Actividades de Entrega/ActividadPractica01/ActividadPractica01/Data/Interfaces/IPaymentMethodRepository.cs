using ActividadPractica01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Data.Interfaces
{
    public interface IPaymentMethodRepository
    {
        List<PaymentMethod> GetAll();
        PaymentMethod GetById(int id);
        bool Save(PaymentMethod oPaymentMethod);
        bool Delete(int id);
    }
}
