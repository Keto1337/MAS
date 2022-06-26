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
    public partial class SeriesDetailsEditPage : Form
    {
        private Series series;
        private List<MovieParticipantDto> mp_participants;
        private List<ParticipantFormObject> participantObjects = new();
        private MainPage mainPage;
        private SeriesDetailsPage seriesDetailsPage;
        private SeriesListPage seriesListPage;

        public SeriesDetailsEditPage(SeriesDetailsPage formCaller, MainPage mainPage, SeriesListPage seriesListPage)
        {
            seriesDetailsPage = formCaller;
            this.mainPage = mainPage;
            this.seriesListPage = seriesListPage;
            InitializeComponent();
        }

        public void DownloadSeries(Series series)
        {
            this.series = series;
        }

        public void DownloadParticipants(List<MovieParticipantDto> participants)
        {
            mp_participants = participants;
        }

        public void RemoveParticipant(int idMP)
        {
            DbService.DeleteMovieParticipant(idMP);
            seriesDetailsPage = new(seriesListPage);
            seriesDetailsPage.Location = Location;
            seriesDetailsPage.Size = Size;
            List<MovieParticipantDto> mps = DbService.FetchMovieParticipantsById(series.IdMovie);
            seriesDetailsPage.DownloadSeries(series);
            seriesDetailsPage.DownloadParticipants(mps);
            Close();
            seriesDetailsPage.Show();
        }

        private void SeriesDetailsEditPage_Load(object sender, EventArgs e)
        {
            const int initial_X = 220;
            const int increment_X = 140;
            int Y_loc = participants_label.Location.Y - 5;

            int current_X = initial_X;
            foreach (var mp in mp_participants)
            {
                var po = new ParticipantFormObject(this, mp.IdMovieParticipant, mp.FullName, mp.RoleType.ToString(), current_X, Y_loc, delete_button: true);
                participantObjects.Add(po);
                main_panel.Controls.Add(po);

                current_X += increment_X;
            }
        }

        private void main_panel_Paint(object sender, PaintEventArgs e)
        {
            series_name.Text = series.Name;
            series_desc.Text = series.Description;
            release_date.Text = "Released on " + series.ReleaseDate.ToShortDateString();
            genres.Text = String.Join(", ", series.Genres);
            buy_btn.Text = "$" + series.MovieCost;

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Hide();
            seriesDetailsPage.Show();
            seriesDetailsPage.Location = Location;
            seriesDetailsPage.Size = Size;
        }

        private void series_btn_Click(object sender, EventArgs e)
        {
            Close();
            seriesDetailsPage.Close();
            seriesListPage.Show();
            seriesListPage.Location = Location;
            seriesListPage.Size = Size;
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            Close();
            mainPage.Show();
            mainPage.Location = Location;
            mainPage.Size = Size;
        }
    }
}
