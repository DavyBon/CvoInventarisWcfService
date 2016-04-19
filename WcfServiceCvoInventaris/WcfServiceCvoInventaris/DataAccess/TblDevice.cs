using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblDevice : ICrudable<Device>
    {
        #region Get Connection String
        private string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["CvoInventarisDBConnection"].ConnectionString;
        }
        #endregion

        #region CRUD TblDevice
        public Device GetById(int id)
        {
            Device dev = new Device();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblDeviceReadOne", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        result.Read();
                        dev.IdDevice = (int)result["IdDevice"];
                        dev.Merk = result["Merk"].ToString();
                        dev.Type = result["Type"].ToString();
                        dev.Serienummer = result["Serienummer"].ToString();
                        dev.IsPcCompatibel = (bool)result["IsPcCompatibel"];
                        dev.FabrieksNummer = result["FabrieksNummer"].ToString();
                    }
                }
                catch
                {
                }
            }
            return dev;
        }

        public List<Device> GetAll()
        {
            List<Device> devs = new List<Device>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblDeviceReadAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            Device dev = new Device();
                            dev.IdDevice = (int)result["IdDevice"];
                            dev.Merk = result["Merk"].ToString();
                            dev.Type = result["Type"].ToString();
                            dev.Serienummer = result["Serienummer"].ToString();
                            dev.IsPcCompatibel = (bool)result["IsPcCompatibel"];
                            dev.FabrieksNummer = result["FabrieksNummer"].ToString();
                            devs.Add(dev);
                        }
                    }
                }
                catch
                {
                }
            }
            return devs;
        }

        public int Create(Device dev)
        {
            int affected = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblDeviceInsert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Merk", dev.Merk);
                cmd.Parameters.AddWithValue("@Type", dev.Type);
                cmd.Parameters.AddWithValue("@Serienummer", dev.Serienummer);
                cmd.Parameters.AddWithValue("@IsPcCompatibel", dev.IsPcCompatibel);
                cmd.Parameters.AddWithValue("@FabrieksNummer", dev.FabrieksNummer);

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

        public bool Update(Device dev)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblDeviceUpdate", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdDevice", dev.IdDevice);
                cmd.Parameters.AddWithValue("@Merk", dev.Merk);
                cmd.Parameters.AddWithValue("@Type", dev.Type);
                cmd.Parameters.AddWithValue("@Serienummer", dev.Serienummer);
                cmd.Parameters.AddWithValue("@IsPcCompatibel", dev.IsPcCompatibel);
                cmd.Parameters.AddWithValue("@FabrieksNummer", dev.FabrieksNummer);

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
                SqlCommand cmd = new SqlCommand("TblDeviceDelete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdDevice", id);

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
        public List<Device> Rapportering(string s, string[] keuzeKolommen)
        {
            List<Device> devs = new List<Device>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.CommandType = System.Data.CommandType.Text;

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            Device dev = new Device();
                            if (keuzeKolommen.Contains("idDevice")) { dev.IdDevice = (int)result["IdDevice"]; }
                            if (keuzeKolommen.Contains("merk")) { dev.Merk = result["Merk"].ToString(); }
                            if (keuzeKolommen.Contains("type")) { dev.Type = result["Type"].ToString(); }
                            if (keuzeKolommen.Contains("serienummer")) { dev.Serienummer = result["Serienummer"].ToString(); }
                            if (keuzeKolommen.Contains("isPcCompatibel")) { dev.IsPcCompatibel = (bool)result["IsPcCompatibel"]; }
                            if (keuzeKolommen.Contains("fabrieksNummer")) { dev.FabrieksNummer = result["FabrieksNummer"].ToString(); }
                            devs.Add(dev);
                        }
                    }
                }
                catch
                {
                }
            }
            return devs;
        }
    }
}