using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BitirmeDRM.UI
{
    public class MesajGizle
    {
        public byte[] Gizle(string stringMesaj, Byte[] byteWave, string kayitYeri)
        {
            int[] mesajUzunluk = { stringMesaj.Length };
            //Mesajı ASCII kodu haline getir(byte)
            byte[] asciiBytes = Encoding.ASCII.GetBytes(stringMesaj);
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

               
            }
            
            return byteSonuc;
        }

    }
}