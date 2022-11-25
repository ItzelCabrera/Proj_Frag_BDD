
namespace Proj_Frag_App
{
    partial class frmPRINCIPAL
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbtn1 = new System.Windows.Forms.RadioButton();
            this.rbtn2 = new System.Windows.Forms.RadioButton();
            this.rbtn3 = new System.Windows.Forms.RadioButton();
            this.rbtn4 = new System.Windows.Forms.RadioButton();
            this.btnUPDATE = new System.Windows.Forms.Button();
            this.btnREAD = new System.Windows.Forms.Button();
            this.pnlCONSULTAS = new System.Windows.Forms.Panel();
            this.pnlConF = new System.Windows.Forms.Panel();
            this.txtCF1 = new System.Windows.Forms.TextBox();
            this.lblCF1 = new System.Windows.Forms.Label();
            this.pnlConE = new System.Windows.Forms.Panel();
            this.lblCE2 = new System.Windows.Forms.Label();
            this.txtCE1 = new System.Windows.Forms.TextBox();
            this.lblCE1 = new System.Windows.Forms.Label();
            this.btnGO = new System.Windows.Forms.Button();
            this.dataGV = new System.Windows.Forms.DataGridView();
            this.pnlConG = new System.Windows.Forms.Panel();
            this.txtCG2 = new System.Windows.Forms.TextBox();
            this.lblCG2 = new System.Windows.Forms.Label();
            this.txtCG1 = new System.Windows.Forms.TextBox();
            this.lblCG1 = new System.Windows.Forms.Label();
            this.lblCE3 = new System.Windows.Forms.Label();
            this.txtCE2 = new System.Windows.Forms.TextBox();
            this.txtCE3 = new System.Windows.Forms.TextBox();
            this.txtCF2 = new System.Windows.Forms.TextBox();
            this.lblCF2 = new System.Windows.Forms.Label();
            this.pnlConA = new System.Windows.Forms.Panel();
            this.txtCA1 = new System.Windows.Forms.TextBox();
            this.lblCA1 = new System.Windows.Forms.Label();
            this.pnlCONSULTAS.SuspendLayout();
            this.pnlConF.SuspendLayout();
            this.pnlConE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.pnlConG.SuspendLayout();
            this.pnlConA.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtn1
            // 
            this.rbtn1.AutoSize = true;
            this.rbtn1.Location = new System.Drawing.Point(194, 31);
            this.rbtn1.Name = "rbtn1";
            this.rbtn1.Size = new System.Drawing.Size(17, 16);
            this.rbtn1.TabIndex = 0;
            this.rbtn1.TabStop = true;
            this.rbtn1.UseVisualStyleBackColor = true;
            this.rbtn1.CheckedChanged += new System.EventHandler(this.rbtn1_CheckedChanged);
            // 
            // rbtn2
            // 
            this.rbtn2.AutoSize = true;
            this.rbtn2.Location = new System.Drawing.Point(194, 58);
            this.rbtn2.Name = "rbtn2";
            this.rbtn2.Size = new System.Drawing.Size(17, 16);
            this.rbtn2.TabIndex = 1;
            this.rbtn2.TabStop = true;
            this.rbtn2.UseVisualStyleBackColor = true;
            this.rbtn2.CheckedChanged += new System.EventHandler(this.rbtn2_CheckedChanged);
            // 
            // rbtn3
            // 
            this.rbtn3.AutoSize = true;
            this.rbtn3.Location = new System.Drawing.Point(194, 85);
            this.rbtn3.Name = "rbtn3";
            this.rbtn3.Size = new System.Drawing.Size(17, 16);
            this.rbtn3.TabIndex = 2;
            this.rbtn3.TabStop = true;
            this.rbtn3.UseVisualStyleBackColor = true;
            this.rbtn3.CheckedChanged += new System.EventHandler(this.rbtn3_CheckedChanged);
            // 
            // rbtn4
            // 
            this.rbtn4.AutoSize = true;
            this.rbtn4.Location = new System.Drawing.Point(194, 112);
            this.rbtn4.Name = "rbtn4";
            this.rbtn4.Size = new System.Drawing.Size(17, 16);
            this.rbtn4.TabIndex = 3;
            this.rbtn4.TabStop = true;
            this.rbtn4.UseVisualStyleBackColor = true;
            this.rbtn4.CheckedChanged += new System.EventHandler(this.rbtn4_CheckedChanged);
            // 
            // btnUPDATE
            // 
            this.btnUPDATE.Location = new System.Drawing.Point(45, 51);
            this.btnUPDATE.Name = "btnUPDATE";
            this.btnUPDATE.Size = new System.Drawing.Size(110, 23);
            this.btnUPDATE.TabIndex = 4;
            this.btnUPDATE.Text = "UPDATE";
            this.btnUPDATE.UseVisualStyleBackColor = true;
            this.btnUPDATE.Click += new System.EventHandler(this.btnUPDATE_Click);
            // 
            // btnREAD
            // 
            this.btnREAD.Location = new System.Drawing.Point(45, 81);
            this.btnREAD.Name = "btnREAD";
            this.btnREAD.Size = new System.Drawing.Size(110, 23);
            this.btnREAD.TabIndex = 5;
            this.btnREAD.Text = "READ";
            this.btnREAD.UseVisualStyleBackColor = true;
            this.btnREAD.Click += new System.EventHandler(this.btnREAD_Click);
            // 
            // pnlCONSULTAS
            // 
            this.pnlCONSULTAS.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlCONSULTAS.Controls.Add(this.pnlConA);
            this.pnlCONSULTAS.Controls.Add(this.pnlConF);
            this.pnlCONSULTAS.Controls.Add(this.pnlConE);
            this.pnlCONSULTAS.Controls.Add(this.btnGO);
            this.pnlCONSULTAS.Controls.Add(this.dataGV);
            this.pnlCONSULTAS.Controls.Add(this.pnlConG);
            this.pnlCONSULTAS.Location = new System.Drawing.Point(30, 148);
            this.pnlCONSULTAS.Name = "pnlCONSULTAS";
            this.pnlCONSULTAS.Size = new System.Drawing.Size(924, 293);
            this.pnlCONSULTAS.TabIndex = 6;
            // 
            // pnlConF
            // 
            this.pnlConF.Controls.Add(this.txtCF2);
            this.pnlConF.Controls.Add(this.lblCF2);
            this.pnlConF.Controls.Add(this.txtCF1);
            this.pnlConF.Controls.Add(this.lblCF1);
            this.pnlConF.Location = new System.Drawing.Point(15, 17);
            this.pnlConF.Name = "pnlConF";
            this.pnlConF.Size = new System.Drawing.Size(797, 53);
            this.pnlConF.TabIndex = 5;
            // 
            // txtCF1
            // 
            this.txtCF1.Location = new System.Drawing.Point(88, 18);
            this.txtCF1.MaxLength = 5;
            this.txtCF1.Name = "txtCF1";
            this.txtCF1.Size = new System.Drawing.Size(100, 22);
            this.txtCF1.TabIndex = 1;
            // 
            // lblCF1
            // 
            this.lblCF1.AutoSize = true;
            this.lblCF1.Location = new System.Drawing.Point(23, 18);
            this.lblCF1.Name = "lblCF1";
            this.lblCF1.Size = new System.Drawing.Size(59, 17);
            this.lblCF1.TabIndex = 0;
            this.lblCF1.Text = "Method:";
            // 
            // pnlConE
            // 
            this.pnlConE.Controls.Add(this.txtCE3);
            this.pnlConE.Controls.Add(this.txtCE2);
            this.pnlConE.Controls.Add(this.lblCE3);
            this.pnlConE.Controls.Add(this.lblCE2);
            this.pnlConE.Controls.Add(this.txtCE1);
            this.pnlConE.Controls.Add(this.lblCE1);
            this.pnlConE.Location = new System.Drawing.Point(15, 17);
            this.pnlConE.Name = "pnlConE";
            this.pnlConE.Size = new System.Drawing.Size(797, 53);
            this.pnlConE.TabIndex = 4;
            // 
            // lblCE2
            // 
            this.lblCE2.AutoSize = true;
            this.lblCE2.Location = new System.Drawing.Point(230, 18);
            this.lblCE2.Name = "lblCE2";
            this.lblCE2.Size = new System.Drawing.Size(60, 17);
            this.lblCE2.TabIndex = 2;
            this.lblCE2.Text = "SalesID:";
            // 
            // txtCE1
            // 
            this.txtCE1.Location = new System.Drawing.Point(104, 18);
            this.txtCE1.MaxLength = 5;
            this.txtCE1.Name = "txtCE1";
            this.txtCE1.Size = new System.Drawing.Size(100, 22);
            this.txtCE1.TabIndex = 1;
            // 
            // lblCE1
            // 
            this.lblCE1.AutoSize = true;
            this.lblCE1.Location = new System.Drawing.Point(17, 18);
            this.lblCE1.Name = "lblCE1";
            this.lblCE1.Size = new System.Drawing.Size(65, 17);
            this.lblCE1.TabIndex = 0;
            this.lblCE1.Text = "Quantity:";
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(825, 17);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 53);
            this.btnGO.TabIndex = 2;
            this.btnGO.Text = "GO";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // dataGV
            // 
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Location = new System.Drawing.Point(15, 86);
            this.dataGV.Name = "dataGV";
            this.dataGV.RowHeadersWidth = 51;
            this.dataGV.RowTemplate.Height = 24;
            this.dataGV.Size = new System.Drawing.Size(885, 184);
            this.dataGV.TabIndex = 1;
            // 
            // pnlConG
            // 
            this.pnlConG.Controls.Add(this.txtCG2);
            this.pnlConG.Controls.Add(this.lblCG2);
            this.pnlConG.Controls.Add(this.txtCG1);
            this.pnlConG.Controls.Add(this.lblCG1);
            this.pnlConG.Location = new System.Drawing.Point(15, 17);
            this.pnlConG.Name = "pnlConG";
            this.pnlConG.Size = new System.Drawing.Size(797, 53);
            this.pnlConG.TabIndex = 0;
            // 
            // txtCG2
            // 
            this.txtCG2.Location = new System.Drawing.Point(311, 18);
            this.txtCG2.MaxLength = 50;
            this.txtCG2.Name = "txtCG2";
            this.txtCG2.Size = new System.Drawing.Size(213, 22);
            this.txtCG2.TabIndex = 3;
            // 
            // lblCG2
            // 
            this.lblCG2.AutoSize = true;
            this.lblCG2.Location = new System.Drawing.Point(230, 18);
            this.lblCG2.Name = "lblCG2";
            this.lblCG2.Size = new System.Drawing.Size(75, 17);
            this.lblCG2.TabIndex = 2;
            this.lblCG2.Text = "new EMail:";
            // 
            // txtCG1
            // 
            this.txtCG1.Location = new System.Drawing.Point(104, 18);
            this.txtCG1.MaxLength = 5;
            this.txtCG1.Name = "txtCG1";
            this.txtCG1.Size = new System.Drawing.Size(100, 22);
            this.txtCG1.TabIndex = 1;
            // 
            // lblCG1
            // 
            this.lblCG1.AutoSize = true;
            this.lblCG1.Location = new System.Drawing.Point(17, 18);
            this.lblCG1.Name = "lblCG1";
            this.lblCG1.Size = new System.Drawing.Size(85, 17);
            this.lblCG1.TabIndex = 0;
            this.lblCG1.Text = "CostumerID:";
            // 
            // lblCE3
            // 
            this.lblCE3.AutoSize = true;
            this.lblCE3.Location = new System.Drawing.Point(425, 18);
            this.lblCE3.Name = "lblCE3";
            this.lblCE3.Size = new System.Drawing.Size(74, 17);
            this.lblCE3.TabIndex = 4;
            this.lblCE3.Text = "ProductID:";
            // 
            // txtCE2
            // 
            this.txtCE2.Location = new System.Drawing.Point(296, 18);
            this.txtCE2.MaxLength = 5;
            this.txtCE2.Name = "txtCE2";
            this.txtCE2.Size = new System.Drawing.Size(100, 22);
            this.txtCE2.TabIndex = 5;
            // 
            // txtCE3
            // 
            this.txtCE3.Location = new System.Drawing.Point(505, 18);
            this.txtCE3.MaxLength = 5;
            this.txtCE3.Name = "txtCE3";
            this.txtCE3.Size = new System.Drawing.Size(100, 22);
            this.txtCE3.TabIndex = 6;
            // 
            // txtCF2
            // 
            this.txtCF2.Location = new System.Drawing.Point(296, 18);
            this.txtCF2.MaxLength = 5;
            this.txtCF2.Name = "txtCF2";
            this.txtCF2.Size = new System.Drawing.Size(100, 22);
            this.txtCF2.TabIndex = 8;
            // 
            // lblCF2
            // 
            this.lblCF2.AutoSize = true;
            this.lblCF2.Location = new System.Drawing.Point(230, 18);
            this.lblCF2.Name = "lblCF2";
            this.lblCF2.Size = new System.Drawing.Size(60, 17);
            this.lblCF2.TabIndex = 7;
            this.lblCF2.Text = "SalesID:";
            // 
            // pnlConA
            // 
            this.pnlConA.Controls.Add(this.txtCA1);
            this.pnlConA.Controls.Add(this.lblCA1);
            this.pnlConA.Location = new System.Drawing.Point(15, 17);
            this.pnlConA.Name = "pnlConA";
            this.pnlConA.Size = new System.Drawing.Size(797, 53);
            this.pnlConA.TabIndex = 9;
            // 
            // txtCA1
            // 
            this.txtCA1.Location = new System.Drawing.Point(88, 18);
            this.txtCA1.MaxLength = 5;
            this.txtCA1.Name = "txtCA1";
            this.txtCA1.Size = new System.Drawing.Size(100, 22);
            this.txtCA1.TabIndex = 1;
            // 
            // lblCA1
            // 
            this.lblCA1.AutoSize = true;
            this.lblCA1.Location = new System.Drawing.Point(23, 18);
            this.lblCA1.Name = "lblCA1";
            this.lblCA1.Size = new System.Drawing.Size(59, 17);
            this.lblCA1.TabIndex = 0;
            this.lblCA1.Text = "Method:";
            // 
            // frmPRINCIPAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(982, 453);
            this.Controls.Add(this.pnlCONSULTAS);
            this.Controls.Add(this.btnREAD);
            this.Controls.Add(this.btnUPDATE);
            this.Controls.Add(this.rbtn4);
            this.Controls.Add(this.rbtn3);
            this.Controls.Add(this.rbtn2);
            this.Controls.Add(this.rbtn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPRINCIPAL";
            this.Text = "App Consultas Distribuidas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlCONSULTAS.ResumeLayout(false);
            this.pnlConF.ResumeLayout(false);
            this.pnlConF.PerformLayout();
            this.pnlConE.ResumeLayout(false);
            this.pnlConE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.pnlConG.ResumeLayout(false);
            this.pnlConG.PerformLayout();
            this.pnlConA.ResumeLayout(false);
            this.pnlConA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtn1;
        private System.Windows.Forms.RadioButton rbtn2;
        private System.Windows.Forms.RadioButton rbtn3;
        private System.Windows.Forms.RadioButton rbtn4;
        private System.Windows.Forms.Button btnUPDATE;
        private System.Windows.Forms.Button btnREAD;
        private System.Windows.Forms.Panel pnlCONSULTAS;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.DataGridView dataGV;
        private System.Windows.Forms.Panel pnlConG;
        private System.Windows.Forms.TextBox txtCG2;
        private System.Windows.Forms.Label lblCG2;
        private System.Windows.Forms.TextBox txtCG1;
        private System.Windows.Forms.Label lblCG1;
        private System.Windows.Forms.Panel pnlConF;
        private System.Windows.Forms.TextBox txtCF1;
        private System.Windows.Forms.Label lblCF1;
        private System.Windows.Forms.Panel pnlConE;
        private System.Windows.Forms.Label lblCE2;
        private System.Windows.Forms.TextBox txtCE1;
        private System.Windows.Forms.Label lblCE1;
        private System.Windows.Forms.TextBox txtCE3;
        private System.Windows.Forms.TextBox txtCE2;
        private System.Windows.Forms.Label lblCE3;
        private System.Windows.Forms.TextBox txtCF2;
        private System.Windows.Forms.Label lblCF2;
        private System.Windows.Forms.Panel pnlConA;
        private System.Windows.Forms.TextBox txtCA1;
        private System.Windows.Forms.Label lblCA1;
    }
}

