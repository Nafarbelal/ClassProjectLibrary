using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace ClassProjectLibrary
{
    public abstract class Dao : MySql
    {
        public string[] param_co;
        string Table;

        public Dao(string table, string db, string user, string pass, string server) : base(db, user, pass, server)
        {
            param_co = new string[]{ db, user, pass, server};

            Table = table;
        }

        public List<Dictionary<string, string>> Select(string conditions)
        {
            string sql;

            if (conditions.Length == 0) sql = "select * from " + Table;
            else sql = "select * from " + Table + " where " + conditions;

            return Get(sql);
        }
        public int insert(Dictionary<string, string> Data)
        {
            string sql = "";
            string att="";
            string values="";

            sql = "insert into " + Table;

            foreach (KeyValuePair<string, string> entry in Data)
            {
                att += entry.Key + ",";
                values += "'" + entry.Value + "',";
            }

            att = att.Remove(att.Length - 1);
            values = values.Remove(values.Length - 1);

            sql = sql + "(" + att + ") values (" + values + ")";
            
            return Up(sql);
        }

        public int update(Dictionary<string, string> Data, string Conditions)
        {
            string sql = "update " + Table + " set ";

            foreach (KeyValuePair<string, string> entry in Data)
            {
                sql += entry.Key + "='" + entry.Value + "',";
            }

            sql = sql.Remove(sql.Length - 1);

            sql += " where " + Conditions;

            return Up(sql);
        }

        public int Delete(string Conditions)
        {
            string sql = "delete from " + Table + " where " + Conditions;

            return Up(sql);
        }

    }
}