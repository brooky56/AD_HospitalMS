using HospitalMS_UWP.Models.Database;
using HospitalMS_UWP.Models.Models;
using System.Collections.Generic;

namespace HospitalMS_UWP.Controllers
{
    public class PaymentsController : DatabaseController
    {
        public IEnumerable<Payment> GetPayments()
        {
            return databaseManager.Database.Query<Payment>().ToList();
        }

        public MessageResponse AddPayment(Payment payment)
        {
            if (Models.Database.Payment.IsInDB(databaseManager, payment.Key))
            {
                return new MessageResponse("Payment already exists");
            }
            payment.InsertIntoDB(databaseManager);
            return new MessageResponse("Payment added");
        }
    }
}
