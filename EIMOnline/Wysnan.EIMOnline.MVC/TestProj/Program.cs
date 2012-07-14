using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.EF.Migrations;
using System.IO;


namespace TestProj
{
    class Program
    {
        static void Main(string[] args)
        {
            var migrationDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Migrations\InitialScript");
            var ddlSqlFiles = new string[] { "InitialPromysSPandFN.sql", "InitialPromysViews.sql" };

            var dataDir = migrationDir + "/Data";
            var storedProceduresDir = migrationDir + "/StoredProcedures";

            var files_data = Directory.GetFiles(dataDir);
            var files_StoredProcedures = Directory.GetFiles(storedProceduresDir);

            var splitter = new string[] { "\r\nGO\r\n" };
            string commandText = null;
            foreach (var item in files_data)
            {
                commandText = System.IO.File.ReadAllText(System.IO.Path.Combine(dataDir, item));
                //Sql(commandText);
            }
            foreach (var item in files_StoredProcedures)
            {
                commandText = System.IO.File.ReadAllText(System.IO.Path.Combine(storedProceduresDir, item));
                //Sql(commandText);
            }
        }
    }
}
