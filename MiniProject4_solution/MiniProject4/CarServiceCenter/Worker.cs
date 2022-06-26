using MiniProject4.CarServiceCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject4
{
    enum WorkerType { Owner, Mechanic }
    enum MechanicType { None, SeniorMechanic, JuniorMechanic }
    class Worker
    {
        private static List<Worker> workers_mechanics = new();

        private string first_name, last_name;

        private double base_salary;
        public const double salary_junior_mul = 1.5, salary_senior_mul = 2.5;

        private MechanicType mechanic_type;
        private Owner owner;

        private WorkerType worker_type;

        private Car assigned_car;

        private List<MechanicServiceCenter> service_centers = new();
        private List<ServiceCenter> managed_service_centers = new();


        public List<Worker> WorkersMechanics { get => new(workers_mechanics); }

        public string FirstName
        {
            get => first_name;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("First name is null or empty");
                first_name = value;
            }
        }
        public string LastName
        {
            get => last_name;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Last name is null or empty");
                last_name = value;
            }
        }

        public double Salary 
        { 
            get
            {
                if (worker_type != WorkerType.Mechanic) throw new Exception("OwnerWorker doesn't have access to this property");
                return mechanic_type switch
                {
                    MechanicType.JuniorMechanic => base_salary * salary_junior_mul,
                    MechanicType.SeniorMechanic => base_salary * salary_senior_mul,
                    _ => throw new Exception("No such mechanic type implemented.")
                };
            }
            set
            {
                if (worker_type != WorkerType.Mechanic) throw new Exception("OwnerWorker doesn't have access to this property");
                if (value < 0) throw new ArgumentException("Salary can't be less than 0.");
                base_salary = value;
            }
        }

        public MechanicType MechanicType 
        {
            get
            {
                if (worker_type != WorkerType.Mechanic) throw new Exception("OwnerWorker doesn't have access to this property");
                return mechanic_type;
            }
        }
        public Owner Owner 
        {
            get
            {
                if (worker_type != WorkerType.Owner) throw new Exception("MechanicWorker doesn't have access to this property");
                return owner;
            }
        }

        public WorkerType WorkerType { get => worker_type; }

        public Car AssignedCar 
        {
            get
            {
                if (worker_type != WorkerType.Mechanic) throw new Exception("OwnerWorker doesn't have access to this property");
                return assigned_car;
            }
            set
            {
                if (worker_type != WorkerType.Mechanic) throw new Exception("OwnerWorker doesn't have access to this property");
                if (value == assigned_car) return;

                if (assigned_car is not null)
                {
                    if (value is null)
                    {
                        // Remove connection
                        var tmp = assigned_car;
                        assigned_car = null;
                        tmp.RemoveMechanic(this);
                    }
                    else
                    {
                        // Change connection
                        var tmp = assigned_car;
                        assigned_car = null;
                        tmp.RemoveMechanic(this);
                        assigned_car = value;
                        value.AddMechanic(this);
                    }
                }
                else
                {
                    if (value is not null)
                    {
                        // Add connection
                        assigned_car = value;
                        value.AddMechanic(this);
                    }
                }

                assigned_car = value;
            }
        }

        public List<MechanicServiceCenter> ServiceCenters
        {
            get
            {
                if (worker_type != WorkerType.Mechanic) throw new Exception("OwnerWorker doesn't have access to this property");
                return new(service_centers);
            }
        }

        public List<ServiceCenter> ManagedServiceCenters 
        {
            get
            {
                if (worker_type != WorkerType.Mechanic) throw new Exception("OwnerWorker doesn't have access to this property");
                return new(managed_service_centers);
            }
        }

        // constructor Mechanic
        public Worker(string firstName, string lastName, double salary, MechanicType mechanicType)
        {
            worker_type = WorkerType.Mechanic;
            mechanic_type = mechanicType;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            owner = null;

            workers_mechanics.Add(this);
        }

        // constructor Owner
        public Worker(string firstName, string lastName)
        {
            worker_type = WorkerType.Owner;
            mechanic_type = MechanicType.None;
            FirstName = firstName;
            LastName = lastName;
            base_salary = 0;
            owner = new Owner(this);
        }


        public void AddServiceCenter(MechanicServiceCenter serviceCenter)
        {
            if (worker_type != WorkerType.Mechanic) throw new Exception("OwnerWorker doesn't have access to this method");

            if (serviceCenter is null) throw new ArgumentNullException("ServiceCenter is null.");
            if (serviceCenter.WorkingMechanic != this) throw new ArgumentException("This ServiceCenter is not for this Mechanic.");

            service_centers.Add(serviceCenter);
        }

        public void RemoveServiceCenter(MechanicServiceCenter serviceCenter)
        {
            if (worker_type != WorkerType.Mechanic) throw new Exception("OwnerWorker doesn't have access to this method");

            if (serviceCenter is null) throw new ArgumentNullException("ServiceCenter is null.");
            if (!service_centers.Contains(serviceCenter)) return;

            service_centers.Remove(serviceCenter);
            serviceCenter.RemovePair();
        }

        public void ManageServiceCenter(ServiceCenter serviceCenter)
        {
            if (worker_type != WorkerType.Mechanic) throw new Exception("OwnerWorker doesn't have access to this method");
            if (MechanicType != MechanicType.SeniorMechanic)
                throw new Exception($"Mechanic has to be {MechanicType.SeniorMechanic} to manage service center");

            if (serviceCenter is null) throw new ArgumentNullException("ServiceCenter is null.");
            if (service_centers.Any(sc => sc.ServiceCenter == serviceCenter) == false)
                throw new Exception("This Mechanic can't manage service center which they don't work in.");
            
            
            if (managed_service_centers.Contains(serviceCenter)) return;

            managed_service_centers.Add(serviceCenter);
            serviceCenter.Manager = this;
        }

        public void StopManagingServiceCenter(ServiceCenter serviceCenter)
        {
            if (worker_type != WorkerType.Mechanic) throw new Exception("OwnerWorker doesn't have access to this method");

            if (serviceCenter is null) throw new ArgumentNullException("ServiceCenter is null.");
            if (!managed_service_centers.Contains(serviceCenter)) return;

            managed_service_centers.Remove(serviceCenter);
            serviceCenter.Manager = null;
        }

        public double CalculateAllSalaries()
        {
            if (worker_type != WorkerType.Owner) throw new Exception("MechanicWorker doesn't have access to this method");
            return owner.CalculateAllSalaries();
        }
    }
}
