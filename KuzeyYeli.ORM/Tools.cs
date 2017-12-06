using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyYeli.ORM
{
    class Tools
    {
        private static SqlConnection baglanti=new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
         

        public static SqlConnection Baglanti
        {
            get { return baglanti; }
            
        }

    }
}
