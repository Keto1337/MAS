using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5.Models
{
    class Context : DbContext
    {
        public virtual DbSet<FeatureFilm> FeatureFilms { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientMovie> ClientMovies { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Series> Seriess { get; set; }
        public virtual DbSet<SeriesEpisode> SeriesEpisodes { get; set; }

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
                    .UseSqlServer(@"Data Source=(localdb)\Local;Initial Catalog=mas_mp5;Integrated Security=True")
                    .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Client
            var client1 = new Client()
            {
                IdClient = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                ClientType = ClientType.REGULAR
            };

            var client2 = new Client()
            {
                IdClient = 2,
                FirstName = "FirstName2",
                LastName = "LastName2",
                ClientType = ClientType.REGULAR
            };

            var client3 = new Client()
            {
                IdClient = 3,
                FirstName = "FirstName3",
                LastName = "LastName3",
                ClientType = ClientType.REGULAR
            };

            // Client
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable(nameof(Client));

                entity.HasKey(e => e.IdClient);
                entity.Property(e => e.IdClient).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Bio).HasMaxLength(300);
                entity.Property(e => e.ClientType).IsRequired();

                entity.HasData(client1, client2, client3);
            });

            // Contact
            var contact1 = new Contact()
            {
                IdContact = 1,
                Email = "s21120@pjwstk.edu.pl",
                Phone = "+48333333333",
                IdClient = client1.IdClient
            };

            var contact2 = new Contact()
            {
                IdContact = 2,
                Email = "s21121@pjwstk.edu.pl",
                Phone = "+48334433333",
                IdClient = client2.IdClient
            };

            var contact3 = new Contact()
            {
                IdContact = 3,
                Email = "s21122@pjwstk.edu.pl",
                Phone = "+48335533333",
                IdClient = client3.IdClient
            };

            var contact4 = new Contact()
            {
                IdContact = 4,
                Email = "s21123@pjwstk.edu.pl",
                Phone = "+48222333333",
                IdClient = client3.IdClient
            };


            // Contact
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable(nameof(Contact));

                entity.HasKey(e => e.IdContact);
                entity.Property(e => e.IdContact).ValueGeneratedOnAdd();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Phone).IsRequired();

                entity.HasOne(e => e.ClientNavigation)
                    .WithMany(cl => cl.ContactNavigation)
                    .HasForeignKey(e => e.IdClient)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(contact1, contact2, contact3);
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
                entity.Property(e => e.ReleaseDate).IsRequired().HasColumnType("datetime");

            });

            // Movie
            var movie1 = new Series()
            {
                IdMovie = 1,
                Name = "Series1",
                Description = "Description1",
                MovieCost = 50,
                ReleaseDate = DateTime.Now.AddYears(-5)
            };

            var movie2 = new Series()
            {
                IdMovie = 2,
                Name = "Series2",
                Description = "Description2",
                MovieCost = 50,
                ReleaseDate = DateTime.Now.AddYears(-3)
            };

            var movie3 = new FeatureFilm()
            {
                IdMovie = 3,
                Name = "Film3",
                Description = "Description3",
                MovieCost = 60,
                ReleaseDate = DateTime.Now.AddYears(-7),
                DurationInMins = 120
            };

            // Series
            modelBuilder.Entity<Series>(entity =>
            {
                entity.ToTable(nameof(Series));

                entity.HasData(movie1, movie2);
            });

            // FeatureFilm
            modelBuilder.Entity<FeatureFilm>(entity =>
            {
                entity.ToTable(nameof(FeatureFilm));

                entity.Property(e => e.DurationInMins).IsRequired();

                entity.HasData(movie3);
            });

            // SeriesEpisode
            var sr1_episode1 = new SeriesEpisode()
            {
                IdSeriesEpisode = 1,
                Name = "sr1ep1",
                Description = "desc",
                IdSeries = movie1.IdMovie
            };

            var sr1_episode2 = new SeriesEpisode()
            {
                IdSeriesEpisode = 2,
                Name = "sr1ep2",
                Description = "desc",
                IdSeries = movie1.IdMovie
            };

            var sr2_episode1 = new SeriesEpisode()
            {
                IdSeriesEpisode = 3,
                Name = "sr2ep1",
                Description = "desc",
                IdSeries = movie2.IdMovie
            };

            var sr2_episode2 = new SeriesEpisode()
            {
                IdSeriesEpisode = 4,
                Name = "sr2ep2",
                Description = "desc",
                IdSeries = movie2.IdMovie
            };

            // SeriesEpisode
            modelBuilder.Entity<SeriesEpisode>(entity =>
            {
                entity.ToTable(nameof(SeriesEpisode));

                entity.HasKey(e => e.IdSeriesEpisode);
                entity.Property(e => e.IdSeriesEpisode).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(300);

                entity.HasOne(e => e.SeriesNavigation)
                    .WithMany(e => e.Episodes)
                    .HasForeignKey(e => e.IdSeries);

                entity.HasData(sr1_episode1, sr1_episode2, sr2_episode1, sr2_episode2);
            });


            // ClientMovie
            var clientmovie1 = new ClientMovie()
            {
                IdClient = client1.IdClient,
                IdMovie = movie1.IdMovie
            };

            var clientmovie2 = new ClientMovie()
            {
                IdClient = client2.IdClient,
                IdMovie = movie2.IdMovie
            };

            var clientmovie3 = new ClientMovie()
            {
                IdClient = client3.IdClient,
                IdMovie = movie3.IdMovie
            };

            // ClientMovie
            modelBuilder.Entity<ClientMovie>(entity =>
            {
                entity.ToTable(nameof(ClientMovie));

                entity.HasKey(e => new { e.IdClient, e.IdMovie })
                    .HasName("Client_Movie_PK");

                entity.HasOne(e => e.ClientNavigation)
                    .WithMany(e => e.ClientMovies)
                    .HasForeignKey(e => e.IdClient);

                entity.HasOne(e => e.MovieNavigation)
                    .WithMany(e => e.ClientMovies)
                    .HasForeignKey(e => e.IdMovie);

                entity.HasData(clientmovie1, clientmovie2, clientmovie3);
            });
        }
    }
}
