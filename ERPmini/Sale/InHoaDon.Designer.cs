
namespace ERPmini.Sale
{
    partial class InHoaDon
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
            this.cRVInHoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVInHoaDon
            // 
            this.cRVInHoaDon.ActiveViewIndex = -1;
            this.cRVInHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cRVInHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVInHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.cRVInHoaDon.Location = new System.Drawing.Point(3, 4);
            this.cRVInHoaDon.Name = "cRVInHoaDon";
            this.cRVInHoaDon.Size = new System.Drawing.Size(795, 444);
            this.cRVInHoaDon.TabIndex = 0;
            // 
            // InHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cRVInHoaDon);
            this.Name = "InHoaDon";
            this.Text = "InHoaDon";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVInHoaDon;
    }
}