using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Baithuctapck
{
    class DataAccess
    {
        private static string DuongDan = @"Data Source=.\SQLEXPRESS;Initial Catalog=db_thuctap;Integrated Security=True";
        private static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(DuongDan);
        }
        public static DataTable GetTable(string sql)
        {
            SqlConnection KetNoi = TaoKetNoi();
            KetNoi.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, KetNoi);
            DataTable b = new DataTable();
            ad.Fill(b);
            KetNoi.Close();
            ad.Dispose();
            return b;
        }
        public static void AddEditDelete(string sql)
        {
            SqlConnection con = TaoKetNoi();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }
        public static string LayMotGT(string sql)
        {
            SqlConnection con = TaoKetNoi();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            object rs = cmd.ExecuteScalar();
            con.Close();
            cmd.Dispose();
            if (rs != null)
                return rs.ToString();
            else
                return "";
        }
        public static bool ReadRoles(string stored)
        {
            SqlConnection con = TaoKetNoi();
            con.Open();
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            string result = cmd.ExecuteScalar().ToString();
            if (result == "1")
                return true;
            return false;
        }
        public static string DataReader(string sql)
        {
            string data = "";
            SqlConnection con = TaoKetNoi();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                data = read.GetString(0);
            }
            return data;
        }
        public static string CountData(string sql)
        {
            string data = " ";
            SqlConnection con = TaoKetNoi();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            data = cmd.ExecuteScalar().ToString();
            return data;
        }
        public static List<string> cbBoxAddData(string sql)
        {
            List<string> cb = new List<string>();
            SqlConnection con = TaoKetNoi();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                string value = read.GetString(0);
                cb.Add(value);

            }
            read.Close();
            return cb;
        }
    }
}
