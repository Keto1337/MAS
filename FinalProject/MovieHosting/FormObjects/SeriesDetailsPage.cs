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
    public partial class SeriesDetailsPage : Form
    {
        public Form form_caller;
        public Series series;
        private List<MovieParticipantDto> mp_participants;
        private List<ParticipantFormObject> participantObjects = new();
        private MainPage mainPage;
        private SeriesDetailsEditPage seriesDetailsEditPage;

        public SeriesDetailsPage(Form formCaller)
        {
            InitializeComponent();
            form_caller = formCaller;
            mainPage = (MainPage) ((SeriesListPage)formCaller).form_caller;
            seriesDetailsEditPage = new(this, mainPage, (SeriesListPage) formCaller);
        }

        public void DownloadSeries(Series series)
        {
            this.series = series;
        }

        public void DownloadParticipants(List<MovieParticipantDto> participants)
        {
            mp_participants = participants;
        }

        private void SeriesDetailsPage_Load(object sender, EventArgs e)
        {
            const int initial_X = 220;
            const int increment_X = 140;
            int Y_loc = participants_label.Location.Y - 5;

            int current_X = initial_X;
            foreach (var mp in mp_participants)
            {
                var po = new ParticipantFormObject(this, mp.IdMovieParticipant, mp.FullName, mp.RoleType.ToString(), current_X, Y_loc);
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

            /*main_panel.Controls.Add(po.type);
            main_panel.Controls.Add(po.participant_name);
            main_panel.Controls.Add(po.icon);*/

        }

        private void series_btn_Click(object sender, EventArgs e)
        {
            Close();
            form_caller.Show();
            form_caller.Location = Location;
            form_caller.Size = Size;
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            Close();
            mainPage.Show();
            mainPage.Location = Location;
            mainPage.Size = Size;
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            seriesDetailsEditPage.DownloadSeries(series);
            seriesDetailsEditPage.DownloadParticipants(mp_participants);
            Hide();
            seriesDetailsEditPage.Show();
            seriesDetailsEditPage.Location = Location;
            seriesDetailsEditPage.Size = Size;
        }

        private void icon2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void participant_name2_Click(object sender, EventArgs e)
        {

        }

        private void type2_Click(object sender, EventArgs e)
        {

        }

        private void genres_Click(object sender, EventArgs e)
        {

        }
    }
}
