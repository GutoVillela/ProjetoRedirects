namespace Projeto_Redirects
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialogSitemap = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSitemapUrlAntigo = new System.Windows.Forms.Label();
            this.lblSitemapUrlAtual = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEtapaAtual = new System.Windows.Forms.Label();
            this.saveFileDialogSitemap = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkRemoverSubdominio = new System.Windows.Forms.CheckBox();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.btnGerarRedirects = new System.Windows.Forms.Button();
            this.btnBuscarSitemapAtual = new System.Windows.Forms.Button();
            this.btnBuscarSitemapAntigo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialogSitemap
            // 
            this.openFileDialogSitemap.FileName = "openFileDialog1";
            this.openFileDialogSitemap.Filter = "Arquivos XML (*.xml)|*.xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sitemap do site antigo:";
            // 
            // lblSitemapUrlAntigo
            // 
            this.lblSitemapUrlAntigo.AutoSize = true;
            this.lblSitemapUrlAntigo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSitemapUrlAntigo.Location = new System.Drawing.Point(174, 114);
            this.lblSitemapUrlAntigo.Name = "lblSitemapUrlAntigo";
            this.lblSitemapUrlAntigo.Size = new System.Drawing.Size(153, 16);
            this.lblSitemapUrlAntigo.TabIndex = 1;
            this.lblSitemapUrlAntigo.Text = "URL do sitemap antigo";
            // 
            // lblSitemapUrlAtual
            // 
            this.lblSitemapUrlAtual.AutoSize = true;
            this.lblSitemapUrlAtual.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSitemapUrlAtual.Location = new System.Drawing.Point(168, 174);
            this.lblSitemapUrlAtual.Name = "lblSitemapUrlAtual";
            this.lblSitemapUrlAtual.Size = new System.Drawing.Size(145, 16);
            this.lblSitemapUrlAtual.TabIndex = 4;
            this.lblSitemapUrlAtual.Text = "URL do sitemap atual";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sitemap do site atual:";
            // 
            // lblEtapaAtual
            // 
            this.lblEtapaAtual.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblEtapaAtual.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEtapaAtual.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtapaAtual.Location = new System.Drawing.Point(0, 344);
            this.lblEtapaAtual.Name = "lblEtapaAtual";
            this.lblEtapaAtual.Size = new System.Drawing.Size(534, 17);
            this.lblEtapaAtual.TabIndex = 7;
            this.lblEtapaAtual.Text = "Aguardando sitemaps...";
            this.lblEtapaAtual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveFileDialogSitemap
            // 
            this.saveFileDialogSitemap.Filter = "Arquivos TXT (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 65);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(153, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gerador de redirects";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Projeto_Redirects.Properties.Resources.icone_gerador_de_redirect;
            this.pictureBox1.Location = new System.Drawing.Point(84, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // chkRemoverSubdominio
            // 
            this.chkRemoverSubdominio.AutoSize = true;
            this.chkRemoverSubdominio.Location = new System.Drawing.Point(12, 223);
            this.chkRemoverSubdominio.Name = "chkRemoverSubdominio";
            this.chkRemoverSubdominio.Size = new System.Drawing.Size(308, 21);
            this.chkRemoverSubdominio.TabIndex = 9;
            this.chkRemoverSubdominio.Text = "Remover subdomínio Cintra Comunicação";
            this.chkRemoverSubdominio.UseVisualStyleBackColor = true;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbProgresso.Location = new System.Drawing.Point(0, 342);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(534, 2);
            this.pgbProgresso.TabIndex = 10;
            // 
            // btnGerarRedirects
            // 
            this.btnGerarRedirects.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGerarRedirects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarRedirects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarRedirects.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarRedirects.ForeColor = System.Drawing.Color.White;
            this.btnGerarRedirects.Image = global::Projeto_Redirects.Properties.Resources.icone_gerar_redirect;
            this.btnGerarRedirects.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarRedirects.Location = new System.Drawing.Point(169, 275);
            this.btnGerarRedirects.Name = "btnGerarRedirects";
            this.btnGerarRedirects.Size = new System.Drawing.Size(173, 50);
            this.btnGerarRedirects.TabIndex = 6;
            this.btnGerarRedirects.Text = "Gerar Redirects";
            this.btnGerarRedirects.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGerarRedirects.UseVisualStyleBackColor = false;
            this.btnGerarRedirects.Click += new System.EventHandler(this.btnGerarRedirects_Click);
            // 
            // btnBuscarSitemapAtual
            // 
            this.btnBuscarSitemapAtual.BackColor = System.Drawing.Color.White;
            this.btnBuscarSitemapAtual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarSitemapAtual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarSitemapAtual.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarSitemapAtual.Image = global::Projeto_Redirects.Properties.Resources.icone_buscar;
            this.btnBuscarSitemapAtual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarSitemapAtual.Location = new System.Drawing.Point(393, 161);
            this.btnBuscarSitemapAtual.Name = "btnBuscarSitemapAtual";
            this.btnBuscarSitemapAtual.Size = new System.Drawing.Size(129, 45);
            this.btnBuscarSitemapAtual.TabIndex = 5;
            this.btnBuscarSitemapAtual.Text = "Buscar Sitemap";
            this.btnBuscarSitemapAtual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarSitemapAtual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarSitemapAtual.UseVisualStyleBackColor = false;
            this.btnBuscarSitemapAtual.Click += new System.EventHandler(this.btnBuscarSitemapAtual_Click);
            // 
            // btnBuscarSitemapAntigo
            // 
            this.btnBuscarSitemapAntigo.BackColor = System.Drawing.Color.White;
            this.btnBuscarSitemapAntigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarSitemapAntigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarSitemapAntigo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarSitemapAntigo.Image = global::Projeto_Redirects.Properties.Resources.icone_buscar;
            this.btnBuscarSitemapAntigo.Location = new System.Drawing.Point(393, 100);
            this.btnBuscarSitemapAntigo.Name = "btnBuscarSitemapAntigo";
            this.btnBuscarSitemapAntigo.Size = new System.Drawing.Size(129, 45);
            this.btnBuscarSitemapAntigo.TabIndex = 2;
            this.btnBuscarSitemapAntigo.Text = "Buscar Sitemap";
            this.btnBuscarSitemapAntigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarSitemapAntigo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarSitemapAntigo.UseVisualStyleBackColor = false;
            this.btnBuscarSitemapAntigo.Click += new System.EventHandler(this.btnBuscarSitemapAntigo_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.pgbProgresso);
            this.Controls.Add(this.chkRemoverSubdominio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblEtapaAtual);
            this.Controls.Add(this.btnGerarRedirects);
            this.Controls.Add(this.btnBuscarSitemapAtual);
            this.Controls.Add(this.lblSitemapUrlAtual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscarSitemapAntigo);
            this.Controls.Add(this.lblSitemapUrlAntigo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projeto Redirects";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogSitemap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSitemapUrlAntigo;
        private System.Windows.Forms.Button btnBuscarSitemapAntigo;
        private System.Windows.Forms.Button btnBuscarSitemapAtual;
        private System.Windows.Forms.Label lblSitemapUrlAtual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGerarRedirects;
        private System.Windows.Forms.Label lblEtapaAtual;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSitemap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkRemoverSubdominio;
        private System.Windows.Forms.ProgressBar pgbProgresso;
    }
}

