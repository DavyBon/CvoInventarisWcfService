using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblCpu : ICrudable<Cpu>
    {
        #region Get Connection String
        private string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["CvoInventarisDBConnection"].ConnectionString;
        }
        #endregion

        #region CRUD TblCpu
        public Cpu GetById(int id)
        {
            Cpu cpu = new Cpu();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblCpuReadOne", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        result.Read();
                        cpu.IdCpu = (int)result["IdCpu"];
                        cpu.Merk = result["Merk"].ToString();
                        cpu.Type = result["Type"].ToString();
                        cpu.Snelheid = (int)result["Snelheid"];
                        cpu.FabrieksNummer = result["FabrieksNummer"].ToString();
                    }
                }
                catch
                {
                }
            }
            return cpu;
        }

        public List<Cpu> GetAll()
        {
            List<Cpu> cpus = new List<Cpu>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblCpuReadAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            Cpu cpu = new Cpu();
                            cpu.IdCpu = (int)result["IdCpu"];
                            cpu.Merk = result["Merk"].ToString();
                            cpu.Type = result["Type"].ToString();
                            cpu.Snelheid = (int)result["Snelheid"];
                            cpu.FabrieksNummer = result["FabrieksNummer"].ToString();
                            cpus.Add(cpu);
                        }
                    }
                }
                catch
                {
                }
            }
            return cpus;
        }

        public int Create(Cpu cpu)
        {
            int affected = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblCpuInsert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Merk", cpu.Merk);
                cmd.Parameters.AddWithValue("@Type", cpu.Type);
                cmd.Parameters.AddWithValue("@Snelheid", cpu.Snelheid);
                cmd.Parameters.AddWithValue("@FabrieksNummer", cpu.FabrieksNummer);

                try
                {
                    con.Open();
                    affected = cmd.ExecuteNonQuery();
                }
                catch
                {
                }
            }
            return affected;
        }

        public bool Update(Cpu cpu)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblCpuUpdate", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdCpu", cpu.IdCpu);
                cmd.Parameters.AddWithValue("@Merk", cpu.Merk);
                cmd.Parameters.AddWithValue("@Type", cpu.Type);
                cmd.Parameters.AddWithValue("@Snelheid", cpu.Snelheid);
                cmd.Parameters.AddWithValue("@FabrieksNummer", cpu.FabrieksNummer);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblCpuDelete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdCpu", id);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        #endregion
    }
}