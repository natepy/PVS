using System;
using System.Collections.Generic;

namespace PVS.PVS
{
    class PVSManagement
    {
        PatientManagement ManagePatients;
        VacineManagement ManageVacines;

        public void SetUpSampleData()
        {
            ManagePatients.setSampleDate();
            ManageVacines.setSampleData();
            ManagePatients.AddVaccineToPatient("covid19", 1, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("sars", 1, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("swineflu", 1, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("measles", 2, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("memb", 3, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("covid19", 4, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("memc", 5, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("covid19", 6, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("covid19", 7, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("covid19", 8, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("sars", 8, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("rotavirus", 9, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("covid19", 12, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("sars", 13, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("swineflu", 13, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("sars", 14, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("swineflu", 14, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("mumps", 14, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("chickenpox", 14, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("whooping cough", 14, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("measles", 14, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("memb", 14, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("memc", 14, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("covid19", 14, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("polio", 14, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("rotavirus", 14, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("covid19", 15, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("covid19", 16, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("polio", 17, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("whooping cough", 18, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("mumps", 19, ManageVacines.getSystemData());
            ManagePatients.AddVaccineToPatient("mumps", 20, ManageVacines.getSystemData());
        }

        public void QueryEither()
        {
            LinkedList<string> vaccines = GetQuery();
            foreach (var patient in ManagePatients.getSystemData())
                patient.PrintIfTakenEither(vaccines);
        }
        public void QueryBoth()
        {
            LinkedList<string> vaccines = GetQuery();
            foreach (var patient in ManagePatients.getSystemData())
                patient.PrintIfTakenAll(vaccines);
        }
        private LinkedList<string> GetQuery()
        {
            LinkedList<string> vaccines = new LinkedList<string>();
            int MenuOption = -1;
            while (MenuOption != 0)
            {
                Console.WriteLine("1 - Add vaccine option.");
                Console.WriteLine("0 - Exit.");
                Console.Write("-> ");
                MenuOption = Convert.ToInt16(Console.ReadLine());
                if (MenuOption == 1)
                {
                    Console.Write("Enter vaccine name: ");
                    vaccines.AddLast(Console.ReadLine());
                }
            }
            return vaccines;
        }
        public void DisplayPatients()
        {
            ManagePatients.PrintPatients();
            Console.WriteLine("".PadLeft(51, '-'));
            Console.WriteLine();
            Console.WriteLine("Total patients: {0}", ManagePatients.PatientCount());
        }

        public void AddNewVacineToSystem()
        {
            string VacineName;
            Console.Write("Enter name of new vacine: ");
            VacineName = Console.ReadLine();
            ManageVacines.AddVaccineToSystem(VacineName);
        }

        public void AddVacineToPatient()
        {
            string VacineName;
            int PatientNumber;
            Console.Write("Enter name of existing vacine: ");
            VacineName = Console.ReadLine();
            Console.Write("Enter patient number: ");
            PatientNumber = Convert.ToInt16(Console.ReadLine());
            ManagePatients.AddVaccineToPatient(VacineName, PatientNumber, ManageVacines.getSystemData());
        }

        public void DisplayVacineFrequency()
        {
            ManageVacines.DisplayVaccineFreq(ManagePatients.PatientCount());
        }

        public void DisplayVacinePatient()
        {
            ManageVacines.VaccinePatient(ManagePatients.getSystemData());
        }

        // SaveAll();
        public void SaveAll()
        {
            ManagePatients.SaveOut("systemPatients.dat");
            ManageVacines.SaveOut("systemVacines.dat");
        }

        public PVSManagement() 
        {
            ManagePatients = new PatientManagement();
            ManageVacines = new VacineManagement();
        }
    }
}
