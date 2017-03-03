namespace DRM.VeriGizleme
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtOpenFile = new System.Windows.Forms.TextBox();
            this.btnGizle = new System.Windows.Forms.Button();
            this.txtKayitYeri = new System.Windows.Forms.TextBox();
            this.btnKayitYeri = new System.Windows.Forms.Button();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSrcMOku = new System.Windows.Forms.TextBox();
            this.btnSrcMOku = new System.Windows.Forms.Button();
            this.txtOkuMesaj = new System.Windows.Forms.TextBox();
            this.btnOkuMesaj = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(261, 6);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Dosya Seç";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtOpenFile
            // 
            this.txtOpenFile.Location = new System.Drawing.Point(6, 8);
            this.txtOpenFile.Name = "txtOpenFile";
            this.txtOpenFile.Size = new System.Drawing.Size(249, 20);
            this.txtOpenFile.TabIndex = 1;
            // 
            // btnGizle
            // 
            this.btnGizle.Location = new System.Drawing.Point(264, 171);
            this.btnGizle.Name = "btnGizle";
            this.btnGizle.Size = new System.Drawing.Size(75, 23);
            this.btnGizle.TabIndex = 3;
            this.btnGizle.Text = "Gizle";
            this.btnGizle.UseVisualStyleBackColor = true;
            this.btnGizle.Click += new System.EventHandler(this.btnGizle_Click);
            // 
            // txtKayitYeri
            // 
            this.txtKayitYeri.Location = new System.Drawing.Point(6, 34);
            this.txtKayitYeri.Name = "txtKayitYeri";
            this.txtKayitYeri.Size = new System.Drawing.Size(249, 20);
            this.txtKayitYeri.TabIndex = 5;
            // 
            // btnKayitYeri
            // 
            this.btnKayitYeri.Location = new System.Drawing.Point(261, 34);
            this.btnKayitYeri.Name = "btnKayitYeri";
            this.btnKayitYeri.Size = new System.Drawing.Size(75, 23);
            this.btnKayitYeri.TabIndex = 6;
            this.btnKayitYeri.Text = "Kayıt Yeri";
            this.btnKayitYeri.UseVisualStyleBackColor = true;
            this.btnKayitYeri.Click += new System.EventHandler(this.btnKayitYeri_Click);
            // 
            // txtMesaj
            // 
            this.txtMesaj.Location = new System.Drawing.Point(6, 81);
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(330, 84);
            this.txtMesaj.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Gizlenecek Mesaj";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(350, 226);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMesaj);
            this.tabPage1.Controls.Add(this.btnKayitYeri);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtKayitYeri);
            this.tabPage1.Controls.Add(this.btnGizle);
            this.tabPage1.Controls.Add(this.txtOpenFile);
            this.tabPage1.Controls.Add(this.btnOpenFile);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(342, 200);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mesaj Gizle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtSrcMOku);
            this.tabPage2.Controls.Add(this.btnSrcMOku);
            this.tabPage2.Controls.Add(this.txtOkuMesaj);
            this.tabPage2.Controls.Add(this.btnOkuMesaj);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(342, 200);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mesaj Çıkart";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Okunan Mesaj";
            // 
            // txtSrcMOku
            // 
            this.txtSrcMOku.Location = new System.Drawing.Point(6, 8);
            this.txtSrcMOku.Name = "txtSrcMOku";
            this.txtSrcMOku.Size = new System.Drawing.Size(249, 20);
            this.txtSrcMOku.TabIndex = 15;
            // 
            // btnSrcMOku
            // 
            this.btnSrcMOku.Location = new System.Drawing.Point(261, 6);
            this.btnSrcMOku.Name = "btnSrcMOku";
            this.btnSrcMOku.Size = new System.Drawing.Size(75, 23);
            this.btnSrcMOku.TabIndex = 14;
            this.btnSrcMOku.Text = "Dosya Seç";
            this.btnSrcMOku.UseVisualStyleBackColor = true;
            this.btnSrcMOku.Click += new System.EventHandler(this.btnSrcMOku_Click);
            // 
            // txtOkuMesaj
            // 
            this.txtOkuMesaj.Enabled = false;
            this.txtOkuMesaj.Location = new System.Drawing.Point(6, 81);
            this.txtOkuMesaj.Multiline = true;
            this.txtOkuMesaj.Name = "txtOkuMesaj";
            this.txtOkuMesaj.Size = new System.Drawing.Size(330, 84);
            this.txtOkuMesaj.TabIndex = 12;
            // 
            // btnOkuMesaj
            // 
            this.btnOkuMesaj.Location = new System.Drawing.Point(264, 171);
            this.btnOkuMesaj.Name = "btnOkuMesaj";
            this.btnOkuMesaj.Size = new System.Drawing.Size(75, 23);
            this.btnOkuMesaj.TabIndex = 11;
            this.btnOkuMesaj.Text = "Çıkart";
            this.btnOkuMesaj.UseVisualStyleBackColor = true;
            this.btnOkuMesaj.Click += new System.EventHandler(this.btnOkuMesaj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 248);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Watermarking";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtOpenFile;
        private System.Windows.Forms.Button btnGizle;
        private System.Windows.Forms.TextBox txtKayitYeri;
        private System.Windows.Forms.Button btnKayitYeri;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtOkuMesaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOkuMesaj;
        private System.Windows.Forms.TextBox txtSrcMOku;
        private System.Windows.Forms.Button btnSrcMOku;
    }
}

