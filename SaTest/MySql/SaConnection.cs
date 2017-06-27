using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaTest.MySql
{
    public class SaConnection
    {
        private static string dbHost = "127.0.0.1";
        private static string dbUser = "root";
        private static string dbPass = "zone3210";
        private static string dbName = "sa";

        public string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
    }
}