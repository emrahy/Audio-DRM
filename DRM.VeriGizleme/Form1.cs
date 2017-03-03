using System;
using System.IO;
using System.Windows.Forms;
using System.Management;

namespace DRM.VeriGizleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            GetFileName(dlg, txtOpenFile);
        }

        //Veri gizleme işlemi yapılan wav dosyasının kayıt yeri
        private void btnKayitYeri_Click(object sender, EventArgs e)
        {
            SaveFileDialog kayitYeri = new SaveFileDialog();
            GetFileName(kayitYeri, txtKayitYeri);
        }
        //Mesaj çıkartılacak ses dosyası
        private void btnSrcMOku_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            GetFileName(dlg, txtSrcMOku);
        }

        //Açılan dosya konumunu al
        private void GetFileName(FileDialog dialog, TextBox control)
        {
            dialog.Filter = "Wave Audio (*.wav)|*.wav";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                control.Text = dialog.FileName;
            }
        }
        //Wave işlemlerini içeren class(Mesaj Gizleme ve Mesaj Çıkartma)
        WaveIslem waveIslem = new WaveIslem();
        private void btnGizle_Click(object sender, EventArgs e)
        {
            try
            {
                //Dosyayı byte olarak oku
                Byte[] bytes = File.ReadAllBytes(txtOpenFile.Text);
                WaveDosya waveStream = new WaveDosya(bytes);

                //mesaj içeriği ve uzunluk(max 2.147.483.647(int))
                string stringMesaj = txtMesaj.Text;
                //Wave ses dosyasına mesaj gizleme işlemi
                Byte[] sonuc = waveIslem.MesajGizle(stringMesaj, waveStream.Data, txtKayitYeri.Text);
                Byte[] waveSonuc = ByteArrayBirlestir(waveStream.WaveReadFormat(bytes), sonuc);
                File.WriteAllBytes(txtKayitYeri.Text, waveSonuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu. " + ex.Message);
            }
        }

        private void btnOkuMesaj_Click(object sender, EventArgs e)
        {
            try
            {
                //Dosyayı byte olarak oku
                Byte[] bytes = File.ReadAllBytes(txtSrcMOku.Text);
                //Okunan mesajı göster
                WaveDosya waveStream = new WaveDosya(bytes);
                txtOkuMesaj.Text = waveIslem.MesajOku(waveStream.Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu. " + ex.Message);
            }
        }

        //İki bayt dizisini birleştirme 
        public byte[] ByteArrayBirlestir(byte[] a, byte[] b)
        {
            byte[] bytes = new byte[a.Length + b.Length];

            Array.Copy(a, 0, bytes, 0, a.Length);
            Array.Copy(b, 0, bytes, a.Length, b.Length);
            return bytes;
        }


    }
}
