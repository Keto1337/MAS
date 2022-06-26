
namespace MovieHosting
{
    partial class SeriesDetailsEditPage
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
            this.main_panel = new System.Windows.Forms.Panel();
            this.participants_label = new System.Windows.Forms.Label();
            this.genres = new System.Windows.Forms.Label();
            this.release_date = new System.Windows.Forms.Label();
            this.series_desc = new System.Windows.Forms.Label();
            this.series_name = new System.Windows.Forms.Label();
            this.buy_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.series_panel = new System.Windows.Forms.Panel();
            this.topmenu_panel = new System.Windows.Forms.Panel();
            this.films_btn = new System.Windows.Forms.Button();
            this.series_btn = new System.Windows.Forms.Button();
            this.home_btn = new System.Windows.Forms.Button();
            this.main_panel.SuspendLayout();
            this.topmenu_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.BackColor = System.Drawing.Color.Silver;
            this.main_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.main_panel.Controls.Add(this.participants_label);
            this.main_panel.Controls.Add(this.genres);
            this.main_panel.Controls.Add(this.release_date);
            this.main_panel.Controls.Add(this.series_desc);
            this.main_panel.Controls.Add(this.series_name);
            this.main_panel.Controls.Add(this.buy_btn);
            this.main_panel.Controls.Add(this.cancel_btn);
            this.main_panel.Controls.Add(this.series_panel);
            this.main_panel.Controls.Add(this.topmenu_panel);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.MinimumSize = new System.Drawing.Size(1262, 653);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1262, 653);
            this.main_panel.TabIndex = 2;
            this.main_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.main_panel_Paint);
            // 
            // participants_label
            // 
            this.participants_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.participants_label.AutoSize = true;
            this.participants_label.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.participants_label.Location = new System.Drawing.Point(79, 465);
            this.participants_label.Name = "participants_label";
            this.participants_label.Size = new System.Drawing.Size(97, 20);
            this.participants_label.TabIndex = 10;
            this.participants_label.Text = "Participants:";
            // 
            // genres
            // 
            this.genres.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.genres.AutoSize = true;
            this.genres.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.genres.Location = new System.Drawing.Point(1011, 219);
            this.genres.MinimumSize = new System.Drawing.Size(200, 50);
            this.genres.Name = "genres";
            this.genres.Size = new System.Drawing.Size(200, 50);
            this.genres.TabIndex = 9;
            this.genres.Text = "Genres";
            // 
            // release_date
            // 
            this.release_date.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.release_date.AutoSize = true;
            this.release_date.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.release_date.Location = new System.Drawing.Point(1011, 130);
            this.release_date.Name = "release_date";
            this.release_date.Size = new System.Drawing.Size(96, 20);
            this.release_date.TabIndex = 8;
            this.release_date.Text = "Released on";
            // 
            // series_desc
            // 
            this.series_desc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.series_desc.AutoSize = true;
            this.series_desc.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.series_desc.Location = new System.Drawing.Point(322, 195);
            this.series_desc.MaximumSize = new System.Drawing.Size(300, 220);
            this.series_desc.MinimumSize = new System.Drawing.Size(300, 220);
            this.series_desc.Name = "series_desc";
            this.series_desc.Size = new System.Drawing.Size(300, 220);
            this.series_desc.TabIndex = 7;
            this.series_desc.Text = "Description:";
            // 
            // series_name
            // 
            this.series_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.series_name.AutoSize = true;
            this.series_name.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.series_name.Location = new System.Drawing.Point(322, 143);
            this.series_name.Name = "series_name";
            this.series_name.Size = new System.Drawing.Size(52, 20);
            this.series_name.TabIndex = 6;
            this.series_name.Text = "Name";
            // 
            // buy_btn
            // 
            this.buy_btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buy_btn.BackColor = System.Drawing.Color.LawnGreen;
            this.buy_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buy_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buy_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buy_btn.ForeColor = System.Drawing.Color.Black;
            this.buy_btn.Location = new System.Drawing.Point(1105, 385);
            this.buy_btn.Name = "buy_btn";
            this.buy_btn.Size = new System.Drawing.Size(83, 45);
            this.buy_btn.TabIndex = 5;
            this.buy_btn.Text = "$Cost";
            this.buy_btn.UseVisualStyleBackColor = false;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancel_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cancel_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancel_btn.ForeColor = System.Drawing.Color.Black;
            this.cancel_btn.Location = new System.Drawing.Point(613, 82);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(83, 45);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // series_panel
            // 
            this.series_panel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.series_panel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.series_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.series_panel.Location = new System.Drawing.Point(79, 143);
            this.series_panel.Name = "series_panel";
            this.series_panel.Size = new System.Drawing.Size(205, 287);
            this.series_panel.TabIndex = 3;
            // 
            // topmenu_panel
            // 
            this.topmenu_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.topmenu_panel.Controls.Add(this.films_btn);
            this.topmenu_panel.Controls.Add(this.series_btn);
            this.topmenu_panel.Controls.Add(this.home_btn);
            this.topmenu_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topmenu_panel.ForeColor = System.Drawing.Color.Black;
            this.topmenu_panel.Location = new System.Drawing.Point(0, 0);
            this.topmenu_panel.MinimumSize = new System.Drawing.Size(1262, 66);
            this.topmenu_panel.Name = "topmenu_panel";
            this.topmenu_panel.Size = new System.Drawing.Size(1262, 66);
            this.topmenu_panel.TabIndex = 0;
            // 
            // films_btn
            // 
            this.films_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.films_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.films_btn.FlatAppearance.BorderSize = 0;
            this.films_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.films_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.films_btn.ForeColor = System.Drawing.Color.White;
            this.films_btn.Location = new System.Drawing.Point(392, 0);
            this.films_btn.Name = "films_btn";
            this.films_btn.Size = new System.Drawing.Size(104, 66);
            this.films_btn.TabIndex = 2;
            this.films_btn.Text = "Films";
            this.films_btn.UseVisualStyleBackColor = false;
            // 
            // series_btn
            // 
            this.series_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.series_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.series_btn.FlatAppearance.BorderSize = 0;
            this.series_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.series_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.series_btn.ForeColor = System.Drawing.Color.White;
            this.series_btn.Location = new System.Drawing.Point(282, 0);
            this.series_btn.Name = "series_btn";
            this.series_btn.Size = new System.Drawing.Size(104, 66);
            this.series_btn.TabIndex = 1;
            this.series_btn.Text = "Series";
            this.series_btn.UseVisualStyleBackColor = false;
            this.series_btn.Click += new System.EventHandler(this.series_btn_Click);
            // 
            // home_btn
            // 
            this.home_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.home_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.home_btn.FlatAppearance.BorderSize = 0;
            this.home_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.home_btn.ForeColor = System.Drawing.Color.White;
            this.home_btn.Location = new System.Drawing.Point(172, 0);
            this.home_btn.Name = "home_btn";
            this.home_btn.Size = new System.Drawing.Size(104, 66);
            this.home_btn.TabIndex = 0;
            this.home_btn.Text = "Home";
            this.home_btn.UseVisualStyleBackColor = false;
            this.home_btn.Click += new System.EventHandler(this.home_btn_Click);
            // 
            // SeriesDetailsEditPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 653);
            this.Controls.Add(this.main_panel);
            this.Name = "SeriesDetailsEditPage";
            this.Text = "SeriesDetailsEditPage";
            this.Load += new System.EventHandler(this.SeriesDetailsEditPage_Load);
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.topmenu_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Label participants_label;
        private System.Windows.Forms.Label genres;
        private System.Windows.Forms.Label release_date;
        private System.Windows.Forms.Label series_desc;
        private System.Windows.Forms.Label series_name;
        private System.Windows.Forms.Button buy_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Panel series_panel;
        private System.Windows.Forms.Panel topmenu_panel;
        private System.Windows.Forms.Button films_btn;
        private System.Windows.Forms.Button series_btn;
        private System.Windows.Forms.Button home_btn;
    }
}