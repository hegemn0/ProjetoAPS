namespace Ordenador
{
    partial class Detalhes
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
            this.PB_Detalhes = new System.Windows.Forms.PictureBox();
            this.B_Fechar = new System.Windows.Forms.Button();
            this.B_Anterior = new System.Windows.Forms.Button();
            this.B_Proximo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Detalhes)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Detalhes
            // 
            this.PB_Detalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_Detalhes.Location = new System.Drawing.Point(12, 12);
            this.PB_Detalhes.Name = "PB_Detalhes";
            this.PB_Detalhes.Size = new System.Drawing.Size(580, 528);
            this.PB_Detalhes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Detalhes.TabIndex = 0;
            this.PB_Detalhes.TabStop = false;
            // 
            // B_Fechar
            // 
            this.B_Fechar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.B_Fechar.Location = new System.Drawing.Point(517, 546);
            this.B_Fechar.Name = "B_Fechar";
            this.B_Fechar.Size = new System.Drawing.Size(75, 23);
            this.B_Fechar.TabIndex = 2;
            this.B_Fechar.Text = "Fechar";
            this.B_Fechar.UseVisualStyleBackColor = true;
            this.B_Fechar.Click += new System.EventHandler(this.B_Fechar_Click);
            // 
            // B_Anterior
            // 
            this.B_Anterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.B_Anterior.Location = new System.Drawing.Point(355, 546);
            this.B_Anterior.Name = "B_Anterior";
            this.B_Anterior.Size = new System.Drawing.Size(75, 23);
            this.B_Anterior.TabIndex = 3;
            this.B_Anterior.Text = "<";
            this.B_Anterior.UseVisualStyleBackColor = true;
            this.B_Anterior.Click += new System.EventHandler(this.B_Anterior_Click);
            // 
            // B_Proximo
            // 
            this.B_Proximo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.B_Proximo.Location = new System.Drawing.Point(436, 546);
            this.B_Proximo.Name = "B_Proximo";
            this.B_Proximo.Size = new System.Drawing.Size(75, 23);
            this.B_Proximo.TabIndex = 3;
            this.B_Proximo.Text = ">";
            this.B_Proximo.UseVisualStyleBackColor = true;
            this.B_Proximo.Click += new System.EventHandler(this.B_Proximo_Click);
            // 
            // Detalhes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(604, 581);
            this.Controls.Add(this.B_Proximo);
            this.Controls.Add(this.B_Anterior);
            this.Controls.Add(this.B_Fechar);
            this.Controls.Add(this.PB_Detalhes);
            this.DoubleBuffered = true;
            this.Name = "Detalhes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalhes";
            this.Load += new System.EventHandler(this.Detalhes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Detalhes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Detalhes;
        private System.Windows.Forms.Button B_Fechar;
        private System.Windows.Forms.Button B_Anterior;
        private System.Windows.Forms.Button B_Proximo;
    }
}