using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSQL
{
    class DoctorFunctions
    {
        public static void Select()
        {
            Console.WriteLine("{0, -10}{1, -15}{2, -10}{3, -10}{4, -15}{5, -10}","AK", "Vardas", "Pavarde", "Kvalifikacija", "Atlyginimas", "Ligonines Pavadinimas");
            foreach (DataRow rows in ManualDbConnection.Select("SELECT * FROM dbo.Gydytojas").Rows)
            {
                Console.WriteLine("{0, -10}{1, -15}{2, -10}{3, -10}{4, -15}{5, -10}", rows[0], rows[1], rows[2], rows[3], rows[4], rows[5]);
            }
            Console.WriteLine();
        }

        internal static bool Insert()
        {
            Console.Write("Norimas asmens kodas: ");
            string AK = Console.ReadLine();
            Console.Write("Norimas vardas: ");
            string vardas = Console.ReadLine();
            Console.Write("Norima pavardė: ");
            string pavarde = Console.ReadLine();
            Console.Write("Norima kvalifikacija: ");
            string kvalifikacija = Console.ReadLine();
            Console.Write("Norimas atlyginimas: ");
            string atlyginimas = Console.ReadLine();
            Console.Write("Norima ligoninė: ");
            string ligonine = Console.ReadLine();
            SqlCommand command = new SqlCommand("INSERT INTO dbo.Gydytojas VALUES(@AK, @vardas, @pavarde, @kvalifikacija, @atlyginimas, @ligonine)");
            command.Parameters.AddWithValue("@AK", AK);
            command.Parameters.AddWithValue("@vardas", vardas);
            command.Parameters.AddWithValue("@pavarde", pavarde);
            command.Parameters.AddWithValue("@kvalifikacija", kvalifikacija);
            command.Parameters.AddWithValue("@atlyginimas", atlyginimas);
            command.Parameters.AddWithValue("@ligonine", ligonine);
            if (ManualDbConnection.Change(command))
            {
                Console.WriteLine("Success!");
                return true;
            }
            Console.WriteLine("Error!");
            return false;
        }

        internal static bool Update()
        {
            Console.Write("Įveskite norimo keisti gydytojo asmens kodą: ");
            string AK = Console.ReadLine();
            foreach (DataRow rows in ManualDbConnection.Select("SELECT * FROM dbo.Gydytojas").Rows)
            {
                if (AK.Equals(rows[0].ToString()))
                {
                    Console.Write("Dabartinis darbovietėsc pavadinimas: {0}. Nauja darbovietė: ", rows[5].ToString());
                    string pavadinimas = Console.ReadLine();
                    SqlCommand command = new SqlCommand("UPDATE dbo.Gydytojas SET Ligonine=@pavadinimas WHERE AK=@AK");
                    command.Parameters.AddWithValue("@pavadinimas", pavadinimas);
                    command.Parameters.AddWithValue("@AK", AK);
                    if (ManualDbConnection.Change(command))
                    {
                        Console.WriteLine("Success!");
                        return true;
                    }
                    Console.WriteLine("Error!");
                    return false;
                }
            }
            Console.WriteLine("Tokio gydytojo nėra!");
            return false;
        }

        internal static bool Delete()
        {
            Console.Write("Įveskite gydytojo asmens kodą: ");
            string AK = Console.ReadLine();
            foreach (DataRow rows in ManualDbConnection.Select("SELECT * FROM dbo.Gydytojas").Rows)
            {
                if (AK.Equals(rows[0].ToString()))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM dbo.Gydytojas WHERE AK=@AK");
                    command.Parameters.AddWithValue("@AK", AK);
                    if (ManualDbConnection.Change(command))
                    {
                        Console.WriteLine("Success!");
                        return true;
                    }
                    Console.WriteLine("Error!");
                    return false;
                }
            }
            Console.WriteLine("Tokio gydytojo nėra!");
            return false;
        }
    }
}
