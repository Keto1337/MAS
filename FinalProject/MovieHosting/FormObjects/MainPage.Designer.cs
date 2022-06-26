namespace MovieHosting
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.main_panel = new System.Windows.Forms.Panel();
            this.Watch = new System.Windows.Forms.Button();
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
            this.main_panel.BackgroundImage = global::MovieHosting.Properties.Resources.main_screen_img2;
            this.main_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.main_panel.Controls.Add(this.Watch);
            this.main_panel.Controls.Add(this.topmenu_panel);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.MinimumSize = new System.Drawing.Size(1262, 653);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1262, 653);
            this.main_panel.TabIndex = 0;
            this.main_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.main_panel_Paint);
            // 
            // Watch
            // 
            this.Watch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Watch.AutoSize = true;
            this.Watch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Watch.BackColor = System.Drawing.Color.White;
            this.Watch.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Watch.Location = new System.Drawing.Point(149, 491);
            this.Watch.MaximumSize = new System.Drawing.Size(250, 100);
            this.Watch.MinimumSize = new System.Drawing.Size(153, 65);
            this.Watch.Name = "Watch";
            this.Watch.Size = new System.Drawing.Size(153, 65);
            this.Watch.TabIndex = 1;
            this.Watch.Text = "Watch";
            this.Watch.UseVisualStyleBackColor = false;
            this.Watch.Click += new System.EventHandler(this.button1_Click);
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
            this.topmenu_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.topmenu_panel_Paint);
            // 
            // films_btn
            // 
            this.films_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.films_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.films_btn.FlatAppearance.BorderSize = 0;
            this.films_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.films_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.films_btn.ForeColor = System.Drawing.Color.White;
            this.films_btn.Location = new System.Drawing.Point(390, 0);
            this.films_btn.Name = "films_btn";
            this.films_btn.Size = new System.Drawing.Size(104, 66);
            this.films_btn.TabIndex = 2;
            this.films_btn.Text = "Films";
            this.films_btn.UseVisualStyleBackColor = false;
            this.films_btn.Click += new System.EventHandler(this.films_btn_Click);
            // 
            // series_btn
            // 
            this.series_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.series_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.series_btn.FlatAppearance.BorderSize = 0;
            this.series_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.series_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.series_btn.ForeColor = System.Drawing.Color.White;
            this.series_btn.Location = new System.Drawing.Point(280, 0);
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
            this.home_btn.Location = new System.Drawing.Point(170, 0);
            this.home_btn.Name = "home_btn";
            this.home_btn.Size = new System.Drawing.Size(104, 66);
            this.home_btn.TabIndex = 0;
            this.home_btn.Text = "Home";
            this.home_btn.UseVisualStyleBackColor = false;
            this.home_btn.Click += new System.EventHandler(this.home_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 653);
            this.Controls.Add(this.main_panel);
            this.MinimumSize = new System.Drawing.Size(1280, 700);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.topmenu_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Panel topmenu_panel;
        private System.Windows.Forms.Button Watch;
        private System.Windows.Forms.Button home_btn;
        private System.Windows.Forms.Button series_btn;
        private System.Windows.Forms.Button films_btn;
    }
}

