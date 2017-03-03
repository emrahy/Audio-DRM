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
    class KulIslemConverter : IConverter<KulIslem>
    {
        public KulIslem DataToEntity(DataRow dr)
        {
            KulIslem k = new KulIslem();
            try
            {
                k.kiId = Convert.ToInt32(dr["kiId"]);
                k.kiKulId = Convert.ToInt32(dr["kiKulId"]);
                k.kiMuzikId = Convert.ToInt32(dr["kiMuzikId"]);
                k.kiOdeme = Convert.ToBoolean(dr["kiOdeme"]);
                k.kiTarih = Convert.ToString(dr["kiTarih"]);
            }
            catch (Exception)
            {
            }
            return k;
        }

        public IEnumerable<KulIslem> DataToListEntity(DataTable dt)
        {
            List<KulIslem> kList = new List<KulIslem>();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    KulIslem k = new KulIslem();
                    k.kiId = Convert.ToInt32(dr["kiId"]);
                    k.kiKulId = Convert.ToInt32(dr["kiKulId"]);
                    k.kiMuzikId = Convert.ToInt32(dr["kiMuzikId"]);
                    k.kiOdeme = Convert.ToBoolean(dr["kiOdeme"]);
                    k.kiTarih = Convert.ToString(dr["kiTarih"]);
                    kList.Add(k);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return kList;
        }

        public SqlParameter[] EntityToData(KulIslem t)
        {
            SqlParameter[] sqlParam = {new SqlParameter("@kiTarih",t.kiTarih),
                                          new SqlParameter("@kiOdeme",t.kiOdeme),
                                          new SqlParameter("@kiMuzikId",t.kiMuzikId),
                                          new SqlParameter("@kiKulId", t.kiKulId),
                                          new SqlParameter("@kiId",t.kiId)
            };
            return sqlParam;
        }
    }
}
