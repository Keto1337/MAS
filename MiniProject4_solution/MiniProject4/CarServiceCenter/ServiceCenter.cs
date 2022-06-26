using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject4
{
    class ServiceCenter
    {

        private string name, address;

        private List<MechanicServiceCenter> working_mechanics = new();

        private Worker manager;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Name is null or empty");
                name = value;
            }
        }
        public string Address
        {
            get => address;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Address is null or empty");
                address = value;
            }
        }

        public List<MechanicServiceCenter> WorkingMechanics { get => new(working_mechanics); }

        public Worker Manager 
        { 
            get => manager;
            set
            {
                if (value == manager) return;

                if (manager is not null)
                {
                    if (value is null)
                    {
                        // Remove connection
                        var tmp = manager;
                        manager = null;
                        tmp.StopManagingServiceCenter(this);
                    }
                    else
                    {
                        // Change connection
                        if (working_mechanics.Any(wm => wm.WorkingMechanic == value) == false)
                            throw new Exception("This Mechanic can't manage service center which they don't work in.");

                        var tmp = manager;
                        manager = null;
                        tmp.StopManagingServiceCenter(this);
                        manager = value;
                        value.ManageServiceCenter(this);
                    }
                }
                else
                {
                    if (value is not null)
                    {
                        // Add connection
                        if (working_mechanics.Any(wm => wm.WorkingMechanic == value) == false)
                            throw new Exception("This Mechanic can't manage service center which they don't work in.");

                        manager = value;
                        value.ManageServiceCenter(this);
                    }
                }

                manager = value;
            }
        }

        // constructor
        public ServiceCenter(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public void AddMechanic(MechanicServiceCenter mechanic)
        {
            if (mechanic is null) throw new ArgumentNullException("Mechanic is null.");
            if (mechanic.ServiceCenter != this) throw new ArgumentException("This Mechanic is not for this ServiceCenter.");

            working_mechanics.Add(mechanic);
        }

        public void RemoveMechanic(MechanicServiceCenter mechanic)
        {
            if (mechanic is null) throw new ArgumentNullException("Mechanic is null.");
            if (!working_mechanics.Contains(mechanic)) return;

            working_mechanics.Remove(mechanic);
            mechanic.RemovePair();
        }
    }
}
