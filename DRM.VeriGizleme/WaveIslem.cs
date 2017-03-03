using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DRM.VeriGizleme
{
    public class WaveIslem
    {
        public byte[] MesajGizle(string stringMesaj, Byte[] byteWave, string kayitYeri)
        {
            //   int[] mesajUzunluk = { stringMesaj.Length };

            //Mesajı ASCII kodu haline getir(byte)
            //byte[] asciiBytes = Encoding.ASCII.GetBytes(stringMesaj); //Hata var türkçe karakter
            byte[] asciiBytes = Encoding.UTF8.GetBytes(stringMesaj);
            int[] mesajUzunluk = { asciiBytes.Length };

            //Mesajı ve mesaj uzunluğunu bit array haline getir;
            BitArray mesajU = new BitArray(mesajUzunluk);
            BitArray mesajIcerik = new BitArray(asciiBytes);
            //Mesaj uzunlugunu ve mesajı bitarrray olarak birleştir
            var bools = new bool[mesajU.Count + mesajIcerik.Count];
            mesajU.CopyTo(bools, 0);
            mesajIcerik.CopyTo(bools, mesajU.Count);
            BitArray mesaj = new BitArray(bools);

            //Wav dosyasını bit array haline getir
            BitArray WaveDosyası = new BitArray(byteWave);

            //wav dosyası içerisinde 8 bit ilerletir
            int bitIndex = 0;
            //Sonuc byte dizisi tanımlandı
            byte[] byteSonuc = new byte[(WaveDosyası.Length) / 8];
            //Ses dosyasın alabileceği mesaj kapasitesi (her 1 Byte alana 1 bit yazıldığı için 8 e bölündü)
            int dosyaMesajKapasitesi = byteWave.Length / 8;
            //Dosya mesaj kapasitesi: Mesaj + Mesaj uzunluk alanını(4 byte) dan küçük veya eşit olmalı 
            if (dosyaMesajKapasitesi >= stringMesaj.Length + 4)
            {
                //mesaj uzunluğu(bit cinsinden) kadar işlem yap
                for (int i = 0; i < mesaj.Length; i++)
                {
                    WaveDosyası[bitIndex] = mesaj[i];
                    //index i 8 bit ilerlet
                    bitIndex += 8;
                }
                //Bit dizisi halindeki ses dosyasını byte dizine dönüştür ve sonucu wav dosyası olarak kaydet
                WaveDosyası.CopyTo(byteSonuc, 0);

                //File.WriteAllBytes(kayitYeri, byteSonuc);
                MessageBox.Show("Mesaj Başarıyla Gizlendi.");
            }
            else
                MessageBox.Show("Ses dosyanız bu mesajı gizleyecek büyüklükte değil!.\nMaximum " + (dosyaMesajKapasitesi - 4) + " karakter mesaj giriniz.");
            return byteSonuc;
        }

        public string MesajOku(Byte[] bytes)
        {
            string sonuc = "";

            //Mesaj Uzunluğu ve Mesaj İçeriği 
            BitArray mesajUzunluk = new BitArray(32);

            //Wav dosyasını bit array haline getir
            BitArray WaveDosyası = new BitArray(bytes);

            //wav dosyası içerisinde 8 bit ilerletir
            int bitIndex = 0;
            //mesaj uzunluğu(bit cinsinden) kadar işlem yap
            for (int i = 0; i < 32; i++)
            {
                if (i < 32)
                    mesajUzunluk[i] = WaveDosyası[bitIndex];
                //index i 8 bit ilerlet
                bitIndex += 8;
            }
            //Mesajın çıkartılması
            byte[] uzunlukSonuc = new byte[4];
            mesajUzunluk.CopyTo(uzunlukSonuc, 0);
            //uzunluk alanına byte cinsinden uzunluk yazılmıştır. Mesajı çıkartma işleminde bit üzerinden işlem yapılıyor
            int mesajUzunlukByte = BitConverter.ToInt32(uzunlukSonuc, 0);
            //(ses dosyasındaki data kısmınada her byte'ın LSB bitine mesajın bit biti yazılır. )
            int mesajUzunlukBit = mesajUzunlukByte * 8;
            //Mesaj uzunluk alanındaki değer sıfırdan büyük ise işleme başla
            if (mesajUzunlukBit > 0)
            {
                BitArray mesajICerik = new BitArray(mesajUzunlukBit);
                bitIndex = 0;
                //mesajUzunluğu 32 bit -> ses doasyası içinde 32*8 = 256 bit alana yayılır
                int mesajBaslangic = 32 * 8;
                for (int i = 0; i < mesajUzunlukBit; i++)
                {
                    mesajICerik[i] = WaveDosyası[mesajBaslangic + bitIndex];
                    //index i 8 bit ilerlet
                    bitIndex += 8;
                }

                //Mesajı Byte çevir
                byte[] mesajSonuc = new byte[mesajUzunlukByte];
                mesajICerik.CopyTo(mesajSonuc, 0);

                //Mesajı textbox a yazdır
                sonuc = Encoding.UTF8.GetString(mesajSonuc);
                return sonuc;
            }
            
            return sonuc;
        }

      
    }
}
