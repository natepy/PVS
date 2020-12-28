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
    public class PatientManagement
    {
        private static LinkedList<Patient> patients;

        public void AddVaccineToPatient(string VaccineName, int PatientNumber, VaccineRecords vaccines)
        {
            foreach (var patient in patients)
            {
                if (patient.Number == PatientNumber)
                {
                    if (vaccines.VaccineExists(VaccineName))
                    {
                        patient.AddVacine(VaccineName, vaccines);
                        Console.WriteLine("Vaccine added to patient number {0}'s history.", patient.Number);
                    }
                    else
                        Console.WriteLine("Vaccine does not exist on our system.");
                }
            }
        }
        public int PatientCount()
        {
            return patients.Count();
        }
        public void setSampleDate()
        {
            if (patients != null)
            {
                patients.Clear();
                Console.WriteLine("List cleared.");
            }
            patients = getSampleData();
            Console.WriteLine();
            Console.WriteLine("Data initalised.");
        }
        private static LinkedList<Patient> getSampleData()
        {
            LinkedList<Patient> sampleData = new LinkedList<Patient>();
            sampleData.AddLast(new Patient(1, "Nathan O'Connor", "28/02/1999"));
            sampleData.AddLast(new Patient(2, "Oleg Vladimirovich", "23/03/1983"));
            sampleData.AddLast(new Patient(3, "Keith Kelly", "09/05/2001"));
            sampleData.AddLast(new Patient(4, "Micheal D. Higgens", "18/04/1941"));
            sampleData.AddLast(new Patient(5, "Mary McAleese", "27/06/1951"));
            sampleData.AddLast(new Patient(6, "Patrick Hillery", "02/05/1923"));
            sampleData.AddLast(new Patient(7, "Cearbhall Ó Dálaigh", "12/02/1911"));
            sampleData.AddLast(new Patient(8, "Erskine H. Childers", "11/12/1905"));
            sampleData.AddLast(new Patient(9, "Éamon de Velera", "14/10/1882"));
            sampleData.AddLast(new Patient(10, "Seán T. O'Kelly", "25/08/1882"));
            sampleData.AddLast(new Patient(11, "Douglas Hyde", "17/01/1945"));
            sampleData.AddLast(new Patient(12, "Tony Hawk", "12/05/1968"));
            sampleData.AddLast(new Patient(13, "John Cena", "23/04/1977"));
            sampleData.AddLast(new Patient(14, "Mary Kelly", "09/11/1888"));
            sampleData.AddLast(new Patient(15, "Johnny Nitro", "03/10/1979"));
            sampleData.AddLast(new Patient(16, "Rey Mysterio", "11/12/1974"));
            sampleData.AddLast(new Patient(17, "Peter Parker", "10/08/2001"));
            sampleData.AddLast(new Patient(18, "Mike Murphy", "20/10/1941"));
            sampleData.AddLast(new Patient(19, "Pádrig J. O'Leprosy", "01/01/1941"));
            sampleData.AddLast(new Patient(20, "Rodraig S. O'Leprosy", "01/01/1941"));
            return sampleData;
        }
        public void PrintPatients()
        {
            foreach (var patient in patients)
            {
                Console.WriteLine("".PadLeft(50, '-'));
                patient.Print();
            }
        }

        public void HasTaken(string VaccineName)
        {
            foreach (var patient in patients)
                if (patient.HasTaken(VaccineName))
                    Console.WriteLine("{0}", patient.Number);
        }

        public LinkedList<Patient> getSystemData()
        {
            return patients;
        }

        private static bool PatientExists(int PatientNumber)
        {
            foreach (var patient in patients)
                if (PatientNumber == patient.Number)
                    return true;
            return false;
        }

        public void SaveOut(string file)
        {
            FileInfo PatientFile = new FileInfo(file);
            FileStream PatientFileStream;
            BinaryFormatter FormatPatientFile = new BinaryFormatter();

            if (PatientFile.Exists)
                PatientFileStream = new FileStream(file, FileMode.Truncate, FileAccess.Write);
            else
                PatientFileStream = new FileStream(file, FileMode.Create, FileAccess.Write);

            try
            {
                foreach (var patient in patients)
                {
                    FormatPatientFile.Serialize(PatientFileStream, $"{patient.Number}, {patient.Name}, {patient.DateOfBirth}, vaccines: {patient.GetVaccinesTakenAsString()}\n");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            PatientFileStream.Close();
            Console.WriteLine("Vaccines saved to file {0}", PatientFile.FullName);
        }

        public PatientManagement() 
        {
            patients = new LinkedList<Patient>();
        }
    }
}
