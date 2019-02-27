using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace ClassProjectLibrary
{
    public class Dao : MySql
    {
        public string[] param_co;
        string Table;

        public Dao(string table, string db, string user, string pass, string server) : base(db, user, pass, server)
        {
            Table = table;
        }

        public List<Dictionary<string, string>> Select(string conditions)
        {
            string sql;

            if (conditions.Length == 0) sql = "select * from " + Table;
            else sql = "select * from " + Table + " where " + conditions;

            return Get(sql);
        }

        public int Update(string action, List<Dictionary<string, string>> Data, string Conditions)
        {
            string sql = "";
            string att;
            string values;

            action = action.ToLower();

            switch (action)
            {
                case "insert":
                    sql = "insert into " + Table;
                    foreach (var data in Data)
                    {
                        att = "";
                        values = "";
                        foreach (KeyValuePair<string, string> entry in data)
                        {
                            att += entry.Key + ",";
                            values += "'" + entry.Value + "',";
                        }

                        att = att.Remove(att.Length - 1);
                        values = values.Remove(values.Length - 1);
                        Up(sql + "(" + att + ") values (" + values + ")");
                    }
                    break;

                case "update":
                    foreach (var data in Data)
                    {
                        sql = "update " + Table + " set ";
                        foreach (KeyValuePair<string, string> entry in data)
                        {
                            sql += entry.Key + "='" + entry.Value + "',";
                        }

                        sql = sql.Remove(sql.Length - 1);
                        sql += " where " + Conditions;
                        Up(sql);
                    }
                    break;

                case "delete":
                    sql = "delete from " + Table + " where " + Conditions;
                    Up(sql);
                    break;

                default: return -1;
            }

            return 1;

            //update table set DATA where conditions 
            //delete from table where 
        }
    }
}