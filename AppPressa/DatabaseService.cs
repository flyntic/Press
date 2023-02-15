using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AppPressa
{
    public class DatabaseService
    {
        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Press;Integrated security=true;");
        SqlDataAdapter adapter;
        public DataSet data = new DataSet();

        public enum CollectDate
        {
            AllPublications,
            All_Releases,
          //  Publication,
          //  Themes,
          //  Publishing_company,
          //  Edition,
          //  Frequency,
          //  Cities,
          //  Regions,
          //  All_prices

        };
        public DatabaseService()
        {
            string str = "execute Select_from_date @dt =" + " '" + DateTime.Now.ToString("yyyy-MM-dd") + "';";
            str += "execute select_release;";
          //  str += "select name from Publication;";
          //  str += "select name from Themes;";
          //  str += "select name from Publishing_company;";
          //  str += "select count from Edition;";
          //  str += "select description from Frequency;";
          //  str += "select distinct city from Publishing_company;";
          //  str += "select region from Distribution_region;";
            //str += "select distinct price_one from All_prices;";



            adapter = new SqlDataAdapter(str, connection);
            adapter.Fill(data);

        }


    }
}
