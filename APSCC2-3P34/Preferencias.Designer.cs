namespace Ordenador
{
    partial class Preferencias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV_MenuPreferencias = new System.Windows.Forms.DataGridView();
            this.C_Preferencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MenuPreferencias)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_MenuPreferencias
            // 
            this.DGV_MenuPreferencias.AllowUserToAddRows = false;
            this.DGV_MenuPreferencias.AllowUserToDeleteRows = false;
            this.DGV_MenuPreferencias.AllowUserToResizeColumns = false;
            this.DGV_MenuPreferencias.AllowUserToResizeRows = false;
            this.DGV_MenuPreferencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_MenuPreferencias.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV_MenuPreferencias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_MenuPreferencias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGV_MenuPreferencias.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_MenuPreferencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_MenuPreferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_MenuPreferencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_Preferencias});
            this.DGV_MenuPreferencias.GridColor = System.Drawing.SystemColors.Window;
            this.DGV_MenuPreferencias.Location = new System.Drawing.Point(12, 12);
            this.DGV_MenuPreferencias.MultiSelect = false;
            this.DGV_MenuPreferencias.Name = "DGV_MenuPreferencias";
            this.DGV_MenuPreferencias.ReadOnly = true;
            this.DGV_MenuPreferencias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_MenuPreferencias.RowHeadersVisible = false;
            this.DGV_MenuPreferencias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV_MenuPreferencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_MenuPreferencias.Size = new System.Drawing.Size(158, 483);
            this.DGV_MenuPreferencias.TabIndex = 0;
            // 
            // C_Preferencias
            // 
            this.C_Preferencias.HeaderText = "Preferências";
            this.C_Preferencias.Name = "C_Preferencias";
            this.C_Preferencias.ReadOnly = true;
            this.C_Preferencias.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.C_Preferencias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(176, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 483);
            this.panel1.TabIndex = 1;
            // 
            // Preferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(704, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGV_MenuPreferencias);
            this.Name = "Preferencias";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferencias";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Preferencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MenuPreferencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_MenuPreferencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Preferencias;
        private System.Windows.Forms.Panel panel1;
    }
}