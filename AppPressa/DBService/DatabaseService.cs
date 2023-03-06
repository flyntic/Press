using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AppPressa.DBService
{
    public class DatabaseService
    {
        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=PressDB;Integrated security=true;");
        SqlDataAdapter adapter;
        public DataSet data = new DataSet();

        private void UpdateRemoveAdd(string nametable, Dictionary<string,SqlDbType> list)
        {
           SqlCommand command = new SqlCommand();
            //1
           string strcommand = "update " + nametable + " set " ;
            list.Keys.ToList().ForEach(x =>
            {
                strcommand += x + "=@" + x + "  ,";
                string newp = "@" + x;
                command.Parameters.Add(newp, list[x]);
                command.Parameters[newp].SourceColumn =x;
                command.Parameters[newp].SourceVersion = DataRowVersion.Current;

            });
            strcommand=strcommand.Remove(strcommand.Length-2,2);
            strcommand += " WHERE ID = @ID";

            command.CommandText = strcommand;
            command.Connection = connection;


            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].SourceColumn = "id";
            command.Parameters["@ID"].SourceVersion = DataRowVersion.Original;
           
            adapter.UpdateCommand = command;
            //2
            command = new SqlCommand(
             "DELETE "+nametable+" WHERE ID = @ID", connection);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].SourceColumn = "id";
            command.Parameters["@ID"].SourceVersion = DataRowVersion.Original;

            adapter.DeleteCommand = command;

            //3
            command = new SqlCommand();

             strcommand = "Insert into " + nametable + " values(";
            list.Keys.ToList().ForEach(x =>
            {
                string newp = "@" + x;
                strcommand += newp + "  ,";
                command.Parameters.Add(newp, list[x]);
                command.Parameters[newp].SourceColumn = x;
                command.Parameters[newp].SourceVersion = DataRowVersion.Current;

            });
            strcommand = strcommand.Remove(strcommand.Length - 2, 2);
            strcommand += " )";

            command.CommandText = strcommand;
            command.Connection = connection;


            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].SourceColumn = "id";
            command.Parameters["@ID"].SourceVersion = DataRowVersion.Original;

            adapter.InsertCommand = command;
        }

        public enum CollectDate
        {
            AllPublications,
            All_Releases,
            DefPublication,
            DefRelease,
            publication,
            publishing_company,
            edition,
            themes,
            frequency,
            dregions

        };

        public DatabaseService()
        {
            string str = "execute description_all_publications;";
            str += "execute Description_All_Releases;";
            str += "select * from DefineAllPublication;";
            str += "select * from DefineAllRelease;";
            str += "select * from publication;";
            str += "select * from publishing_company;";
            str += "select * from edition;";
            str += "select * from themes;";
            str += "select * from frequency;";
            str += "select * from distribution_region;";
            

            adapter = new SqlDataAdapter(str, connection);
            adapter.Fill(data);

        }
        
        public string Save(int index)
        { 
            try
            {
               
                DataTable ds = data.Tables[index];
                adapter.Update(ds);
            }  
            catch 
            {
                return "Не удалось сохранить изменения в базе"; 
            }
            return null;
        }

        public void setUpdateRemoveAdd(int index)
        {
            switch ((CollectDate)index)
            {
                case CollectDate.publication: UpdateRemoveAdd("Publication",new Dictionary<string, SqlDbType>()
                                              { { "name",SqlDbType.VarChar },{ "description",SqlDbType.Text } });  break;
                case CollectDate.edition: UpdateRemoveAdd("Edition", new Dictionary<string, SqlDbType>()
                                              { { "count", SqlDbType.Int }}); break;
                case CollectDate.themes: UpdateRemoveAdd("themes", new Dictionary<string, SqlDbType>()
                                              { { "name", SqlDbType.VarChar }, { "description", SqlDbType.Text } }); break;
                case CollectDate.publishing_company: UpdateRemoveAdd("publishing_company", new Dictionary<string, SqlDbType>()
                                              { { "name", SqlDbType.VarChar }, { "city", SqlDbType.VarChar },
                                                { "legal_address", SqlDbType.Text }, { "description", SqlDbType.Text },
                                                { "phone", SqlDbType.VarChar }, { "director", SqlDbType.Text }}); break;

                case CollectDate.dregions:    UpdateRemoveAdd("distribution_region", new Dictionary<string, SqlDbType>()
                                              { { "name", SqlDbType.VarChar } }); break;
                case CollectDate.frequency:
                    UpdateRemoveAdd("frequency", new Dictionary<string, SqlDbType>()
                                              { { "short_description", SqlDbType.VarChar }, 
                                                 { "long_description", SqlDbType.VarChar }  }); break;

            }
        }

        public void Update()
        {
            data.Clear();
            adapter.Fill(data);
        }

    }
}
