using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraMap;

namespace LDSong.Libs
{
    public class clsSQL
    {
        //Data Source=10.53.0.7\sql2008;Initial Catalog=CCDC_Chuan;Persist Security Info=True;User ID=ccdc;Password=7894560
        private static SqlConnection connect = new SqlConnection();
        private static DataTable tbl;
        //private string SqlString;

        public clsSQL()
        {
            Close();
            connect.ConnectionString = LDSong.Properties.Settings.Default.connect;
        }

        private void Open()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
        }

        private void Close()
        {
            if (connect.State != ConnectionState.Closed)
            {
                connect.Close();
            }
        }

        public VectorItemsLayer getItemLocation(string _MaDV, int _IDPTDien)
        {
            SqlGeometryDataAdapter adapter = new SqlGeometryDataAdapter() {
                ConnectionString  = connect.ConnectionString,
                SqlText = string.Format( "SELECT TOA_DO,MA_PTDIEN FROM M_VITRI WHERE MA_DVQLY LIKE '{0}' AND ID_PTDIEN = {1}",_MaDV,_IDPTDien),
                SpatialDataMember = "TOA_DO"
            };
            VectorItemsLayer layer = new VectorItemsLayer()
            {
                Data = adapter,
                ShapeTitlesPattern = "{MA_PTDIEN}"
            };
            return layer;
        }

        public DataTable Select(string sqlString)
        {
            tbl = new DataTable();
            Open();
            SqlDataAdapter adap = new SqlDataAdapter(sqlString, connect);
            adap.Fill(tbl);
            Close();
            return tbl;
        }
        public object SelectColumn(string sqlString)
        {
            tbl = new DataTable();
            Open();
            SqlDataAdapter adap = new SqlDataAdapter(sqlString, connect);
            adap.Fill(tbl);
            Close();
            return tbl.Rows[0][0];//.ToString();
        }
        //Thuc thi cau lenh Update, Insert, Delete
        public void ExcuteSQL(string sql)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Close();
        }

        public DataTable LoadData(string sql)
        {
            Open();
            SqlCommand command = new SqlCommand(sql,connect);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable dt = new DataTable();
            tbl = new DataTable();
            adapter.Fill(tbl);
            Close();
            return tbl;
        }
        
        public DataTable LoadData(string sql,string[]name, object[]value)
        {
            if (name.Count() != value.Count()) return null;
            Open();
            SqlCommand command = new SqlCommand(sql, connect);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            for (int i = 0; i < name.Count(); i++)
            {
                command.Parameters.AddWithValue(name[i],value[i]);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            tbl = new DataTable();
            adapter.Fill(tbl);
            Close();
            return tbl;
        }
        
        public int UpdateData(string sql)
        {
            Open();
            SqlCommand command = new SqlCommand(sql,connect);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            int i = command.ExecuteNonQuery();
            Close();
            return i;
        }

        public int UpdateData(string sql, string[] name, object[] value)
        {
            if (name.Count() != value.Count()) return -1;
            Open();
            SqlCommand command = new SqlCommand(sql, connect);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            for (int i = 0; i < name.Count(); i++)
            {
                command.Parameters.AddWithValue(name[i], value[i]);
            }
            int n = command.ExecuteNonQuery();
            Close();
            return n;
        }

        public bool UpdateData(string sql, string[] name, object[] value,bool ret = false)
        {
            if(name.Count() != value.Count()) return false;
            Open();
            SqlCommand command = new SqlCommand(sql, connect);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            for (int i = 0; i < name.Count(); i++)
            {
                command.Parameters.AddWithValue(name[i], value[i]);
            }
            SqlParameter p = command.Parameters.Add("@bRet", SqlDbType.Bit);
            p.Direction = ParameterDirection.Output;                
            command.ExecuteNonQuery();
            bool _ret = bool.Parse(p.Value.ToString());            
            Close();
            return _ret;
        }

        public void loadFromPROC(string sStoreName, ref SqlParameter[] sqlParams)
        {           
            Open();
            SqlCommand command = new SqlCommand(sStoreName, connect);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            for (int i = 0; i < sqlParams.Count(); i++)
            {
                command.Parameters.Add(sqlParams[i]);
            }
            command.ExecuteReader().Close();
            Close();
        }
    }
}
