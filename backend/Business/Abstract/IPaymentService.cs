using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPaymentService:IServiceRepository<PaymentCard>
    {
        IResult IsPaymentSuccess(PaymentCard paymentCard);
        IDataResult<PaymentCard> GetByCustomerId(int id);
    }
}
