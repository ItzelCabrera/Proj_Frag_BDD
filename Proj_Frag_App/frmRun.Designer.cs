
namespace Proj_Frag_App
{
    partial class frmRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRun));
            this.label1 = new System.Windows.Forms.Label();
            this.btnDist = new System.Windows.Forms.Button();
            this.btnLocal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el tipo de arquitectura";
            // 
            // btnDist
            // 
            this.btnDist.BackgroundImage = global::Proj_Frag_App.Properties.Resources.distrib;
            this.btnDist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDist.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnDist.Location = new System.Drawing.Point(249, 58);
            this.btnDist.Name = "btnDist";
            this.btnDist.Size = new System.Drawing.Size(150, 150);
            this.btnDist.TabIndex = 2;
            this.btnDist.UseVisualStyleBackColor = true;
            this.btnDist.Click += new System.EventHandler(this.btnDist_Click);
            // 
            // btnLocal
            // 
            this.btnLocal.BackgroundImage = global::Proj_Frag_App.Properties.Resources.local;
            this.btnLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocal.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnLocal.Location = new System.Drawing.Point(38, 58);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(150, 150);
            this.btnLocal.TabIndex = 1;
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // frmRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(446, 224);
            this.Controls.Add(this.btnDist);
            this.Controls.Add(this.btnLocal);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "runOption";
            this.Load += new System.EventHandler(this.frmRun_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnDist;
    }
}