using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BitirmeDRM.Core.Repository
{
    public interface IConverter<T> where T : class
    {
        T DataToEntity(DataRow dr);
        IEnumerable<T> DataToListEntity(DataTable dt);
        SqlParameter[] EntityToData(T t);
    }
}
