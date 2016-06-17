namespace Ordenador
{
    partial class Sobre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sobre));
            this.GB_Sobre = new System.Windows.Forms.GroupBox();
            this.TXB_Sobre = new System.Windows.Forms.TextBox();
            this.LLB_CodigoFonte = new System.Windows.Forms.LinkLabel();
            this.GB_Sobre.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_Sobre
            // 
            this.GB_Sobre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_Sobre.Controls.Add(this.LLB_CodigoFonte);
            this.GB_Sobre.Controls.Add(this.TXB_Sobre);
            this.GB_Sobre.Location = new System.Drawing.Point(12, 12);
            this.GB_Sobre.Name = "GB_Sobre";
            this.GB_Sobre.Size = new System.Drawing.Size(296, 234);
            this.GB_Sobre.TabIndex = 1;
            this.GB_Sobre.TabStop = false;
            this.GB_Sobre.Text = "Sobre";
            // 
            // TXB_Sobre
            // 
            this.TXB_Sobre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXB_Sobre.Location = new System.Drawing.Point(6, 69);
            this.TXB_Sobre.Multiline = true;
            this.TXB_Sobre.Name = "TXB_Sobre";
            this.TXB_Sobre.Size = new System.Drawing.Size(284, 159);
            this.TXB_Sobre.TabIndex = 0;
            this.TXB_Sobre.Text = resources.GetString("TXB_Sobre.Text");
            // 
            // LLB_CodigoFonte
            // 
            this.LLB_CodigoFonte.AutoSize = true;
            this.LLB_CodigoFonte.Location = new System.Drawing.Point(115, 30);
            this.LLB_CodigoFonte.Name = "LLB_CodigoFonte";
            this.LLB_CodigoFonte.Size = new System.Drawing.Size(67, 13);
            this.LLB_CodigoFonte.TabIndex = 1;
            this.LLB_CodigoFonte.TabStop = true;
            this.LLB_CodigoFonte.Text = "Código fonte";
            // 
            // Sobre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(320, 258);
            this.Controls.Add(this.GB_Sobre);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Sobre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sobre";
            this.Load += new System.EventHandler(this.Sobre_Load);
            this.GB_Sobre.ResumeLayout(false);
            this.GB_Sobre.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Sobre;
        private System.Windows.Forms.TextBox TXB_Sobre;
        private System.Windows.Forms.LinkLabel LLB_CodigoFonte;
    }
}