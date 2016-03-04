using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSQL
{
    class LinqFunctions
    {
        public static void PatientsAndTreatments()
        {
            var context = new LigoninesDBEntities();

            var group =
                from p in context.Pacientas1
                join pa in context.Gydymas1 on p.AK equals pa.PacientoAK into pacientai

                from pac in pacientai

                select new
                {
                    p.Vardas,
                    p.Pavarde,
                    pac.Diagnoze
                };

            Console.WriteLine();
            foreach (var element in group)
            {
                Console.WriteLine("{0, -10}{1, -15}{2}", element.Vardas, element.Pavarde, element.Diagnoze);
            }
            Console.WriteLine();
        }

        public static void GroupTreatments()
        {
            var context = new LigoninesDBEntities();

            var treats =
                from t in context.Gydymas1
                group t by t.Baigta != null;

            Console.WriteLine();
            foreach (var treat in treats)
            {
                if (treat.Key)
                    Console.WriteLine("Baigti gydymai:");
                else
                    Console.WriteLine("Nebaigti gydymai:");
                foreach (var row in treat)
                {
                    Console.Write("\t-" + row.Gydymo_Nr, row.Diagnoze);
                    if (treat.Key)
                        Console.WriteLine("{0}", row.Baigta.ToString());
                    else
                        Console.WriteLine();
                }
            }
        }

        public static void Salaries()
        {
            int from;
            int to;
            var context = new LigoninesDBEntities();
            Console.WriteLine("Viso elementu: " + context.Gydytojas1.Count());
            Console.WriteLine();
            Console.Write("Norimas pirmas elementas: ");
            from = int.Parse(Console.ReadLine());
            Console.Write("Norimas paskutinis elementas: ");
            to = int.Parse(Console.ReadLine());

            var docs = context.Gydytojas1.OrderBy(c => c.AK).Skip(from).Take(to);
            Console.WriteLine(Environment.NewLine + "{0, -10}{1, -15}{2, -15}", "Vardas", "Pavarde", "Atlyginimas");

            foreach (var doc in docs)
            {
                Console.WriteLine("{0, -10}{1, -15}{2, -15}", doc.Vardas, doc.Pavarde, doc.Atlyginimas);
            }

            int atlyginimuSuma = docs.ToList().Aggregate(0, (a, b) => (int)(b.Atlyginimas + a));

            Console.WriteLine("Bendra suma: {0}", atlyginimuSuma);
        }
    }
}
