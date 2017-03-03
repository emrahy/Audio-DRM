using BitirmeDRM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BitirmeDRM.Core.Repository
{
    public class KategoriConverter : IConverter<Kategori>
    {
        public Kategori DataToEntity(DataRow dr)
        {
            Kategori k = new Kategori();
            if(dr != null)
            {
                k.KategoriAdi = Convert.ToString(dr["KategoriAdi"]);
                k.KategoriId = Convert.ToInt32(dr["KategoriId"]);
            }
            return k;
        }

        public IEnumerable<Kategori> DataToListEntity(DataTable dt)
        {
            List<Kategori> kList = new List<Kategori>();
            foreach (DataRow dr in dt.Rows)
            {
                Kategori k = new Kategori();
                k.KategoriAdi = Convert.ToString(dr["KategoriAdi"]);
                k.KategoriId = Convert.ToInt32(dr["KategoriId"]);
                kList.Add(k);
            }
            return kList;
        }

        public SqlParameter[] EntityToData(Kategori t)
        {
            SqlParameter[] sqlParam = {new SqlParameter("@KategoriId",t.KategoriId),
                                          new SqlParameter("@KategoriAdi",t.KategoriAdi)
            };
            return sqlParam;
        }
    }
}
