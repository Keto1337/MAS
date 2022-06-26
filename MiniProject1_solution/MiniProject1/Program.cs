using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*// Movie * - 1 Cast 1 - * Actor 
            Client client1 = new Client("Abc1", "Abc1", ClientType.REGULAR, new Contact("client1@email.com", "+48333333333"));
            Client client2 = new Client("Abc2", "Abc2", ClientType.REGULAR, new Contact("client1@email.com", "+48312333333"), "some desc");
            Client client3 = new Client("Abc3", "Abc3", ClientType.REGULAR, new Contact("client1@email.com", "+48332131212"));
            Client client4 = new Client("Abc4", "Abc4", ClientType.REGULAR, new Contact("client1@email.com", "+48326654333"), "description");
            Client client5 = new Client("Abc5", "Abc5", ClientType.REGULAR, new Contact("client1@email.com", "+48339878973"));

            List<Client> clients = Client.Clients;

            clients.ForEach(c => Console.WriteLine(c));
            clients.Remove(client2);
            // no changes in real collection:
            Console.WriteLine("------no changes in real collection:-------");
            Client.Clients.ForEach(c => Console.WriteLine(c));


            //Serialize Deserialize
            Console.WriteLine("------Serialization Deserialization:------");
            Client.Serialize();
            List<Client> clients_deserialized = Client.Deserialize();
            clients_deserialized.ForEach(c => Console.WriteLine(c));


            Console.WriteLine("-------------------------------");
            Client premium_client1 = new Client("Abc6", "Abc6", ClientType.PREMIUM, new Contact("client1@email.com", "+484444444"));
            Client.Clients.ForEach(c => Console.WriteLine(c));

            // to test error handling:
            // Client error_client1 = new Client("", "dsadas", ClientType.PREMIUM);
            // Client error_client2 = new Client("dsadas", null, ClientType.REGULAR);
            // client3.LastName = "";

            Movie movie1 = new Movie("Spider-Man", new List<string> { "action", "adventure" }, DateTime.Now);
            SeriesEpisode sr1_ep1 = new SeriesEpisode("Beginning");
            SeriesEpisode sr1_ep2 = new SeriesEpisode("Beginning2");
            HashSet<SeriesEpisode> sr1_episodes = new HashSet<SeriesEpisode>();

            // to test error handling:
            // Series series1 = new Series("La casa de Papel", sr1_episodes, new List<String> { "action", "robbery", "drama" }, DateTime.Now);

            sr1_episodes.Add(sr1_ep1);

            // comment this for test above
            Series series1 = new Series("La casa de Papel", sr1_episodes, new List<String> { "action", "robbery", "drama" }, DateTime.Now);

            // to test error handling:
            // series1.AddEpisode(null);

            Console.WriteLine("-------------------------------");
            series1.AddEpisode(sr1_ep2);
            series1.Episodes.ToList().ForEach(e => Console.WriteLine(e));

            Console.WriteLine("-------------------------------");
            Console.WriteLine(Client.GetClientById(3));
            // to test error handling:
            // Console.WriteLine(Client.GetClientById(80));

            Console.WriteLine("-------------------------------");
            series1.Episodes.ToList().ForEach(e => Console.WriteLine(e));
            Console.WriteLine("-------------------------------");
            HashSet<SeriesEpisode> tmp = new HashSet<SeriesEpisode>();
            SeriesEpisode sr1_ep3 = new SeriesEpisode("Beginning3");
            SeriesEpisode sr1_ep4 = new SeriesEpisode("Beginning4");
            tmp.Add(sr1_ep3);
            tmp.Add(sr1_ep4);
            series1.AddEpisode(tmp);
            series1.Episodes.ToList().ForEach(e => Console.WriteLine(e));
            Console.WriteLine("-------------------------------");
            series1.RemoveEpisode(sr1_ep1);
            series1.RemoveEpisode(sr1_ep2);
            series1.Episodes.ToList().ForEach(e => Console.WriteLine(e));


            Console.WriteLine("-------------------------------");
            Console.WriteLine(Client.GetClientById(3));


            *//*// Comment everything else out to test this one
            // #######################  TEST ADDING ALREADY EXISTING EPISODES EXCEPTION HANDLING  #######################
            SeriesEpisode sr10_ep1 = new SeriesEpisode("sr10_ep1");
            SeriesEpisode sr10_ep2 = new SeriesEpisode("sr10_ep2");
            SeriesEpisode sr10_ep3 = new SeriesEpisode("sr10_ep3");
            Series series10 = new Series("Test", sr10_ep1, new List<string> { "test", "test", "test" }, DateTime.Now.AddYears(-10));

            HashSet<SeriesEpisode> sr10_episodes = new HashSet<SeriesEpisode> { sr10_ep1, sr10_ep2, sr10_ep3 };
            series10.AddEpisode(sr10_episodes);*/

            /*SeriesEpisode sr10_ep1 = new SeriesEpisode("sr10_ep1");
            SeriesEpisode sr10_ep2 = new SeriesEpisode("sr10_ep2");
            SeriesEpisode sr10_ep3 = new SeriesEpisode("sr10_ep3");
            Series series10 = new Series("Test", sr10_ep1, new List<string> { "test", "test", "test" }, DateTime.Now.AddYears(-10));

            HashSet<SeriesEpisode> sr10_episodes = new HashSet<SeriesEpisode> { sr10_ep2, sr10_ep3 };

            series10.Episodes.ToList().ForEach(e => Console.WriteLine(e));

            series10.AddEpisode(sr10_episodes);

            series10.Episodes.ToList().ForEach(e => Console.WriteLine(e));*/


            /*Movie movie = new("dsad", new List<string> { "dsadas", "dasdsa" }, DateTime.Now.AddYears(-10));
            Actor actor = new("das", "das");
            Cast cast1 = new(movie, actor, "role", "awaa", 10);

            Console.WriteLine(cast1.Movie);

            var tmp = cast1.Movie;
            tmp.RemoveCast(cast1);

            actor.Movies.ToList().ForEach(m => Console.WriteLine(m));*/

            /*Client client1 = new Client("Abc1", "Abc1", ClientType.REGULAR, new Contact("client1@email.com", "+48333333333"));
            PaymentMethod pm = new PaymentMethod(PaymentType.CARD, "3123211251521");

            client1.AddPaymentMethod(pm);

            foreach (var method in client1.PaymentMethods)
            {
                Console.WriteLine(method.Key + " " + method.Value.MethodId + method.Value.PaymentType);
            }*/

            Series series10 = new Series("La casa de Papel", new List<string> { "action", "robbery", "drama" }, DateTime.Now);
            SeriesEpisode sr10_ep1 = new SeriesEpisode(series10, "s10_ep1");
            SeriesEpisode sr10_ep2 = new SeriesEpisode(series10, "s10_ep2");

            series10.AddEpisode(sr10_ep1);
            series10.AddEpisode(sr10_ep2);

            series10.Episodes.ToList().ForEach(ep => Console.WriteLine(ep));

            series10.DeleteAllEpisodes();
            series10.Episodes.ToList().ForEach(ep => Console.WriteLine(ep));
            Console.WriteLine(SeriesEpisode.Extent.Count);

            /*Series series11 = new Series("La casa de Papel", new List<string> { "action", "robbery", "drama" }, DateTime.Now);

            series11.AddEpisode(sr10_ep1);
            series11.Episodes.ToList().ForEach(ep => Console.WriteLine(ep));*/

        }
    }
}
