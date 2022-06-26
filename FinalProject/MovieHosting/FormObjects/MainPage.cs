using MovieHosting.Models;
using MovieHosting.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieHosting
{
    public partial class MainPage : Form
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void topmenu_panel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void main_panel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void home_btn_Click(object sender, EventArgs e)
        {

        }

        private void series_btn_Click(object sender, EventArgs e)
        {
            SeriesListPage seriesListPage = new(this);
            List<Series> series = DbService.FetchSeries();
            seriesListPage.DownloadSeries(series);
            Hide();
            seriesListPage.Show();
            seriesListPage.Location = Location;
            seriesListPage.Size = Size;
        }

        private void films_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
