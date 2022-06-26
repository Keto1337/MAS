using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using MovieHosting.Enums;
using System;
using System.Collections.Generic;

namespace MovieHosting.Models
{
    public class Context : DbContext
    {
        public virtual DbSet<FeatureFilm> FeatureFilms { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<ClientMovie> ClientMovies { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Series> Seriess { get; set; }
        public virtual DbSet<SeriesEpisode> SeriesEpisodes { get; set; }
        public virtual DbSet<SeriesSeason> SeriesSeasons { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<MovieOfWeek> MovieOfWeeks { get; set; }
        public virtual DbSet<AdminMovie> AdminMovies { get; set; }
        public virtual DbSet<MovieParticipant> MovieParticipants { get; set; }

        public Context()
        {
        }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder
                    .UseSqlServer(@"Data Source=(localdb)\Local;Initial Catalog=MovieHosting;Integrated Security=True")
                    .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Person
            var client1 = new Person()
            {
                IdPerson = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                PersonType = new() { PersonType.Client }
            };

            var client2 = new Person()
            {
                IdPerson = 2,
                FirstName = "FirstName2",
                LastName = "LastName2",
                PersonType = new() { PersonType.Client }
            };

            var participant3 = new Person()
            {
                IdPerson = 3,
                FirstName = "Illia",
                LastName = "Zviezdin",
                PersonType = new() { PersonType.Participant }
            };

            var participant4 = new Person()
            {
                IdPerson = 4,
                FirstName = "Emil",
                LastName = "Wcislo",
                PersonType = new() { PersonType.Participant }
            };

            var admin5 = new Person()
            {
                IdPerson = 5,
                FirstName = "FirstName5",
                LastName = "LastName5",
                PersonType = new() { PersonType.Admin }
            };

            // Person
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable(nameof(MovieParticipants));

                entity.HasKey(e => e.IdPerson);
                entity.Property(e => e.IdPerson).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Bio).HasMaxLength(500);
                entity.Property(e => e.PersonType).HasConversion(new ValueConverter<HashSet<PersonType>, string>
                    (
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<HashSet<PersonType>>(v)
                    ));

                entity.HasOne(e => e.ContactNavigation)
                    .WithOne(cl => cl.ClientNavigation)
                    .HasForeignKey<Contact>(e => e.IdClient)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(client1, client2, participant3, participant4, admin5);
            });

            // Contact
            var contact1 = new Contact()
            {
                IdContact = 1,
                Email = "s21120@pjwstk.edu.pl",
                Phone = "+48333333333",
                IdClient = client1.IdPerson
            };

            var contact2 = new Contact()
            {
                IdContact = 2,
                Email = "s21121@pjwstk.edu.pl",
                Phone = "+48334433333",
                IdClient = client2.IdPerson
            };

            var contact3 = new Contact()
            {
                IdContact = 3,
                Email = "s21122@pjwstk.edu.pl",
                Phone = "+48335533333",
                IdClient = participant3.IdPerson
            };

            var contact4 = new Contact()
            {
                IdContact = 4,
                Email = "s21123@pjwstk.edu.pl",
                Phone = "+48222333333",
                IdClient = participant4.IdPerson
            };


            // Contact
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable(nameof(Contact));

                entity.HasKey(e => e.IdContact);
                entity.Property(e => e.IdContact).ValueGeneratedOnAdd();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Phone).IsRequired();

                entity.HasData(contact1, contact2, contact3);
            });

            // PaymentMethod
            var paymentMethod1 = new PaymentMethod()
            {
                IdPaymentMethod = 1,
                PaymentType = PaymentType.CARD,
                ReferenceNumber = "32131221321312",
                IdClient = 1
            };

            var paymentMethod2 = new PaymentMethod()
            {
                IdPaymentMethod = 2,
                PaymentType = PaymentType.BANK_ACCOUNT,
                ReferenceNumber = "PL231123213",
                IdClient = 1
            };


            // PaymentMethod
            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable(nameof(PaymentMethod));

                entity.HasKey(e => e.IdPaymentMethod);
                entity.Property(e => e.IdPaymentMethod).ValueGeneratedOnAdd();
                entity.Property(e => e.PaymentType).IsRequired();
                entity.Property(e => e.ReferenceNumber).IsRequired().HasMaxLength(16);

                entity.HasOne(e => e.ClientNavigation)
                    .WithMany(e => e.PaymentMethods)
                    .HasForeignKey(e => e.IdClient);

                entity.HasData(paymentMethod1, paymentMethod2);
            });

            // Movie
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable(nameof(Movie));

                entity.HasKey(e => e.IdMovie);
                entity.Property(e => e.IdMovie).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(300);
                entity.Property(e => e.MovieCost).IsRequired();
                entity.Property(e => e.ReleaseDate).IsRequired();
                entity.Property(e => e.Genres).HasConversion(new ValueConverter<HashSet<string>, string>
                    (
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<HashSet<string>>(v)
                    ));

                entity.HasOne(e => e.MovieOfWeekNavigation)
                    .WithOne(e => e.MovieNavigation)
                    .HasForeignKey<MovieOfWeek>(e => e.IdMovie)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Movie
            var movie1 = new Series()
            {
                IdMovie = 1,
                Name = "Breaking Bad",
                Description = "A high school teacher with terminal cancer, along with his former student, manufactures and sells methamphetamine in order to secure a prosperous future for his family.",
                MovieCost = 5.99,
                ReleaseDate = DateTime.Now.AddYears(-9),
                Genres = new () { "Crime TV series", "Drama TV series", "Thriller", "Cruel"}
            };

            var movie2 = new FeatureFilm()
            {
                IdMovie = 2,
                Name = "Film_Name2",
                Description = "Description2Description2 Description2 Description2Description2Description2 Description2 Description2Description2Description2 Description2Description2",
                MovieCost = 5.99,
                ReleaseDate = DateTime.Now.AddYears(-7),
                DurationInMins = 120,
                Genres = new() { "Thriller", "Action" }
            };

            var movie3 = new Series()
            {
                IdMovie = 3,
                Name = "Peaky Blinders",
                Description = "The infamous gang is led by the brutal Tommy Shelby, the leader of a crime family determined to achieve new heights at any cost.",
                MovieCost = 6.99,
                ReleaseDate = DateTime.Now.AddYears(-5),
                Genres = new() { "Crime TV series", "Historical films" }
            };

            // Series
            modelBuilder.Entity<Series>(entity =>
            {
                entity.ToTable(nameof(Series));

                entity.HasData(movie1, movie3);
            });

            // FeatureFilm
            modelBuilder.Entity<FeatureFilm>(entity =>
            {
                entity.ToTable(nameof(FeatureFilm));

                entity.Property(e => e.DurationInMins).IsRequired();

                entity.HasData(movie2);
            });

            // MovieOfTheWeek
            var motw1 = new MovieOfWeek()
            {
                IdMovieOfWeek = 1,
                StartDate = DateTime.Now.AddDays(-5),
                IdMovie = movie1.IdMovie
            };

            modelBuilder.Entity<MovieOfWeek>(entity =>
            {
                entity.ToTable(nameof(MovieOfWeek));

                entity.HasKey(e => e.IdMovieOfWeek);
                entity.Property(e => e.IdMovieOfWeek).ValueGeneratedOnAdd();
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.IdMovie).IsRequired();

                entity.HasData(motw1);
            });

            // SeriesSeason
            var sr1_s1 = new SeriesSeason()
            {
                IdSeriesSeason = 1,
                Name = "sr1s1",
                Description = "desc",
                SeasonNumber = 1,
                IdSeries = movie1.IdMovie
            };

            var sr1_s2 = new SeriesSeason()
            {
                IdSeriesSeason = 2,
                Name = "sr1s2",
                Description = "desc",
                SeasonNumber = 2,
                IdSeries = movie1.IdMovie
            };

            var sr3_s1 = new SeriesSeason()
            {
                IdSeriesSeason = 1,
                Name = "sr3s1",
                Description = "desc",
                SeasonNumber = 1,
                IdSeries = movie3.IdMovie
            };

            var sr3_s2 = new SeriesSeason()
            {
                IdSeriesSeason = 2,
                Name = "sr3s2",
                Description = "desc",
                SeasonNumber = 2,
                IdSeries = movie3.IdMovie
            };

            // SeriesSeason
            modelBuilder.Entity<SeriesSeason>(entity =>
            {
                entity.ToTable(nameof(SeriesSeason));

                entity.HasKey(e => e.IdSeriesSeason);
                entity.Property(e => e.IdSeriesSeason).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(300);
                entity.Property(e => e.SeasonNumber).IsRequired();

                entity.HasOne(e => e.SeriesNavigation)
                    .WithMany(e => e.Seasones)
                    .HasForeignKey(e => e.IdSeries);

                entity.HasData(sr1_s1, sr1_s2);
            });

            // SeriesEpisode
            var sr1_s1_ep1 = new SeriesEpisode()
            {
                IdSeriesEpisode = 1,
                Name = "sr1s1ep1",
                Description = "desc",
                EpisodeNumber = 1,
                IdSeason = sr1_s1.IdSeriesSeason,
            };

            var sr1_s1_ep2 = new SeriesEpisode()
            {
                IdSeriesEpisode = 2,
                Name = "sr1s1ep2",
                Description = "desc",
                EpisodeNumber = 2,
                IdSeason = sr1_s1.IdSeriesSeason,
            };

            var sr1_s2_ep1 = new SeriesEpisode()
            {
                IdSeriesEpisode = 3,
                Name = "sr1s2ep1",
                Description = "desc",
                EpisodeNumber = 1,
                IdSeason = sr1_s2.IdSeriesSeason,
            };

            var sr1_s2_ep2 = new SeriesEpisode()
            {
                IdSeriesEpisode = 4,
                Name = "sr1s2ep2",
                Description = "desc",
                EpisodeNumber = 2,
                IdSeason = sr1_s2.IdSeriesSeason,
            };

            var sr3_s1_ep1 = new SeriesEpisode()
            {
                IdSeriesEpisode = 5,
                Name = "sr3s1ep1",
                Description = "desc",
                EpisodeNumber = 1,
                IdSeason = sr3_s1.IdSeriesSeason,
            };

            var sr3_s1_ep2 = new SeriesEpisode()
            {
                IdSeriesEpisode = 6,
                Name = "sr3s1ep2",
                Description = "desc",
                EpisodeNumber = 2,
                IdSeason = sr3_s1.IdSeriesSeason,
            };

            var sr3_s2_ep1 = new SeriesEpisode()
            {
                IdSeriesEpisode = 7,
                Name = "sr3s2ep1",
                Description = "desc",
                EpisodeNumber = 1,
                IdSeason = sr3_s2.IdSeriesSeason,
            };

            var sr3_s2_ep2 = new SeriesEpisode()
            {
                IdSeriesEpisode = 8,
                Name = "sr3s2ep2",
                Description = "desc",
                EpisodeNumber = 2,
                IdSeason = sr3_s2.IdSeriesSeason,
            };

            // SeriesEpisode
            modelBuilder.Entity<SeriesEpisode>(entity =>
            {
                entity.ToTable(nameof(SeriesEpisode));

                entity.HasKey(e => e.IdSeriesEpisode);
                entity.Property(e => e.IdSeriesEpisode).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(300);
                entity.Property(e => e.EpisodeNumber).IsRequired();

                entity.HasOne(e => e.SeasonNavigation)
                    .WithMany(e => e.Episodes)
                    .HasForeignKey(e => e.IdSeason);

                entity.HasData(sr1_s1_ep1, sr1_s1_ep2, sr1_s2_ep1, sr1_s2_ep2, sr3_s1_ep1, sr3_s1_ep2, sr3_s2_ep1, sr3_s2_ep2);
            });


            // ClientMovie
            var clientmovie1 = new ClientMovie()
            {
                IdClient = client1.IdPerson,
                IdMovie = movie1.IdMovie
            };

            var clientmovie2 = new ClientMovie()
            {
                IdClient = client1.IdPerson,
                IdMovie = movie2.IdMovie
            };

            // ClientMovie
            modelBuilder.Entity<ClientMovie>(entity =>
            {
                entity.ToTable(nameof(ClientMovie));

                entity.HasKey(e => new { e.IdClient, e.IdMovie })
                    .HasName("Client_Movie_PK");

                entity.Property(e => e.PurchaseDate).IsRequired();

                entity.HasOne(e => e.ClientNavigation)
                    .WithMany(e => e.ClientMovies)
                    .HasForeignKey(e => e.IdClient);

                entity.HasOne(e => e.MovieNavigation)
                    .WithMany(e => e.ClientMovies)
                    .HasForeignKey(e => e.IdMovie);

                entity.HasData(clientmovie1, clientmovie2);
            });

            // MovieParticipant
            var mp1 = new MovieParticipant()
            {
                IdMovieParticipant = 1,
                IdParticipant = participant3.IdPerson,
                IdMovie = movie1.IdMovie,
                MovieAward = "some",
                MoviePayment = 500000,
                RoleType = RoleType.Actor
            };

            var mp2 = new MovieParticipant()
            {
                IdMovieParticipant = 2,
                IdParticipant = participant4.IdPerson,
                IdMovie = movie1.IdMovie,
                MovieAward = "some",
                MoviePayment = 300000,
                RoleType = RoleType.Actor
            };

            var mp1_1 = new MovieParticipant()
            {
                IdMovieParticipant = 3,
                IdParticipant = participant3.IdPerson,
                IdMovie = movie1.IdMovie,
                MovieAward = "some",
                MoviePayment = 300000,
                RoleType = RoleType.Producer
            };

            var mp3 = new MovieParticipant()
            {
                IdMovieParticipant = 4,
                IdParticipant = participant4.IdPerson,
                IdMovie = movie3.IdMovie,
                MovieAward = "some",
                MoviePayment = 500000,
                RoleType = RoleType.Actor
            };

            var mp4 = new MovieParticipant()
            {
                IdMovieParticipant = 5,
                IdParticipant = participant3.IdPerson,
                IdMovie = movie3.IdMovie,
                MovieAward = "some",
                MoviePayment = 300000,
                RoleType = RoleType.Actor
            };

            var mp3_1 = new MovieParticipant()
            {
                IdMovieParticipant = 6,
                IdParticipant = participant4.IdPerson,
                IdMovie = movie3.IdMovie,
                MovieAward = "some",
                MoviePayment = 300000,
                RoleType = RoleType.Director
            };

            // MovieParticipant
            modelBuilder.Entity<MovieParticipant>(entity =>
            {
                entity.ToTable(nameof(MovieParticipant));

                entity.HasKey(e => e.IdMovieParticipant);

                entity.Property(e => e.IdMovieParticipant).ValueGeneratedOnAdd();
                entity.Property(e => e.MovieAward).IsRequired().HasMaxLength(50);

                entity.HasOne(e => e.ParticipantNavigation)
                    .WithMany(e => e.MovieParticipants)
                    .HasForeignKey(e => e.IdParticipant);

                entity.HasOne(e => e.MovieNavigation)
                    .WithMany(e => e.MovieParticipants)
                    .HasForeignKey(e => e.IdMovie);

                entity.HasData(mp1, mp2, mp1_1, mp3, mp4, mp3_1);
            });

            // AdminMovie

            var admin_movie1 = new AdminMovie()
            {
                IdAdmin = admin5.IdPerson,
                IdMovie = movie1.IdMovie
                //, AccessDate = DateTime.Now
            };

            var admin_movie2 = new AdminMovie()
            {
                IdAdmin = admin5.IdPerson,
                IdMovie = movie2.IdMovie
            };

            var admin_movie3 = new AdminMovie()
            {
                IdAdmin = admin5.IdPerson,
                IdMovie = movie3.IdMovie
            };

            // AdminMovie
            modelBuilder.Entity<AdminMovie>(entity =>
            {
                entity.ToTable(nameof(AdminMovie));

                entity.HasKey(e => new { e.IdAdmin, e.IdMovie })
                    .HasName("Admin_Movie_PK");

                entity.HasOne(e => e.AdminNavigation)
                    .WithMany(e => e.AdminMovies)
                    .HasForeignKey(e => e.IdAdmin);

                entity.HasOne(e => e.MovieNavigation)
                    .WithMany(e => e.AdminMovies)
                    .HasForeignKey(e => e.IdMovie);

                entity.HasData(admin_movie1, admin_movie2, admin_movie3);
            });

        }
    }
}
