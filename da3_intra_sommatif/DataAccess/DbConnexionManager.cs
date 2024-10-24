using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace da3_intra_sommatif.DataAccess
{
    public class DbConnexionManager
    {

        private static SqlConnection? connexion;
        private static String connexionString = "Server= .\\SQL2022DEV;Database=da3_intra_sommatif;Integrated Security=true;TrustServerCertificate=true;";

        public static SqlConnection GetConnection() 
        {
            return connexion ??= new SqlConnection(connexionString);
        }
    }
}
