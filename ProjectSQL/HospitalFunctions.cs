using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSQL
{
    class HospitalFunctions
    {
        public static void Select()
        {
            Console.WriteLine();
            Console.WriteLine("Pavadinimas, Adresas, Biudžetas");
            foreach (DataRow rows in ManualDbConnection.Select("SELECT * FROM dbo.Ligonine").Rows)
            {
                Console.WriteLine("{0, -10} {1, -15} {2, -10}", rows[0], rows[1], rows[2]);
            }
            Console.WriteLine();
        }

        public static bool Delete()
        {
            Console.Write("Įveskite ligoninės pavadinimą: ");
            string pavadinimas = Console.ReadLine();
            foreach(DataRow rows in ManualDbConnection.Select("SELECT * FROM dbo.Ligonine").Rows)
            {
                if (pavadinimas.Equals(rows[0].ToString()))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM dbo.Ligonine WHERE Pavadinimas=@pavadinimas");
                    command.Parameters.AddWithValue("@pavadinimas", pavadinimas);
                    if (ManualDbConnection.Change(command))
                    {
                        Console.WriteLine("Success!");
                        return true;
                    }
                    Console.WriteLine("Error!");
                    return false;
                }
            }
            Console.WriteLine("Tokios ligoninės nėra!");
            return false;
        }

        public static bool Insert()
        {
            Console.Write("Norimas pavadinimas: ");
            string pavadinimas = Console.ReadLine();
            Console.Write("Norimas adresas: ");
            string adresas = Console.ReadLine();
            Console.Write("Norimas biudžetas: ");
            int biudzetas = int.Parse(Console.ReadLine());
            SqlCommand command = new SqlCommand("INSERT INTO dbo.Ligonine VALUES(@pavadinimas, @adresas, @biudzetas)");
            command.Parameters.AddWithValue("@pavadinimas", pavadinimas);
            command.Parameters.AddWithValue("@adresas", adresas);
            command.Parameters.AddWithValue("@biudzetas", biudzetas);
            if (ManualDbConnection.Change(command))
            {
                Console.WriteLine("Success!");
                return true;
            }
            Console.WriteLine("Error!");
            return false;

        }

        public static bool Update()
        {
            Console.Write("Įveskite norimos keisti ligoninės pavadinimą: ");
            string pavadinimas = Console.ReadLine();
            foreach (DataRow rows in ManualDbConnection.Select("SELECT * FROM dbo.Ligonine").Rows)
            {
                if (pavadinimas.Equals(rows[0].ToString()))
                {
                    Console.Write("Dabartinis ligoninės biudžetas: {0}. Norimas naujas biudžetas: ", rows[2].ToString());
                    int biudzetas = int.Parse(Console.ReadLine());
                    SqlCommand command = new SqlCommand("UPDATE dbo.Ligonine SET Biudzetas=@biudzetas WHERE Pavadinimas=@pavadinimas");
                    command.Parameters.AddWithValue("@biudzetas", biudzetas);
                    command.Parameters.AddWithValue("@pavadinimas", pavadinimas);
                    if (ManualDbConnection.Change(command))
                    {
                        Console.WriteLine("Success!");
                        return true;
                    }
                    Console.WriteLine("Error!");
                    return false;
                }
            }
            Console.WriteLine("Tokios ligoninės nėra!");
            return false;
        }
    }
}
