using System;
using System.Data;

namespace ProjectSQL
{
    internal class Menu
    {
        public Menu()
        {
        }

        internal void Start()
        {
            bool valid = true;
            while (valid)
            {
                Console.WriteLine("Ligoninės duomenų bazės valdymas" + Environment.NewLine +
                                    "1. Ligoninės" + Environment.NewLine +
                                    "2. Gydytojai" + Environment.NewLine +
                                    "3. Gydymai" + Environment.NewLine +
                                    "4. Pacientai" + Environment.NewLine +
                                    "5. LINQ Join Pacientų ir jų gydymų sąrašas" + Environment.NewLine +
                                    "6. LINQ Group Gydymų sąrašas" + Environment.NewLine + 
                                    "7. LINQ Skip, Take, Aggregate Atlyginimai" + Environment.NewLine + 
                                    "8. Išeiti iš programos.");

                switch (Console.ReadLine())
                {
                    case "1":
                        ManageHospitals();
                        break;
                    case "2":
                        ManageDoctors();
                        break;
                    case "3":
                        ManageTreatment();
                        break;
                    case "4":
                        ManagePatients();
                        break;
                    case "5":
                        LinqFunctions.PatientsAndTreatments();
                        break;
                    case "6":
                        LinqFunctions.GroupTreatments();
                        break;
                    case "7":
                        LinqFunctions.Salaries();
                        break;
                    case "8":
                        Console.Write("Good bye!");
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Neteisingas simbolis!");
                        Console.Clear();
                        break;
                }
            }
        }

        private void ManageHospitals()
        {
            HospitalFunctions.Select();
            bool valid = true;
            while (valid)
            {
                Console.WriteLine("1. Pridėti naują ligoninę" + Environment.NewLine +
                                    "2. Pakeisti biudžetą" + Environment.NewLine +
                                    "3. Ištrinti ligoninę" + Environment.NewLine +
                                    "4. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        if (HospitalFunctions.Insert()) goto case "4";
                        break;
                    case "2":
                        if (HospitalFunctions.Update()) goto case "4";
                        break;
                    case "3":
                        if (HospitalFunctions.Delete()) goto case "4";
                        break;
                    case "4":
                        valid = false;
                        break;
                    default:
                        Console.WriteLine("Neteisingas simbolis!");
                        break;
                }
            }
        }

        private void ManageDoctors()
        {
            DoctorFunctions.Select();
            bool valid = true;
            while (valid)
            {                
                Console.WriteLine("1. Pridėti naują gydytoją" + Environment.NewLine +
                                    "2. Pakeisti darbovietę" + Environment.NewLine +
                                    "3. Ištrinti gydytoją" + Environment.NewLine +
                                    "4. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        if (DoctorFunctions.Insert()) goto case "4";
                        break;
                    case "2":
                        if (DoctorFunctions.Update()) goto case "4";
                        break;
                    case "3":
                        if (DoctorFunctions.Delete()) goto case "4";
                        break;
                    case "4":
                        valid = false;
                        break;
                    default:
                        Console.WriteLine("Neteisingas simbolis!");
                        break;
                }
            }
        }

        private void ManagePatients()
        {
            PatientFunctions.Select();
            bool valid = true;
            while (valid)
            {                
                Console.WriteLine("1. Pridėti naują pacientą" + Environment.NewLine +
                                    "2. Ištrinti pacientą" + Environment.NewLine +
                                    "3. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        if (PatientFunctions.Insert()) goto case "3";
                        break;
                    case "2":
                        if (PatientFunctions.Delete()) goto case "3";
                        break;
                    case "3":
                        valid = false;
                        break;
                    default:
                        Console.WriteLine("Neteisingas simbolis!");
                        break;
                }
            }
        }

        private void ManageTreatment()
        {
            TreatmentFunctions.Select();
            bool valid = true;
            while (valid)
            {
                Console.WriteLine("1. Pridėti naują gydymą" + Environment.NewLine +
                                    "2. Pakeisti baigimo datą" + Environment.NewLine +
                                    "3. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        if (TreatmentFunctions.Insert()) goto case "3";
                        break;
                    case "2":
                        if (TreatmentFunctions.Update()) goto case "3";
                        break;
                    case "3":
                        valid = false;
                        break;
                    default:
                        Console.WriteLine("Neteisingas simbolis!");
                        break;
                }
            }
        }
    }
}