using Domain.Transaction;
using FluentNHibernate.Mapping;

namespace DataAccess.Transaction
{
    public class CaptureMap : ClassMap<Capture>
    {
        public CaptureMap()
        {
            Schema("cp");
            Table("Capture");

            Id(x => x.Id);
            Map(x => x.TransactionId);
            Map(x => x.Currency);
            Map(x => x.Amount);

            Map(x => x.CreateUser);
            Map(x => x.CreateDate).CustomType("datetime2");
            Map(x => x.ModifiedUser);
            Map(x => x.ModifiedDate).CustomType("datetime2");
        }
    }
}