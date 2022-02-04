using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace accountBook
{

    public class CMysql
    {
        private void CrudSql(string Query, string 메세지)
        {
            string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
            MySqlConnection con = new MySqlConnection(Connect);
            MySqlCommand Comm = new MySqlCommand(Query, con);
            MySqlDataReader Read;
            con.Open();
            Read = Comm.ExecuteReader();
            MessageBox.Show(메세지);
            con.Close();
        }


    }
}
