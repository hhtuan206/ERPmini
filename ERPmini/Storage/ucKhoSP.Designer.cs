
namespace ERPmini.Storage
{
    partial class ucKhoSP
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cRVKhoSP = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVKhoSP
            // 
            this.cRVKhoSP.ActiveViewIndex = -1;
            this.cRVKhoSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVKhoSP.Cursor = System.Windows.Forms.Cursors.Default;
            this.cRVKhoSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVKhoSP.Location = new System.Drawing.Point(0, 0);
            this.cRVKhoSP.Name = "cRVKhoSP";
            this.cRVKhoSP.Size = new System.Drawing.Size(1045, 688);
            this.cRVKhoSP.TabIndex = 0;
            // 
            // ucKhoSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cRVKhoSP);
            this.Name = "ucKhoSP";
            this.Size = new System.Drawing.Size(1045, 688);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVKhoSP;
    }
}
