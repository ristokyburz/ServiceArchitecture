using Domain.Log;
using FluentNHibernate.Mapping;

namespace DataAccess.Log
{
    public class PaymentTransactionLogMap : ClassMap<PaymentTransactionLog>
    {
        public PaymentTransactionLogMap()
        {
            Schema("cp");
            Table("PaymentTransactionLog");

            Id(x => x.Id);
            Map(x => x.TransactionId);
            Map(x => x.Message);

            Map(x => x.CreateUser);
            Map(x => x.CreateDate).CustomType("datetime2");
            Map(x => x.ModifiedUser);
            Map(x => x.ModifiedDate).CustomType("datetime2");
        }   
    }
}