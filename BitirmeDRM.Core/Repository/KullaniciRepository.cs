using BitirmeDRM.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitirmeDRM.Data.Model;

namespace BitirmeDRM.Core.Repository
{
    class KullaniciRepository : IKullaniciRepository
    {
        SqlFunction fn = new SqlFunction();
        KulIslemConverter ccon = new KulIslemConverter();
        KullaniciConverter con = new KullaniciConverter();
        public IEnumerable<Kullanici> GetAll()
        {
            return con.DataToListEntity(fn.GetDataTable("SELECT * FROM Kullanici"));
        }

        public Kullanici GetById(int id)
        {
            try
            {
                return con.DataToEntity(fn.GetDataRow("SELECT * FROM Kullanici WHERE kulId =" + id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Insert(Kullanici obj)
        {
            bool sonuc = true;
            try
            {
                fn.GetNonQuery("spKullaniciEkle", con.EntityToData(obj));
            }
            catch (Exception)
            {
                sonuc = false;
            }
            return sonuc;
        }

        public bool Update(Kullanici obj)
        {
            bool sonuc = true;
            try
            {
                fn.GetNonQuery("spKullaniciGuncelle", con.EntityToData(obj));
            }
            catch (Exception)
            {
                sonuc = false;
            }
            return sonuc;
        }

        public bool Delete(int id)
        {
            bool sonuc = true;
            try
            {
                fn.GetCommand(1, "DELETE FROM Kullanici WHERE kulId = " + id);
            }
            catch (Exception)
            {
                sonuc = false;
            }
            return sonuc;
        }

        public int Count()
        {
            int sonuc;
            try
            {
                string str = fn.GetCommand(2, "SELECT COUNT(*) FROM Kullanici").ToString();
                sonuc = Convert.ToInt32(str);
            }
            catch (Exception)
            {
                sonuc = 0;
            }
            return sonuc;
        }

        public NIslemSonuc<Kullanici> Giris(string kulAdi, string sifre)
        {
            Kullanici k = new Kullanici();
            try
            {
                k = con.DataToEntity(fn.GetDataRow("SELECT * FROM Kullanici WHERE kulAdi = '"+kulAdi+"' OR kulEposta = '" +k.kulEposta +"' AND kulSifre = '"+sifre+"'" ));
                if (k != null)
                    return new NIslemSonuc<Kullanici>
                    {
                        BasariliMi = true,
                        Veri = k

                    };
                else
                    return new NIslemSonuc<Kullanici>
                    {
                        BasariliMi = false,
                        Mesaj = "Kullanıcı girişi başarısız! Bilgilerinizi kontrol edip tekrar deneyiniz."
                    };
            }
            catch (Exception hata)
            {
                return new NIslemSonuc<Kullanici>
                {
                    BasariliMi = false,
                    HataBilgi = new NHata
                    {
                        Sinif = "KullaniciRepository",
                        Metod = "Giris",
                        HataMesaj = hata.Message
                    },
                    Mesaj = "Bir hata ile karşılaşıldı."
                };
            }
        }

        public NIslemSonuc<bool> UyeOl(Kullanici k)
        {
            try
            {
                int uyeKontrol = Convert.ToInt32(fn.GetCommand(2, "SELECT COUNT(*) FROM Kullanici WHERE kulAdi = '" + k.kulAdi + "' OR kulEposta = '" +k.kulEposta +"'"));
                if (uyeKontrol == 0)
                {
                    //Kayıt işlemi yapılabilir
                    bool sonuc = Insert(k);
                    if (sonuc)
                        return new NIslemSonuc<bool>
                        {
                            BasariliMi = true,
                            Veri = true
                        };
                    else
                        return new NIslemSonuc<bool>
                        {
                            BasariliMi = false,
                            Mesaj = "Kullanıcı kaydı başarısız! Bilgilerinizi kontrol edip tekrar deneyiniz."
                        };
                }else
                    //kullanıcı adı veya eposta adresi daha önce kullanılmış
                    return new NIslemSonuc<bool>
                    {
                        BasariliMi = false,
                        Mesaj = "Eposta veya kullanıcı adı daha önce kullanılmıştır!"
                    };
            }
            catch (Exception hata)
            {
                return new NIslemSonuc<bool>
                {
                    BasariliMi = false,
                    HataBilgi = new NHata
                    {
                        Sinif = "KullaniciRepository",
                        Metod = "UyeOl",
                        HataMesaj = hata.Message
                    },
                    Mesaj = "Bir hata ile karşılaşıldı."
                };
            }
        }

        public NIslemSonuc<bool> SifremiUnuttum(string ePosta)
        {
            Kullanici k = new Kullanici();
            try
            {
                k = con.DataToEntity(fn.GetDataRow("SELECT * FROM Kullanici WHERE kulEposta = '" + ePosta + "'"));
                if (k != null) {
                    //eposta gönterme işlemleri eklenecek

                    return new NIslemSonuc<bool>
                    {
                        BasariliMi = true,
                        Veri = true
                    };
                }
                else
                    return new NIslemSonuc<bool>
                    {
                        BasariliMi = false,
                        Mesaj = "Sistemde '" + ePosta + "'eposta adresine ait kullanıcı bulunamadı."
                    };
            }
            catch (Exception hata)
            {
                return new NIslemSonuc<bool>
                {
                    BasariliMi = false,
                    HataBilgi = new NHata
                    {
                        Sinif = "KullaniciRepository",
                        Metod = "SifremiUnuttum",
                        HataMesaj = hata.Message
                    },
                    Mesaj = "Bir hata ile karşılaşıldı."
                };
            }
        }
        public NIslemSonuc<IList<KulIslem>> Siparisler(int kulId)
        {
            try
            {
                var kiList = ccon.DataToListEntity(fn.GetDataTable("SELECT * FROM KulIslem WHERE kulId = " + kulId));
                if (kiList.Count() > 0)
                {
                    return new NIslemSonuc<IList<KulIslem>>
                            {
                                BasariliMi = true,
                                Veri = (IList<KulIslem>)kiList
                            }; 
                }else
                    return new NIslemSonuc<IList<KulIslem>>
                    {
                        BasariliMi = false,
                        Mesaj = "Sipariş bulunamadı."
                    };
            }
            catch (Exception hata)
            {
                 return new NIslemSonuc<IList<KulIslem>>
                {
                    BasariliMi = false,
                    HataBilgi = new NHata
                    {
                        Sinif = "KullaniciRepository",
                        Metod = "Siparisler",
                        HataMesaj = hata.Message
                    },
                    Mesaj = "Bir hata ile karşılaşıldı."
                };
            }
        }

        public NIslemSonuc<bool> SiparisKaydet(KulIslem ki)
        {
            try
            {
                //kayıt işlemi Veritabanı ile 
                return new NIslemSonuc<bool>
                {
                    BasariliMi = true,
                    Veri = true
                };

                
            }
            catch (Exception hata)
            {
                return new NIslemSonuc<bool>
                {
                    BasariliMi = false,
                    HataBilgi = new NHata
                    {
                        Sinif = "KullaniciRepository",
                        Metod = "SiparisKaydet",
                        HataMesaj = hata.Message
                    },
                    Mesaj = "Bir hata ile karşılaşıldı."
                };
            }
        }


    }
}
