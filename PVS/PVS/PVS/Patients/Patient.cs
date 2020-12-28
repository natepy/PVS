using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVS.PVS
{
    [Serializable]
    public class Patient
    {
        private LinkedList<string> VaccinesTaken;

        public int Number { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }

        public string GetVaccinesTakenAsString()
        {
            string vaccines = "";
            foreach (var vaccine in VaccinesTaken)
            {
                vaccines += $"{vaccine}, ";
            }
            return vaccines;
        }
        public void AddVacine(string VaccineName, VaccineRecords vaccines)
        {
            if (vaccines.VaccineExists(VaccineName))
            {
                VaccinesTaken.AddLast(VaccineName);
                vaccines.IncrementFrequency(VaccineName);
            }
            else
                Console.WriteLine("Vaccine does not exist on system.");
        }
        public void PrintIfTakenEither(LinkedList<string> vaccines)
        {
            if (HasTakenEither(vaccines))
                Console.WriteLine("Patient number: {0}", Number);
        }
        public void PrintIfTakenAll(LinkedList<string> vaccines)
        {
            if (HasTakenAll(vaccines))
                Console.WriteLine("Patient number: {0}", Number);
        }
        private bool HasTakenAll(LinkedList<string> vaccines)
        {
            foreach (var vaccine in vaccines)
                if (!(HasTaken(vaccine)))
                    return false;
            return true;
        }
        private bool HasTakenEither(LinkedList<string> vaccines)
        {
            foreach (var vaccine in vaccines)
                if (HasTaken(vaccine))
                    return true;
            return false;
        }
        public bool HasTaken(string Vaccine)
        {
            foreach (var vaccine in VaccinesTaken)
                if (vaccine == Vaccine)
                    return true;
            return false;
        }
        public void Print()
        {
            Console.WriteLine("Patient Number: {0}", Number);
            Console.WriteLine("Patient Name: {0}", Name);
            Console.WriteLine("Patient DOB: {0}", DateOfBirth);
            Console.WriteLine("Patient Vacine History:");
            foreach (var vaccine in VaccinesTaken)
                Console.WriteLine("\t{0}", vaccine);
        }

        public Patient()
        {
            VaccinesTaken = new LinkedList<string>();
        }
        public Patient(int Number, string Name, string DateOfBirth)
        {
            this.Number = Number;
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
            VaccinesTaken = new LinkedList<string>();
        }
        public Patient(int Number, string Name, string DateOfBirth, LinkedList<string> VaccinesTaken)
        {
            this.Number = Number;
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
            this.VaccinesTaken = VaccinesTaken;
        }
    }
}
