using BitirmeDRM.Core.Infrastructure;
using BitirmeDRM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeDRM.Core.Repository
{
    public class MuzikRepository : IMuzikRepository
    {
        SqlFunction fn = new SqlFunction();
        MuzikConverter con = new MuzikConverter();
        public int Count()
        {
            int sonuc;
            try
            {
                string str = fn.GetCommand(2, "SELECT COUNT(*) FROM Muzik").ToString();
                sonuc = Convert.ToInt32(str);
            }
            catch (Exception)
            {
                sonuc = 0;
            }
            return sonuc;
        }

        public bool Delete(int id)
        {
            bool sonuc = true;
            try
            {
                fn.GetCommand(1, "DELETE FROM Muzik WHERE MuzikId = " + id);
            }
            catch (Exception)
            {
                sonuc = false;
            }
            return sonuc;
        }

        public IEnumerable<Muzik> GetAll()
        {
            return con.DataToListEntity(fn.GetDataTable("SELECT * FROM Muzik")); 
        }

        public Muzik GetById(int id)
        {
            try
            {
                return con.DataToEntity(fn.GetDataRow("SELECT * FROM Muzik WHERE MuzikId =" + id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Insert(Muzik obj)
        {
            bool sonuc = true;
            try
            {
                fn.GetNonQuery("spMuzikEkle", con.EntityToData(obj));
            }
            catch (Exception)
            {
                sonuc = false;
            }
            return sonuc;
        }

        public bool Update(Muzik obj)
        {
            bool sonuc = true;
            try
            {
                fn.GetNonQuery("spMuzikGuncelle", con.EntityToData(obj));
            }
            catch (Exception)
            {
                sonuc = false;
            }
            return sonuc;
        }
    }
}
