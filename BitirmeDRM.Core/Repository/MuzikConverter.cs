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
    public class MuzikConverter : IConverter<Muzik>
    {
        public Muzik DataToEntity(DataRow dr)
        {
            Muzik m = new Muzik();
            if(dr != null)
            {
                m.KategoriId = Convert.ToInt32(dr["KategoriId"]);
                m.MuzikAdi = Convert.ToString(dr["MuzikAdi"]);
                m.MuzikBoyut = Convert.ToInt32(dr["MuzikBoyut"]);
                m.MuzikGorsel = Convert.ToString(dr["MuzikGorsel"]);
                m.MuzikId = Convert.ToInt32(dr["MuzikId"]);
                m.MuzikIndirme = Convert.ToInt32(dr["MuzikIndirme"]);
                m.MuzikSanatci = Convert.ToString(dr["MuzikSanatci"]);
                m.MuzikUzunluk = Convert.ToString(dr["MuzikUzunluk"]);
                m.MuzikYayin = Convert.ToBoolean(dr["MuzikYayin"]);
                m.MuzikDosya = Convert.ToString(dr["MuzikDosya"]);
            }
            return m;
        }

        public IEnumerable<Muzik> DataToListEntity(DataTable dt)
        {
            List<Muzik> mList = new List<Muzik>();
            foreach (DataRow dr in dt.Rows)
            {
                Muzik m = new Muzik();
                m.KategoriId = Convert.ToInt32(dr["KategoriId"]);
                m.MuzikAdi = Convert.ToString(dr["MuzikAdi"]);
                m.MuzikBoyut = Convert.ToInt32(dr["MuzikBoyut"]);
                m.MuzikGorsel = Convert.ToString(dr["MuzikGorsel"]);
                m.MuzikId = Convert.ToInt32(dr["MuzikId"]);
                m.MuzikIndirme = Convert.ToInt32(dr["MuzikIndirme"]);
                m.MuzikSanatci = Convert.ToString(dr["MuzikSanatci"]);
                m.MuzikUzunluk = Convert.ToString(dr["MuzikUzunluk"]);
                m.MuzikYayin = Convert.ToBoolean(dr["MuzikYayin"]);
                m.MuzikDosya = Convert.ToString(dr["MuzikDosya"]);

                mList.Add(m);
            }
            return mList;
        }
        public SqlParameter[] EntityToData(Muzik t)
        {
            SqlParameter[] sqlParam = {new SqlParameter("@KategoriId",t.KategoriId),
                                          new SqlParameter("@MuzikAdi",t.MuzikAdi),
                                          new SqlParameter("@MuzikBoyut",t.MuzikBoyut),
                                          new SqlParameter("@MuzikGorsel", t.MuzikGorsel),
                                          new SqlParameter("@MuzikId",t.MuzikId),
                                          new SqlParameter("@MuzikIndirme", t.MuzikIndirme),
                                          new SqlParameter("@MuzikSanatci", t.MuzikSanatci),
                                          new SqlParameter("@MuzikUzunluk", t.MuzikUzunluk),
                                          new SqlParameter("@MuzikYayin", t.MuzikYayin),
                                          new SqlParameter("@MuzikDosya", t.MuzikDosya)

            };
            return sqlParam;
        }
    }
}
