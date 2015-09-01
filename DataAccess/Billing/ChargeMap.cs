using Domain.Billing;
using FluentNHibernate.Mapping;

namespace DataAccess.Billing
{
    public class ChargeMap : ClassMap<Charge>
    {
        public ChargeMap()
        {
            Schema("cp");
            Table("Charge");

            Id(x => x.Id);
            Map(x => x.TransactionId);
            Map(x => x.ChargeCurrency);
            Map(x => x.ChargeAmount);

            Map(x => x.CreateUser);
            Map(x => x.CreateDate).CustomType("datetime2");
            Map(x => x.ModifiedUser);
            Map(x => x.ModifiedDate).CustomType("datetime2");
        }
    }
}