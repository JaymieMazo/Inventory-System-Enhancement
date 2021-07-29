using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace BOI_Inventory_System
{
    class SysCon
    {

        //for primary connection

        public static string uid = "sa";
        public static string pwd = "boi123";

       //ACTUAL DATABASE
        //private static string ConStr = "Data Source = BOI-DB1; Initial Catalog= BIS_DBENG; User Id = " + uid + " ; Password = " + pwd + "";
        

        //testc DATABASE
        private static string ConStr = @"Data Source = jdcmazo; Initial Catalog= BIS_DBENG; User Id = " + uid + " ; Password = " + pwd + "";


        //////for secondary connection
        //public static string uid = "boigsd";
        //public static string pwd = "";
        //////private static string ConStr = "Data Source = BOI_GSD(SQL SERVER 13.0.4466.4-BOI-GSD\boigsd); Initial Catalog= BIS_DBENG; User Id = " + uid + " ; Password = " + pwd + "";
        //private static string ConStr = "Data Source = 52.230.124.22; Initial Catalog= BIS_DBENG; User Id = " + uid + " ; Password = " + pwd + "";
        //private static string ConStr = "Server=tcp:[52.230.124.22].database.windows.net;Database=BIS_DBENG;User ID = boigsd@52.230.124.22;Password=pass@word1boi; Trusted_Connection=False;Encrypt=True;MultipleActiveResultSets=True";

        //// localhost
        // public static string uid = "DTI-BOI\\AJLegaspi";
        // public static string pwd = "";
        // private static string ConStr = "Data Source = AJLEGASPI-HP\\SQLEXPRESS01; Initial Catalog= BIS_DBENG;Integrated Security = True; User Id = " + uid + " ; Password = " + pwd + "";

        //// connect to temporary Server
        // public static string uid = "admin";
        // public static string pwd = "admin0101";
        // private static string ConStr = "Data Source =ITD04\\SQLEXPRESS; Initial Catalog= BIS_DBENG;User Id = " + uid + " ; Password = " + pwd + "";

        public static SqlConnection SystemConnect = new SqlConnection(ConStr);

        public static void OpenConnection()
        {
            if (SystemConnect.State == ConnectionState.Closed)
            {
                SystemConnect.Open();
            }
        }



        public static void CloseConnection()
        {
            if (SystemConnect.State == ConnectionState.Open)
            {
                SystemConnect.Close();
            }
        }
    }
}

  