using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSQL
{
    class PatientFunctions
    {
        public static void Select()
        {
            var context = new LigoninesDBEntities();
            Console.WriteLine("{0, -10}{1, -15}{2, -10}{3, -10}","AK", "Vardas", "Pavarde", "Gimimo Metai");
            foreach (Pacientas patient in context.Pacientas1)
            {
                Console.WriteLine("{0, -10}{1, -15}{2, -10}{3, -10}", patient.AK, patient.Vardas, patient.Pavarde, patient.Gimimo_Metai);
            }
            Console.WriteLine();
        }

        internal static bool Insert()
        {
            var context = new LigoninesDBEntities();
            Console.Write("Įveskite naujo paciento asmens kodą: ");
            string AK = Console.ReadLine();
            Console.Write("Įveskite naujo paciento vardą: ");
            string vardas = Console.ReadLine();
            Console.Write("Įveskite naujo paciento pavardę: ");
            string pavarde = Console.ReadLine();
            Console.Write("Įveskite naujo paciento gimimo datą (dd/mm/yyyy): ");
            DateTime data = DateTime.Parse(Console.ReadLine());
            context.Pacientas1.Add(new Pacientas()
            {
                AK = AK,
                Vardas = vardas,
                Pavarde = pavarde,
                Gimimo_Metai = data
            });
            context.SaveChanges();
            Console.WriteLine("Success!");
            return true;

        }

        internal static bool Delete()
        {
            var context = new LigoninesDBEntities();
            Console.Write("Įveskite paciento AK");
            string AK = Console.ReadLine();
            foreach(Pacientas patient in context.Pacientas1.ToList())
            {
                if(patient.AK.ToString() == AK)
                {
                    context.Pacientas1.Remove(patient);
                    context.SaveChanges();
                    Console.WriteLine("Success!");
                    return true;
                }
            }
            Console.WriteLine("Tokio paciento nėra!");
            return false;
        }
    }
}
