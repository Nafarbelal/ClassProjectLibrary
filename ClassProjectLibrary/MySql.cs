using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassProjectLibrary
{
    public abstract class MySql
    {
        string Server;
        string BD;
        string User;
        String Pass;
        MySqlConnection con;
        MySqlDataReader rs;
        MySqlCommand st;

        protected MySql(string bd, string uid, string password, string server)
        {
            Server = server;
            BD = bd;
            User = uid;
            Pass = password;
            con = new MySqlConnection(connectionString: "Server=" + Server + "; database=" + BD + "; UID=" + User + "; password=" + Pass);
        }
        public List<Dictionary<string, string>> Get(string sql)
        {
            List<Dictionary<string, string>> l = null;

            st = con.CreateCommand();

            st.CommandText = sql;

            try
            {
                con.Open();

                rs = st.ExecuteReader();

                l = new List<Dictionary<string, string>>();

                Dictionary<string, string> row;

                while (rs.Read())
                {
                    row = new Dictionary<string, string>();
                    for (int i = 0; i < rs.FieldCount; i++)
                    {
                        row.Add(rs.GetName(i), rs.GetValue(i).ToString());
                    }
                    l.Add(row);
                }

                con.Close();
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro" + erro);
                con.Close();
            }
            return l;
        }



        public int Up(string sql)
        {
            st = con.CreateCommand();

            st.CommandText = sql;

            try
            {
                con.Open();
                if (st.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return 1;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro" + erro);
                
            }

            con.Close();
            return 0;

        }

        public string Server1 { get => Server; set => Server = value; }
        public string BD1 { get => BD; set => BD = value; }
        public string User1 { get => User; set => User = value; }
        public string Pass1 { get => Pass; set => Pass = value; }
        public MySqlConnection Con { get => con; set => con = value; }
        public MySqlDataReader Rs { get => rs; set => rs = value; }
        public MySqlCommand St { get => st; set => st = value; }


    }
}