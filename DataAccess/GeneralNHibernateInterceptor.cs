using NHibernate;
using NHibernate.SqlCommand;

namespace DataAccess
{
    public class GeneralNHibernateInterceptor : EmptyInterceptor
    {
        public const string QueryHintRecompileCommentString = "queryhint-recompile";
        private const string _queryHintOptionRecompileString = " OPTION(RECOMPILE);";

        public override SqlString OnPrepareStatement(SqlString sql)
        {
            // If a recompile comment string was found - add an RECOMPILE option at the end of the statement
            if (sql.ToString().Contains(QueryHintRecompileCommentString))
            {
                return sql.Replace(";\r\n", _queryHintOptionRecompileString);
            }

            return sql;
        }
    }
}