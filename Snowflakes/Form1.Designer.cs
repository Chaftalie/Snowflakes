namespace Snowflakes
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pBx_main = new System.Windows.Forms.PictureBox();
            this.tmr_16ms = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pBx_main)).BeginInit();
            this.SuspendLayout();
            // 
            // pBx_main
            // 
            this.pBx_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pBx_main.Location = new System.Drawing.Point(0, 0);
            this.pBx_main.Name = "pBx_main";
            this.pBx_main.Size = new System.Drawing.Size(5760, 1080);
            this.pBx_main.TabIndex = 0;
            this.pBx_main.TabStop = false;
            this.pBx_main.Paint += new System.Windows.Forms.PaintEventHandler(this.pBx_main_Paint);
            // 
            // tmr_16ms
            // 
            this.tmr_16ms.Enabled = true;
            this.tmr_16ms.Interval = 2;
            this.tmr_16ms.Tick += new System.EventHandler(this.tmr_16ms_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pBx_main);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pBx_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBx_main;
        private System.Windows.Forms.Timer tmr_16ms;
    }
}

