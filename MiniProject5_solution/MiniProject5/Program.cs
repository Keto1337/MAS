using MiniProject5.Models;
using System;
using System.Linq;

namespace MiniProject5
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            /*context.Clients.Add(new Client()
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                ClientType = ClientType.REGULAR,
                ContactNavigation = new Contact()
                {
                    Email = "s21121@pjwstk.edu.pl",
                    Phone = "+48333333333",
                }
            });

            context.SaveChanges();*/

            /*var clients = context.Clients.Where(c => c.FirstName.Contains("F"));

            context.Clients.RemoveRange(clients);

            context.SaveChanges();*/

            /*
            select *
            from Movie m
            inner join Series s on m.IdMovie = s.IdMovie
            inner join SeriesEpisode se on s.IdMovie = se.IdSeries
            */

        }
    }
}
