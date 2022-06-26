using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace MiniProject1
{
    [Serializable]
    class Client
    {
        private static readonly string path = "resources/client_persistence.txt";

        private static int id_counter = 1;
        private readonly int client_id;
        private string first_name;
        private string last_name;
        private string bio;
        private ClientType clientType;
        private List<ClientMovie> movies = new List<ClientMovie>();
        private Contact contact;
        private Dictionary<int, PaymentMethod> payment_methods = new Dictionary<int, PaymentMethod>();
        private static List<Client> clients = new List<Client>();

        [Required]
        [Key]
        public int Client_id { get { return client_id; } }

        [Required]
        public ClientType ClientType { get { return clientType; } set { clientType = value; } }

        [Required]
        public string FirstName { 
            get { return first_name; } 
            set 
            {
                if (value == null || value.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field first name is mandatory!");
                else first_name = value; 
            }
        }

        [Required]
        public string LastName { 
            get { return last_name; }
            set
            {
                if (value == null || value.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field last name is mandatory!");
                else last_name = value;
            }
        }

        public string Bio { 
            get { return bio; } 
            set 
            {
                if (value is not null)
                    if (value.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. String argument can't be empty");
                    
                bio = value;
            } 
        }

        public List<ClientMovie> Movies { get { return new List<ClientMovie>(movies); } }

        public Contact Contact {
            get { return contact; }
            set 
            {
                if (value == null) throw new ArgumentNullException("Null field specified. Field contact is mandatory!");
                else contact = value;
            }
        }

        public Dictionary<int, PaymentMethod> PaymentMethods { get { return new Dictionary<int, PaymentMethod>(payment_methods); } }

        public static List<Client> Clients { get { return new List<Client>(clients); } }


        // constructor
        public Client(string first_name, string last_name, ClientType clientType, Contact contact, string bio = null)
        {
            if (first_name == null || first_name.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field first name is mandatory!");
            if (last_name == null || last_name.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field last name is mandatory!");
            if (bio is not null)
                if (bio.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. String argument can't be empty");
            if (contact == null) throw new ArgumentNullException("Null field specified. Field contact is mandatory!");

            client_id = id_counter;
            id_counter++;

            this.first_name = first_name;
            this.last_name = last_name;
            this.clientType = clientType;
            this.contact = contact;
            this.bio = bio;
            
            clients.Add(this);
        }

        // constructor
        public Client(string first_name, string last_name, ClientType clientType, Contact contact) : this (first_name, last_name, clientType, contact, null) { }

        /*public static void RemoveClient()
        {

        }*/

        public void AddPaymentMethod(PaymentMethod payment_method)
        {
            int pm_id = payment_method.MethodId;
            if (payment_method == null) throw new ArgumentNullException("Null value received! PaymentMethod can not be null");
            if (payment_methods.Any(pm => pm.Key == pm_id)) return; // throw new ArgumentException("There is the same episode already in the set.");

            payment_methods.Add(pm_id, payment_method);
            payment_method.Client = this;
        }

        public void RemovePaymentMethod(PaymentMethod payment_method)
        {
            int pm_id = payment_method.MethodId;
            if (payment_method == null) throw new ArgumentNullException("Null value received! Episode can not be null");
            if (!payment_methods.Any(pm => pm.Key == pm_id)) return;

            payment_methods.Remove(pm_id);
            payment_method.Client = null;
        }

        public void AddMovie(ClientMovie movie)
        {
            if (movie is null) throw new ArgumentNullException("Movie can not be null!");
            if (movie.Client != this) throw new ArgumentException("This movie is not for this client!");
            movies.Add(movie);
        }

        public void RemoveMovie(ClientMovie movie)
        {
            if (movie is null) throw new ArgumentNullException("Movie can not be null!");
            if (!movies.Contains(movie)) return;
            movies.Remove(movie);
            movie.RemovePair();
        }

        public static void Serialize()
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fs, clients);
                    };
                }
                else
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fs, clients);
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<Client> Deserialize()
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    UpdateClients((List<Client>)formatter.Deserialize(fs));
                    return new List<Client>(clients);
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public static Client GetClientById(int id)
        {
            if (id < 0) throw new ArgumentException("Id cannot be less than 0.");

            Client client = clients.Where(c => c.client_id == id).FirstOrDefault();
            if (client == null) throw new ArgumentNullException("Client with such id does not exist!");

            return client;
        }

        private static void UpdateClients(List<Client> deserialized)
        {
            clients = new List<Client>(deserialized);
        }

        public override string ToString()
        {
            return $"{this.GetType()} [id: {client_id}; Fname: {first_name}; Lname: {last_name}," +
                $" type: {clientType}; contact: {contact}; bio: {bio}]";
        }
    }
}
