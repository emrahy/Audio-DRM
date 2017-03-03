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
    public class KullaniciConverter : IConverter<Kullanici>
    {

        public Kullanici DataToEntity(DataRow dr)
        {
            Kullanici k = new Kullanici();
            try
            {
                k.kulAdi = Convert.ToString(dr["kulAdi"]);
                k.kulDurum = Convert.ToBoolean(dr["kulDurum"]);
                k.kulEposta = Convert.ToString(dr["kulEposta"]);
                k.kulId = Convert.ToInt32(dr["kulId"]);
                k.kulSifre = Convert.ToString(dr["kulSifre"]);
                k.kulTamAdi = Convert.ToString(dr["kulTamAdi"]);
            }
            catch (Exception)
            {
            }
            return k;
        }

        public IEnumerable<Kullanici> DataToListEntity(DataTable dt)
        {
            List<Kullanici> kList = new List<Kullanici>();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Kullanici k = new Kullanici();
                    k.kulAdi = Convert.ToString(dr["kulAdi"]);
                    k.kulDurum = Convert.ToBoolean(dr["kulDurum"]);
                    k.kulEposta = Convert.ToString(dr["kulEposta"]);
                    k.kulId = Convert.ToInt32(dr["kulId"]);
                    k.kulSifre = Convert.ToString(dr["kulSifre"]);
                    k.kulTamAdi = Convert.ToString(dr["kulTamAdi"]);
                    kList.Add(k);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return kList;
        }

        public SqlParameter[] EntityToData(Kullanici t)
        {
            SqlParameter[] sqlParam = {new SqlParameter("@kulTamAdi",t.kulTamAdi),
                                          new SqlParameter("@kulSifre",t.kulSifre),
                                          new SqlParameter("@kulId",t.kulId),
                                          new SqlParameter("@kulEposta", t.kulEposta),
                                          new SqlParameter("@kulDurum",t.kulDurum),
                                          new SqlParameter("@kulAdi", t.kulAdi)
            };
            return sqlParam;
        }
    }
}
