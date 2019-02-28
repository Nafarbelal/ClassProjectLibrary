using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassProjectLibrary
{
    public class RequestCondition
    {
        string Param;

        public string Param1 { get => Param; set => Param = value; }

        public RequestCondition(string p)
        {
            Param = p;
        }

        public string Equal(object value)
        {            
            return Param1 + "='" + value.ToString() + "'";
        }

        private string ForINnotIN(object[] value)
        {
            return null;
        }

        public string GreaterThan(object value)
        {
            return Param1 + ">'" + value.ToString() + "'";
        }

        public string GreaterThanOrEqual(object[] value)
        {
            return Param1 + ">='" + value.ToString() + "'";
        }

        public string IN(object[] value)
        {
            //format giveen array as 
            //param in ('val1','val2','val3')

            string cond=Param+" IN (";
            foreach(var a in value)
            {
                cond += "'" +a.ToString()+ "',";
            }
            //remove the last , from cond

            cond=cond.Remove(cond.Length - 1);

            cond += ")";

            return cond;
        }

        public string LessThan(object value)
        {
            return Param1 + "<'" + value.ToString() + "'";
        }

        public string LessThanOrEqual(object value)
        {
            return Param1 + "<='" + value.ToString() + "'";
        }

        public string LikeCenter(object value)
        {
            return Param1 + " like '%" + value.ToString() + "%'";
        }

        public string LikeFirst(object value)
        {
            return Param1 + " like '" + value.ToString() + "%'";
        }

        public string LikeLast(object value)
        {
            return Param1 + " like '%" + value.ToString() + "'";
        }

        public string NotEqual(object value)
        {
            return Param1 + "<> '" + value.ToString() + "'";
        }

        public string NotIN(object[] value)
        {
            //format giveen array as 
            //param in ('val1','val2','val3')

            string cond = Param + " NOT IN (";
            foreach (var a in value)
            {
                cond += "'" + a.ToString() + "',";
            }
            //remove the last , from cond

            cond = cond.Remove(cond.Length - 1);

            cond += ")";

            return cond;

        }


    }
}