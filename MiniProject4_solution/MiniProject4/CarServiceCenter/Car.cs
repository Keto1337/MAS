using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniProject4
{
    class Car
    {

        private static Dictionary<string, Car> _extent = new();

        //Unique
        private readonly string serial_nr;
        private string model;

        private const string serial_regex = "^(?=.*[0-9])(?=.*[A-z])[0-9A-z-]{17}$";

        //Ordered
        private LinkedList<Worker> assigned_mechanics = new();


        // For an attribute
        private double repair_cost;
        

        public string Model
        {
            get => model;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Model is null or empty");
                model = value;
            }
        }
        public string Serial_Nr { get => serial_nr; }

        public LinkedList<Worker> AssignedMechanics 
        {
            get => new(assigned_mechanics);
        }

        private const double min_repair_cost = 100;
        private const double max_repair_cost = 5000;
        private const int max_repair_cost_increase_percentage = 50;
        private const int max_repair_cost_decrease_percentage = 15;

        public double RepairCost 
        {
            get => repair_cost;
            set
            {
                if (value > max_repair_cost) throw new ArgumentException($"RepairCost can't be more than {max_repair_cost}");
                if (value < min_repair_cost) throw new ArgumentException($"RepairCost can't be less than {min_repair_cost}");

                if (repair_cost != 0)
                    if (value > repair_cost && (value - repair_cost) * 100 / repair_cost > max_repair_cost_increase_percentage)
                        throw new ArgumentException($"RepairCost can't increase on more than {max_repair_cost_increase_percentage}%");
                    if (value < repair_cost && (repair_cost - value) * 100 / repair_cost < max_repair_cost_decrease_percentage)
                        throw new ArgumentException($"RepairCost can't decrease on more than {max_repair_cost_decrease_percentage}%");

                repair_cost = value;
            }
        }

        // constructor
        public Car(string serial_nr, string model, double repair_cost)
        {
            if (string.IsNullOrEmpty(serial_nr)) throw new ArgumentNullException("Serial Number is null or empty.");
            if (_extent.ContainsKey(serial_nr)) throw new ArgumentException("There is already a car with the same serial number.");
            if (!Regex.IsMatch(serial_nr, serial_regex)) throw new ArgumentException("Serial number does not match regex.");

            this.serial_nr = serial_nr;
            Model = model;
            RepairCost = repair_cost;

            _extent.Add(serial_nr, this);
        }

        public void AddMechanic(Worker mechanic)
        {
            if (mechanic is null) throw new ArgumentNullException("Mechanic is null.");
            if (assigned_mechanics.Contains(mechanic)) return;

            assigned_mechanics.AddLast(mechanic);
            mechanic.AssignedCar = this;
        }

        public void RemoveMechanic(Worker mechanic)
        {
            if (mechanic is null) throw new ArgumentNullException("Mechanic is null.");
            if (!assigned_mechanics.Contains(mechanic)) return;

            assigned_mechanics.Remove(mechanic);
            mechanic.AssignedCar = null;
        }

        public static Car GetCarBySerial(string serial_nr)
        {
            if (!_extent.TryGetValue(serial_nr, out Car car)) 
                throw new ArgumentException("No Car with such serial number were found.");
            return car;
        }
    }
}
