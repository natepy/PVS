using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PVS.PVS
{ 
    public class VacineManagement
    {
        private VaccineRecords SystemVaccines;

        public void VaccinePatient(LinkedList<Patient> patients)
        {
            SystemVaccines.DisplayPatientNumberVaccineNamePairings(patients);
        }

        public void AddVaccineToSystem(string VaccineName, int VacineFreq=0)
        {
            bool VaccineAdded = SystemVaccines.AddVaccine(VaccineName, VacineFreq);
            if (!(VaccineAdded))
                Console.WriteLine("Vaccine already exists on system.");
            else
                Console.WriteLine("New vaccine saved to the system.");
        }

        public void IncrementSysVacineFreq(string VaccineName)
        {
            bool VaccineIncrement = SystemVaccines.IncrementFrequency(VaccineName);
            if (!(VaccineIncrement))
                Console.WriteLine("Vaccine does not exists on system.");
        }

        public void DisplayVaccineFreq(int PatientCount)
        {
            SystemVaccines.PrintInfo(PatientCount);
        }
        public void setSampleData()
        {
            SystemVaccines.setSampleData();
        }

        public VaccineRecords getSystemData()
        {
            return SystemVaccines;
        }

        // save
        public void SaveOut(string file)
        {
            FileInfo VaccinesFile = new FileInfo(file);
            FileStream VaccineFileStream;
            BinaryFormatter FormatVaccineFile = new BinaryFormatter();

            if (VaccinesFile.Exists)
                VaccineFileStream = new FileStream(file, FileMode.Truncate, FileAccess.Write);
            else
                VaccineFileStream = new FileStream(file, FileMode.Create, FileAccess.Write);

            try
            {
                foreach (var vaccine in SystemVaccines.GetSystemData())
                {
                    FormatVaccineFile.Serialize(VaccineFileStream, $"{vaccine.Key}, {vaccine.Value}\n");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            VaccineFileStream.Close();
            Console.WriteLine("Vaccines saved to file {0}", VaccinesFile.FullName);
        }

        public VacineManagement()
        {
            SystemVaccines = new VaccineRecords();
        }
    }
}
