using MovieHosting.DTO;
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
    public partial class SeriesListPage : Form
    {
        public Form form_caller { get; set; }
        private List<Series> series;
        public SeriesListPage(Form formCaller)
        {
            InitializeComponent();
            form_caller = formCaller;
            Hide();
        }

        public void DownloadSeries(List<Series> series)
        {
            this.series = series;
        }

        private void main_panel_Paint(object sender, PaintEventArgs e)
        {
            series_name1.Text = series[0].Name;
            buy_btn1.Text = "$" + series[0].MovieCost;

            series_name2.Text = series[1].Name;
            buy_btn2.Text = "$" + series[1].MovieCost;
        }

        private void home_btn_Click(object sender, EventArgs e)
        {           
            Close();
            form_caller.Show();
            form_caller.Location = Location;
            form_caller.Size = Size;
        }

        private void directToDetails(int idSeries)
        {
            SeriesDetailsPage seriesDetailsPage = new(this);
            Series series = DbService.FetchSeriesById(idSeries);
            List<MovieParticipantDto> mps = DbService.FetchMovieParticipantsById(idSeries);
            seriesDetailsPage.DownloadSeries(series);
            seriesDetailsPage.DownloadParticipants(mps);
            Hide();
            seriesDetailsPage.Show();
            seriesDetailsPage.Location = Location;
            seriesDetailsPage.Size = Size;
        }

        private void details_btn1_Click(object sender, EventArgs e)
        {
            directToDetails(1);
        }

        private void details_btn2_Click(object sender, EventArgs e)
        {
            directToDetails(3);
        }

        private void SeriesPage_Load(object sender, EventArgs e)
        {

        }

        private void series_btn_Click(object sender, EventArgs e)
        {

        }

        private void films_btn_Click(object sender, EventArgs e)
        {

        }

        private void series1_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buy_btn1_Click(object sender, EventArgs e)
        {

        }

        private void series_name1_Click(object sender, EventArgs e)
        {

        }

        private void series_name2_Click(object sender, EventArgs e)
        {

        }

        private void buy_btn2_Click(object sender, EventArgs e)
        {

        }

        private void series2_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void topmenu_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
