namespace Ordenador
{
    partial class Resultado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV_Resultado = new System.Windows.Forms.DataGridView();
            this.Original = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BubbleSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertionSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectionSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuickSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B_Fechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Resultado
            // 
            this.DGV_Resultado.AllowUserToAddRows = false;
            this.DGV_Resultado.AllowUserToDeleteRows = false;
            this.DGV_Resultado.AllowUserToResizeColumns = false;
            this.DGV_Resultado.AllowUserToResizeRows = false;
            this.DGV_Resultado.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV_Resultado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Resultado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_Resultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Original,
            this.BubbleSort,
            this.InsertionSort,
            this.SelectionSort,
            this.QuickSort});
            this.DGV_Resultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.DGV_Resultado.Location = new System.Drawing.Point(0, 0);
            this.DGV_Resultado.Name = "DGV_Resultado";
            this.DGV_Resultado.ReadOnly = true;
            this.DGV_Resultado.RowHeadersVisible = false;
            this.DGV_Resultado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV_Resultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Resultado.Size = new System.Drawing.Size(723, 486);
            this.DGV_Resultado.TabIndex = 1;
            // 
            // Original
            // 
            this.Original.Frozen = true;
            this.Original.HeaderText = "Original";
            this.Original.Name = "Original";
            this.Original.ReadOnly = true;
            // 
            // BubbleSort
            // 
            this.BubbleSort.Frozen = true;
            this.BubbleSort.HeaderText = "Bubble Sort";
            this.BubbleSort.Name = "BubbleSort";
            this.BubbleSort.ReadOnly = true;
            // 
            // InsertionSort
            // 
            this.InsertionSort.Frozen = true;
            this.InsertionSort.HeaderText = "Insertion Sort";
            this.InsertionSort.Name = "InsertionSort";
            this.InsertionSort.ReadOnly = true;
            // 
            // SelectionSort
            // 
            this.SelectionSort.Frozen = true;
            this.SelectionSort.HeaderText = "Selection Sort";
            this.SelectionSort.Name = "SelectionSort";
            this.SelectionSort.ReadOnly = true;
            // 
            // QuickSort
            // 
            this.QuickSort.Frozen = true;
            this.QuickSort.HeaderText = "Quick Sort";
            this.QuickSort.Name = "QuickSort";
            this.QuickSort.ReadOnly = true;
            // 
            // B_Fechar
            // 
            this.B_Fechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Fechar.Location = new System.Drawing.Point(636, 492);
            this.B_Fechar.Name = "B_Fechar";
            this.B_Fechar.Size = new System.Drawing.Size(75, 23);
            this.B_Fechar.TabIndex = 2;
            this.B_Fechar.Text = "Fechar";
            this.B_Fechar.UseVisualStyleBackColor = true;
            // 
            // Resultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(723, 527);
            this.Controls.Add(this.B_Fechar);
            this.Controls.Add(this.DGV_Resultado);
            this.Name = "Resultado";
            this.Text = "Resultado";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Resultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Resultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Original;
        private System.Windows.Forms.DataGridViewTextBoxColumn BubbleSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertionSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectionSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuickSort;
        private System.Windows.Forms.Button B_Fechar;
    }
}