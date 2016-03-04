using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSQL
{
    class TreatmentFunctions
    {
        public static void Select()
        {
            var context = new LigoninesDBEntities();
            Console.WriteLine("{0, -10}{1, -15}{2, -10}{3, -10}{4, -15}{5, -10}{6, -10}","Gydymo nr", "Pradėta", "Baigta", "Skirti vaistai", "Gydytojo AK", "Paciento AK", "Diagnozė");
            foreach (Gydymas treatment in context.Gydymas1)
            {
                Console.WriteLine("{0, -10}{1, -15}{2, -10}{3, -10}{4, -15}{5, -10}{6, -10}",
                                    treatment.Gydymo_Nr, treatment.Pradeta, treatment.Baigta, treatment.Skirti_Vaistai,
                                    treatment.GydytojoAK, treatment.PacientoAK, treatment.Diagnoze);
            }
            Console.WriteLine();
        }

        internal static bool Insert()
        {
            int gydymoNr = 0;
            foreach (DataRow rows in ManualDbConnection.Select("SELECT * FROM dbo.Gydymas").Rows)
            {
                gydymoNr = rows.Field<int>("Gydymo_Nr");
            }
            gydymoNr++;
            var context = new LigoninesDBEntities();
            Console.Write("Įveskite gydytojo AK: ");
            string gydAK = Console.ReadLine();
            Console.Write("Įveskite paciento AK: ");
            string pacAK = Console.ReadLine();
            Console.Write("Įveskite diagnozę: ");
            string diagnoze = Console.ReadLine();
            Console.Write("Įveskite skirtus vaistus: ");
            string vaistai = Console.ReadLine();

            context.Gydymas1.Add(new Gydymas()
            {
                Gydymo_Nr = gydymoNr,
                GydytojoAK = gydAK,
                PacientoAK = pacAK,
                Diagnoze = diagnoze,
                Skirti_Vaistai = vaistai,
                Pradeta = DateTime.Now
            });
            context.SaveChanges();
            Console.WriteLine("Success!");
            return true;
        }

        internal static bool Update()
        {
            var context = new LigoninesDBEntities();
            Console.Write("Įveskite gydymo numerį: ");
            string gydymoNr = Console.ReadLine();
            foreach(Gydymas treatment in context.Gydymas1.ToList())
            {
                if (gydymoNr.Equals(treatment.Gydymo_Nr.ToString()))
                {
                    Console.Write("Įveskite pabaigos datą (dd/mm/yyyy): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    treatment.Baigta = date;
                    context.SaveChanges();
                    Console.WriteLine("Success!");
                    return true;
                }
            }
            Console.WriteLine("Tokio gydymo nėra!");
            return false;
        }
    }
}
