
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
            this.label1.Location = new System.Drawing.Point(69, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el tipo de arquitectura";
            // 
            // btnDist
            // 
            this.btnDist.BackgroundImage = global::Proj_Frag_App.Properties.Resources.distrib;
            this.btnDist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDist.Location = new System.Drawing.Point(207, 45);
            this.btnDist.Name = "btnDist";
            this.btnDist.Size = new System.Drawing.Size(110, 111);
            this.btnDist.TabIndex = 2;
            this.btnDist.UseVisualStyleBackColor = true;
            this.btnDist.Click += new System.EventHandler(this.btnDist_Click);
            // 
            // btnLocal
            // 
            this.btnLocal.BackgroundImage = global::Proj_Frag_App.Properties.Resources.local;
            this.btnLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocal.Location = new System.Drawing.Point(39, 45);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(132, 111);
            this.btnLocal.TabIndex = 1;
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // frmRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(371, 165);
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