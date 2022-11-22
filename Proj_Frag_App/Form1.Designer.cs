
namespace Proj_Frag_App
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // rbtn1
            // 
            this.rbtn1.AutoSize = true;
            this.rbtn1.Location = new System.Drawing.Point(377, 33);
            this.rbtn1.Name = "rbtn1";
            this.rbtn1.Size = new System.Drawing.Size(17, 16);
            this.rbtn1.TabIndex = 0;
            this.rbtn1.TabStop = true;
            this.rbtn1.UseVisualStyleBackColor = true;
            // 
            // rbtn2
            // 
            this.rbtn2.AutoSize = true;
            this.rbtn2.Location = new System.Drawing.Point(377, 60);
            this.rbtn2.Name = "rbtn2";
            this.rbtn2.Size = new System.Drawing.Size(17, 16);
            this.rbtn2.TabIndex = 1;
            this.rbtn2.TabStop = true;
            this.rbtn2.UseVisualStyleBackColor = true;
            // 
            // rbtn3
            // 
            this.rbtn3.AutoSize = true;
            this.rbtn3.Location = new System.Drawing.Point(377, 87);
            this.rbtn3.Name = "rbtn3";
            this.rbtn3.Size = new System.Drawing.Size(17, 16);
            this.rbtn3.TabIndex = 2;
            this.rbtn3.TabStop = true;
            this.rbtn3.UseVisualStyleBackColor = true;
            // 
            // rbtn4
            // 
            this.rbtn4.AutoSize = true;
            this.rbtn4.Location = new System.Drawing.Point(377, 114);
            this.rbtn4.Name = "rbtn4";
            this.rbtn4.Size = new System.Drawing.Size(17, 16);
            this.rbtn4.TabIndex = 3;
            this.rbtn4.TabStop = true;
            this.rbtn4.UseVisualStyleBackColor = true;
            // 
            // btnUPDATE
            // 
            this.btnUPDATE.Location = new System.Drawing.Point(48, 60);
            this.btnUPDATE.Name = "btnUPDATE";
            this.btnUPDATE.Size = new System.Drawing.Size(110, 23);
            this.btnUPDATE.TabIndex = 4;
            this.btnUPDATE.Text = "UPDATE";
            this.btnUPDATE.UseVisualStyleBackColor = true;
            this.btnUPDATE.Click += new System.EventHandler(this.btnUPDATE_Click);
            // 
            // btnREAD
            // 
            this.btnREAD.Location = new System.Drawing.Point(48, 90);
            this.btnREAD.Name = "btnREAD";
            this.btnREAD.Size = new System.Drawing.Size(110, 23);
            this.btnREAD.TabIndex = 5;
            this.btnREAD.Text = "READ";
            this.btnREAD.UseVisualStyleBackColor = true;
            this.btnREAD.Click += new System.EventHandler(this.btnREAD_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(30, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 263);
            this.panel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnREAD);
            this.Controls.Add(this.btnUPDATE);
            this.Controls.Add(this.rbtn4);
            this.Controls.Add(this.rbtn3);
            this.Controls.Add(this.rbtn2);
            this.Controls.Add(this.rbtn1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Panel panel1;
    }
}

