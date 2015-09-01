using Domain.Transfer;
using FluentNHibernate.Mapping;

namespace DataAccess.Transfer
{
    public class ChargeTransferMap : ClassMap<ChargeTransfer>
    {
        public ChargeTransferMap()
        {
            Schema("cp");
            Table("ChargeTransfer");

            Id(x => x.Id);
            Map(x => x.TransactionId);
            Map(x => x.TransferDate).CustomType("datetime2");
            Map(x => x.TransferState);

            Map(x => x.CreateUser);
            Map(x => x.CreateDate).CustomType("datetime2");
            Map(x => x.ModifiedUser);
            Map(x => x.ModifiedDate).CustomType("datetime2");
        } 
    }
}