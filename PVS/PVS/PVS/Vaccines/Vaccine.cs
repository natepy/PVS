using System;
using System.Collections.Generic;

namespace PVS.PVS
{
    [Serializable]
    public class VaccineRecords
    {
        private Dictionary<string, int> Vaccines;

        public Dictionary<string, int> GetSystemData()
        {
            return Vaccines;
        }
        public void DisplayPatientNumberVaccineNamePairings(LinkedList<Patient> patients)
        {
            int PatientCount;
            foreach (var vaccine in Vaccines)
            {
                PatientCount = 0;
                Console.WriteLine();
                Console.WriteLine("Patient numbers who took {0}", vaccine.Key);
                foreach (var patient in patients)
                {
                    if (patient.HasTaken(vaccine.Key))
                    {
                        Console.WriteLine("\tPatient number: {0}", patient.Number);
                        PatientCount++;
                    }
                }
                if (PatientCount == 0)
                    Console.WriteLine("\tNo one has taken this vaccine yet.");
            }
        }
        public void PrintInfo(int PatientCount)
        {
            foreach (var Vaccine in Vaccines)
            {
                Console.WriteLine("{0}", Vaccine.Key);
                Console.WriteLine("\tFrequency: {0}", Vaccine.Value);
                Console.WriteLine("\tUsage percent: {0}%", getSysFrequency(Vaccine.Key, PatientCount));
            }
            Console.WriteLine("Total vaccines: {0}", Vaccines.Count);
        }
        public bool IncrementFrequency(string VaccineName)
        {
            if (VaccineExists(VaccineName))
            {
                Vaccines[VaccineName]++;
                return true;
            }
            return false;
        }
        public bool AddVaccine(string VaccineName, int VaccineFrequency = 0)
        {
            if (!(VaccineExists(VaccineName)))
            {
                Vaccines.Add(VaccineName, VaccineFrequency);
                return true;
            }
            return false;
        }
        public bool VaccineExists(string VaccineName)
        {
            foreach (var Vaccine in Vaccines)
                if (Vaccine.Key == VaccineName)
                    return true;
            return false;
        }
        public void setSampleData()
        {
            Vaccines = getSampleData();
        }
        private int getSysFrequency(string VaccineName, int PatientCount)
        {
            int sysFreq = 0;
            if (VaccineExists(VaccineName))
                sysFreq = (int)((Vaccines[VaccineName] / (double)PatientCount) * 100);
            return sysFreq;
        }
        private Dictionary<string, int> getSampleData()
        {
            Dictionary<string, int> vaccines = new Dictionary<string, int>();

            vaccines.Add("covid19", 0);
            vaccines.Add("sars", 0);
            vaccines.Add("swineflu", 0);
            vaccines.Add("measles", 0);
            vaccines.Add("chickenpox", 0);
            vaccines.Add("mumps", 0);
            vaccines.Add("whooping cough", 0);
            vaccines.Add("polio", 0);
            vaccines.Add("memb", 0);
            vaccines.Add("memc", 0);
            vaccines.Add("rotavirus", 0);
            vaccines.Add("tentanus", 0);

            return vaccines;
        }


        public VaccineRecords()
        {
            Vaccines = new Dictionary<string, int>();
        }
    }
}
