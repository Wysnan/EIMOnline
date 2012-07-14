using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.EF.Migrations
{
    public class MigrationsHelp
    {
        public delegate void SqlMethod(string commandText, bool suppressTransaction = false, object anonymousArguments = null);

        public static void InitDB(SqlMethod sqlMethod)
        {
            var migrationDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Wysnan.EIMOnline.EF\Migrations\InitialScript");

            var dataDir = migrationDir + "/Data";
            var storedProceduresDir = migrationDir + "/StoredProcedures";

            var files_data = Directory.GetFiles(dataDir);
            var files_StoredProcedures = Directory.GetFiles(storedProceduresDir);

            string commandText = null;
            //初始化基础数据
            foreach (var item in files_data)
            {
                commandText = System.IO.File.ReadAllText(System.IO.Path.Combine(dataDir, item));
                sqlMethod(commandText);
            }
            //初始化存储过程
            foreach (var item in files_StoredProcedures)
            {
                commandText = System.IO.File.ReadAllText(System.IO.Path.Combine(storedProceduresDir, item));
                sqlMethod(commandText);
            }
            //初始化测试数据
            commandText = System.IO.File.ReadAllText(System.IO.Path.Combine(migrationDir, "InitialData.sql"));
            sqlMethod(commandText);
        }

        public static void AddLookUp(SqlMethod sqlMethod,params Lookup[] lookups)
        {
            if (lookups != null)
            {
                StringBuilder sql = new StringBuilder();
                foreach (var item in lookups)
                {
                    sql.AppendFormat("INSERT INTO zMetaLookup( Name, Code ,EnumCode,SystemStatus)VALUES (N'{0}','{1}','{2}',0); ", item.Name, item.Code, item.EnumCode);
                }
                string commandText = sql.ToString();
                if (commandText.Length > 0)
                {
                    sqlMethod(commandText);
                }
            }
        }
    }
}
