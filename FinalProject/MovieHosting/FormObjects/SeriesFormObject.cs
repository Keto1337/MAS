using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieHosting.FormObjects
{
    class SeriesFormObject : Panel
    {
        public Label series_name;
        public Button buy_btn;
        public Button details_btn;
        public Panel series_panel;

        public SeriesFormObject(int X_loc, int Y_loc)
        {
            this.SuspendLayout();
            this.BackColor = System.Drawing.Color.Silver;
            this.Location = new System.Drawing.Point(X_loc, Y_loc);
            this.MinimumSize = new System.Drawing.Size(97, 150);
            this.Size = new System.Drawing.Size(97, 150);
            this.Anchor = AnchorStyles.Left;


            series_name = new Label();
            buy_btn = new Button();
            details_btn = new Button();
            series_panel = new Panel();


            // 
            // series_name
            series_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            series_name.AutoSize = true;
            series_name.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            series_name.Location = new System.Drawing.Point(79, 433);
            series_name.MinimumSize = new System.Drawing.Size(200, 50);
            series_name.Name = "series_name1";
            series_name.Padding = new System.Windows.Forms.Padding(40, 20, 40, 20);
            series_name.Size = new System.Drawing.Size(200, 62);
            series_name.Text = "Name";
            // 
            // buy_btn
            buy_btn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            buy_btn.BackColor = System.Drawing.Color.LawnGreen;
            buy_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            buy_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buy_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buy_btn.ForeColor = System.Drawing.Color.Black;
            buy_btn.Location = new System.Drawing.Point(201, 508);
            buy_btn.Name = "buy_btn";
            buy_btn.Size = new System.Drawing.Size(83, 45);
            buy_btn.Text = "$Cost";
            buy_btn.UseVisualStyleBackColor = false;
            buy_btn.Click += new System.EventHandler(this.buy_btn_Click);
            // 
            // details_btn
            details_btn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            details_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            details_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            details_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            details_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            details_btn.ForeColor = System.Drawing.Color.Black;
            details_btn.Location = new System.Drawing.Point(79, 508);
            details_btn.Name = "details_btn";
            details_btn.Size = new System.Drawing.Size(83, 45);
            details_btn.Text = "Details";
            details_btn.UseVisualStyleBackColor = false;
            details_btn.Click += new System.EventHandler(this.details_btn_Click);
            // 
            // series_panel
            series_panel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            series_panel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            series_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            series_panel.Location = new System.Drawing.Point(79, 143);
            series_panel.Name = "series1_panel";
            series_panel.Size = new System.Drawing.Size(205, 287);
        }
    }
}
