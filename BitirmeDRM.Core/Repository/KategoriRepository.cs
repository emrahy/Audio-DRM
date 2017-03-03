using BitirmeDRM.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitirmeDRM.Data.Model;

namespace BitirmeDRM.Core.Repository
{
    public class KategoriRepository : IKategoriRepository
    {
        SqlFunction fn = new SqlFunction();
        KategoriConverter con = new KategoriConverter();
        public int Count()
        {
            int sonuc;
            try
            {
                string str = fn.GetCommand(2, "SELECT COUNT(*) FROM Kategori").ToString();
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
                fn.GetCommand(1, "DELETE FROM Kategori WHERE KategoriId = " + id);
            }
            catch (Exception)
            {
                sonuc = false;
            }
            return sonuc;
        }

        public IEnumerable<Kategori> GetAll()
        {
            return con.DataToListEntity(fn.GetDataTable("SELECT * FROM Kategori"));
        }

        public Kategori GetById(int id)
        {
            try
            {
                return con.DataToEntity(fn.GetDataRow("SELECT * FROM Kategori WHERE KategoriId =" + id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Insert(Kategori obj)
        {
            bool sonuc = true;
            try
            {
                fn.GetNonQuery("spKategoriEkle", con.EntityToData(obj));
            }
            catch (Exception)
            {
                sonuc = false;
            }
            return sonuc;
        }

        public bool Update(Kategori obj)
        {
            bool sonuc = true;
            try
            {
                fn.GetNonQuery("spKategoriGuncelle", con.EntityToData(obj));
            }
            catch (Exception)
            {
                sonuc = false;
            }
            return sonuc;
        }
    }
}
