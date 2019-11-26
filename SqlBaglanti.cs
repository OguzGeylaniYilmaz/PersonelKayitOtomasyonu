using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelKayıtOtomasyonu
{
    class SqlBaglanti
    {
        public SqlConnection connection()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DbPersonelKayıtVT;Integrated Security=True");
            conn.Open();
            return conn;
        }
    }
}
