using System;

namespace PVS.PVS
{
    class MenuSystem
    {
        private PVSManagement SysPVS;
        public int MenuOption { get; set; }

        public void RunApplication()
        {
            while (MenuOption != 0)
            {
                Console.WriteLine("{0}Patient Vaccine System{1}","".PadLeft(15, '-'), "".PadLeft(15, '-'));
                DisplayMenu();
                GetMenuOption();
                Console.WriteLine("".PadLeft(51, '-'));
                ProcessMenuOption();
                Console.WriteLine();
                if (MenuOption > 0)
                    Console.WriteLine("Press Enter to continue ...");
                else
                    Console.WriteLine("Program terminated, press enter to close ...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("1 - Set up sample patient data (will erase previous data).");
            Console.WriteLine("2 - Display patient data.");
            Console.WriteLine("3 - Add vaccine to system.");
            Console.WriteLine("4 - Add vaccine to patient.");
            Console.WriteLine("5 - Display vaccine information.");
            Console.WriteLine("6 - Display patient numbers per vaccine.");
            Console.WriteLine("7 - Dynamic query both.");
            Console.WriteLine("8 - Dynamic query all.");
            Console.WriteLine("9 - Save infomation.");
            Console.WriteLine("0 - Exit.");
            Console.Write("-> ");
        }
        private void GetMenuOption()
        {
            
            MenuOption = Convert.ToInt16(Console.ReadLine());
        }
        private void ProcessMenuOption()
        {
            switch (MenuOption)
            {
                case 1:
                    SysPVS.SetUpSampleData();
                    break;
                case 2:
                    SysPVS.DisplayPatients();
                    break;
                case 3:
                    SysPVS.AddNewVacineToSystem();
                    break;
                case 4:
                    SysPVS.AddVacineToPatient();
                    break;
                case 5:
                    SysPVS.DisplayVacineFrequency();
                    break;
                case 6:
                    SysPVS.DisplayVacinePatient();
                    break;
                case 7:
                    SysPVS.QueryBoth();
                    break;
                case 8:
                    SysPVS.QueryEither();
                    break;
                case 9:
                    SysPVS.SaveAll();
                    break;
                default:
                    break;
            }
        }

        public MenuSystem()
        {
            SysPVS = new PVSManagement();
            MenuOption = -1;
        }
    }
}
