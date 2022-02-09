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
            //string sqlInsert = "INSERT INTO \"COOLIEDNIKKEMATEDB\".\"PERSON\" (ID, FULLNAME) VALUES (:ID, :FULLNAME)";
            //using (var conn = new OracleConnection(connString))
            //{
            //    conn.Open();
            //    using (var cmd = new OracleCommand(sqlInsert, conn))
            //    {
            //        string idParam = "DAT";
            //        string fullNameParam = "にはNULLは挿入できません。";
            //        cmd.Parameters.Add(":ID", idParam);
            //        cmd.Parameters.Add(":FULLNAME", fullNameParam);
            //        cmd.ExecuteNonQuery(); //Write data
            //        //cmd.ExecuteReader(); //Read data
            //    }
            //}

            //(R)reate in CRUD (get all)
            //TODO: LOC, DAT, DUC
            //string sqlRead = "SELECT * FROM \"COOLIEDNIKKEMATEDB\".\"PERSON\" ";
            //using (var conn = new OracleConnection(connString))
            //{
            //    conn.Open();
            //    using (var cmd = new OracleCommand(sqlRead, conn))
            //    {
            //        OracleDataReader odr = cmd.ExecuteReader(); //Read data
            //        while (odr.Read())
            //        {
            //            var id = odr["ID"] == DBNull.Value ? string.Empty : odr["ID"];
            //            var fullName = odr["FULLNAME"] == DBNull.Value ? string.Empty : odr["FULLNAME"];
            //            var salary = odr["SALARY"] == DBNull.Value ? string.Empty : odr["SALARY"];
            //            var dob = odr["DOB"] == DBNull.Value ? string.Empty : odr["DOB"];
            //            var department = odr["DEPARTMENT"] == DBNull.Value ? string.Empty : odr["DEPARTMENT"];
            //            var note = odr["NOTE"] == DBNull.Value ? string.Empty : odr["NOTE"];
            //            Console.WriteLine($"{id}, {fullName}, {dob.ToString()}, {department}, {note}");
            //        }
            //        Console.ReadKey();
            //    }
            //}


            //(R)reate in CRUD (get with conditional)
            //TODO: LOC, DAT, DUC
            //string sqlRead2 = "SELECT * FROM \"COOLIEDNIKKEMATEDB\".\"PERSON\" WHERE ID = :ID ";
            //using (var conn = new OracleConnection(connString))
            //{
            //    conn.Open();
            //    using (var cmd = new OracleCommand(sqlRead2, conn))
            //    {
            //        string idParam = "DAT";
            //        cmd.Parameters.Add(":ID", idParam);
            //        OracleDataReader odr = cmd.ExecuteReader(); //Read data
            //        while (odr.Read())
            //        {
            //            var id = odr["ID"] == DBNull.Value ? string.Empty : odr["ID"];
            //            var fullName = odr["FULLNAME"] == DBNull.Value ? string.Empty : odr["FULLNAME"];
            //            var salary = odr["SALARY"] == DBNull.Value ? string.Empty : odr["SALARY"];
            //            var dob = odr["DOB"] == DBNull.Value ? string.Empty : odr["DOB"];
            //            var department = odr["DEPARTMENT"] == DBNull.Value ? string.Empty : odr["DEPARTMENT"];
            //            var note = odr["NOTE"] == DBNull.Value ? string.Empty : odr["NOTE"];
            //            Console.WriteLine($"{id}, {fullName}, {dob.ToString()}, {department}, {note}");
            //        }
            //        Console.ReadKey();
            //    }
            //}

            //(R)reate in CRUD (get with sort)
            //TODO: LOC, DAT, DUC
            //string sqlRead3 = "SELECT * FROM \"COOLIEDNIKKEMATEDB\".\"PERSON\" ORDER BY ID ";
            //using (var conn = new OracleConnection(connString))
            //{
            //    conn.Open();
            //    using (var cmd = new OracleCommand(sqlRead3, conn))
            //    {
            //        OracleDataReader odr = cmd.ExecuteReader(); //Read data
            //        while (odr.Read())
            //        {
            //            var id = odr["ID"] == DBNull.Value ? string.Empty : odr["ID"];
            //            var fullName = odr["FULLNAME"] == DBNull.Value ? string.Empty : odr["FULLNAME"];
            //            var salary = odr["SALARY"] == DBNull.Value ? string.Empty : odr["SALARY"];
            //            var dob = odr["DOB"] == DBNull.Value ? string.Empty : odr["DOB"];
            //            var department = odr["DEPARTMENT"] == DBNull.Value ? string.Empty : odr["DEPARTMENT"];
            //            var note = odr["NOTE"] == DBNull.Value ? string.Empty : odr["NOTE"];
            //            Console.WriteLine($"{id}, {fullName}, {dob.ToString()}, {department}, {note}");
            //        }
            //        Console.ReadKey();
            //    }
            //}

            //(R)reate in CRUD (get with group by)
            //TODO: LOC, DAT, DUC
            string sqlRead4 = "SELECT COUNT(ID), DEPARTMENT FROM \"COOLIEDNIKKEMATEDB\".\"PERSON\" GROUP BY DEPARTMENT ";
            using (var conn = new OracleConnection(connString))
            {
                conn.Open();
                using (var cmd = new OracleCommand(sqlRead4, conn))
                {
                    OracleDataReader odr = cmd.ExecuteReader(); //Read data
                    while (odr.Read())
                    {
                       
                        var department = odr["DEPARTMENT"] == DBNull.Value ? "NO DEPARTMENT" : odr["DEPARTMENT"];
                        var numberOfperson = odr["COUNT(ID)"] == DBNull.Value ? string.Empty : odr["COUNT(ID)"];
                        Console.WriteLine($"{department}, {numberOfperson}");
                    }
                    Console.ReadKey();
                }
            }

            //(U)reate in CRUD
            //TODO: LOC, DAT, DUC
            //string sqlUpdate = "UPDATE \"COOLIEDNIKKEMATEDB\".\"PERSON\" SET FULLNAME = :FULLNAME, DOB = :DOB WHERE ID = :ID ";
            //using (var conn = new OracleConnection(connString))
            //{
            //    conn.Open();
            //    using (var cmd = new OracleCommand(sqlUpdate, conn))
            //    {
            //        string idParam = "DAT";
            //        string fullNameParam = "NGUYEN VAN C";
            //        cmd.Parameters.Add(":FULLNAME", fullNameParam);
            //        cmd.Parameters.Add(":DOB", new DateTime(1998, 5, 3));
            //        cmd.Parameters.Add(":ID", idParam);
            //        cmd.ExecuteNonQuery(); //Write data
            //    }
            //}
            //(D)reate in CRUD
            //TODO: LOC, DAT, DUC
            //string sqlDelete = "DELETE FROM COOLIEDNIKKEMATEDB.PERSON WHERE ID = :ID ";
            //using (var conn = new OracleConnection(connString))
            //{
            //    conn.Open();
            //    using (var cmd = new OracleCommand(sqlDelete, conn))
            //    {
            //        string idParam = "DAT";
            //        cmd.Parameters.Add(":ID", idParam);
            //        cmd.ExecuteNonQuery(); //Write data
            //    }
            //}
        }
    }
}