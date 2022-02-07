using Oracle.ManagedDataAccess.Client;
using System;

namespace OracleCrud.ConsoleApp
{
    /// <summary>
    /// Code Backend:
    /// + Design PERSON table (ID, FULLNAME)
    /// + Connect to Oracle database
    /// + Do CRUD with OracleCommand using Oracle.ManagedDataAccess 18.3.0
    /// + CRUD: Creat, Read, Update, Delete
    /// </summary>
    internal class Program
    {
        private static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }

        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            //throw new Exception("Kaboom");

            //Server: 149.28.144.14
            //Port: 1521
            //Service: ORCL
            //User: CooliedNikkemateDb
            //Pass: CooliedNikkemateDb

            string connString = "DATA SOURCE=149.28.144.14/ORCL;USER ID=CooliedNikkemateDb;PASSWORD=CooliedNikkemateDb;Min Pool Size=5;Decr Pool Size=10;PERSIST SECURITY INFO=True;";
            //string connString = "DATA SOURCE=10.0.64.147/xe;USER ID=ixfds;PASSWORD=ixfds;Min Pool Size=5;Decr Pool Size=10;PERSIST SECURITY INFO=True;";

            //(C)reate in CRUD
            string sqlInsert = "INSERT INTO \"COOLIEDNIKKEMATEDB\".\"PERSON\" (ID, FULLNAME) VALUES (:ID, :FULLNAME)";
            using (var conn = new OracleConnection(connString))
            {
                conn.Open();
                using (var cmd = new OracleCommand(sqlInsert, conn))
                {
                    string idParam = "DAT";
                    string fullNameParam = "にはNULLは挿入できません。";
                    cmd.Parameters.Add(":ID", idParam);
                    cmd.Parameters.Add(":FULLNAME", fullNameParam);
                    cmd.ExecuteNonQuery(); //Write data
                    //cmd.ExecuteReader(); //Read data
                }
            }

            //(R)reate in CRUD
            //TODO: LOC, DAT, DUC

            //(U)reate in CRUD
            //TODO: LOC, DAT, DUC

            //(D)reate in CRUD
            //TODO: LOC, DAT, DUC
        }
    }
}