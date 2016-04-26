using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblHardware : ICrudable<Hardware>
    {
        private string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["CvoInventarisDBConnection"].ConnectionString;
        }

        public int Create(Hardware t)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblHardwareInsert", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCpu", t.IdCpu);
                command.Parameters.AddWithValue("@idDevice", t.IdDevice);
                command.Parameters.AddWithValue("@idGrafischeKaart", t.IdGrafischeKaart);
                command.Parameters.AddWithValue("@idHarddisk", t.IdHarddisk);
                SqlParameter id = new SqlParameter("@idHardware", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                command.Parameters.Add(id);
                try
                {
                    con.Open();
                    result = command.ExecuteNonQuery();
                }
                catch   { }
            }

            return result;
        }

        public List<Hardware> GetAll()
        {
            List<Hardware> hardwares = new List<Hardware>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblHardwareReadAll", con);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Hardware hardware = new Hardware();
                            hardware.IdHardware = (int)reader["idHardware"];
                            hardware.IdCpu = (int)reader["idCpu"];
                            hardware.IdDevice = (int)reader["idDevice"];
                            hardware.IdGrafischeKaart = (int)reader["idGrafischeKaart"];
                            hardware.IdHarddisk = (int)reader["idHarddisk"];
                            hardware.CpuMerk = reader["cm"].ToString();
                            hardware.DeviceMerk = reader["dm"].ToString();
                            hardware.GrafischeKaartMerk = reader["gm"].ToString();
                            hardware.HarddiskMerk = reader["hm"].ToString();
                            hardwares.Add(hardware);
                        }

                    }
                }
                catch{ }
            }

            return hardwares;
        }

        public Hardware GetById(int id)
        {
            Hardware hardware = new Hardware();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblHardwareReadOne", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idHardware", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        hardware.IdHardware = (int)reader["idHardware"];
                        hardware.IdCpu = (int)reader["idCpu"];
                        hardware.IdDevice = (int)reader["idDevice"];
                        hardware.IdGrafischeKaart = (int)reader["idGrafischeKaart"];
                        hardware.IdHarddisk = (int)reader["idHarddisk"];
                        hardware.CpuMerk = reader["cm"].ToString();
                        hardware.DeviceMerk = reader["dm"].ToString();
                        hardware.GrafischeKaartMerk = reader["gm"].ToString();
                        hardware.HarddiskMerk = reader["hm"].ToString();
                    }
                }
                catch   { }
            }

            return hardware;
        }

        public bool Update(Hardware t)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblHardwareUpdate", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idHardware", t.IdHardware);
                command.Parameters.AddWithValue("@idCpu", t.IdCpu);
                command.Parameters.AddWithValue("@idDevice", t.IdDevice);
                command.Parameters.AddWithValue("@idGrafischeKaart", t.IdGrafischeKaart);
                command.Parameters.AddWithValue("@idHarddisk", t.IdHarddisk);
                try
                {
                    con.Open();
                    if(command.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }
                catch { }
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblHardwareDelete", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idHardware", id);
                try
                {
                    con.Open();
                    if (command.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }
                catch { }
            }

            return result;
        }
    }
}