using Domain.Transaction;
using FluentNHibernate.Mapping;

namespace DataAccess.Transaction
{
    public class AuthorizationMap : ClassMap<Authorization>
    {
        public AuthorizationMap()
        {
            Schema("cp");
            Table("[Authorization]");

            Id(x => x.Id);
            Map(x => x.TransactionId);
            Map(x => x.Account);
            Map(x => x.Currency);
            Map(x => x.Amount);

            Map(x => x.CreateUser);
            Map(x => x.CreateDate).CustomType("datetime2");
            Map(x => x.ModifiedUser);
            Map(x => x.ModifiedDate).CustomType("datetime2");
        }
    }
}