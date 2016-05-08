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
                command.Parameters.AddWithValue("@idCpu", t.Cpu.IdCpu);
                command.Parameters.AddWithValue("@idDevice", t.Device.IdDevice);
                command.Parameters.AddWithValue("@idGrafischeKaart", t.GrafischeKaart.IdGrafischeKaart);
                command.Parameters.AddWithValue("@idHarddisk", t.Harddisk.IdHarddisk);
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
                            Cpu cpu = new Cpu();
                            Device device = new Device();
                            GrafischeKaart grafischeKaart = new GrafischeKaart();
                            Harddisk harddisk = new Harddisk();

                            cpu.IdCpu = (int)reader["idCpu"];
                            cpu.FabrieksNummer = reader["cpu fabrieksnummer"].ToString();
                            cpu.Merk = reader["cpu merk"].ToString();
                            cpu.Snelheid = (int)reader["cpu snelheid"];
                            cpu.Type = reader["cpu type"].ToString();

                            device.IdDevice = (int)reader["idDevice"];
                            device.FabrieksNummer = reader["device fabrieksnummer"].ToString();
                            device.IsPcCompatibel = (bool)reader["device isPcCompatibel"];
                            device.Merk = reader["device merk"].ToString();
                            device.Serienummer = reader["device serienummer"].ToString();
                            device.Type = reader["device type"].ToString();

                            grafischeKaart.IdGrafischeKaart = (int)reader["idGrafischeKaart"];
                            grafischeKaart.Driver = reader["grafischeKaart driver"].ToString();
                            grafischeKaart.FabrieksNummer = reader["grafischeKaart fabrieksnummer"].ToString();
                            grafischeKaart.Merk = reader["grafischeKaart merk"].ToString();
                            grafischeKaart.Type = reader["grafischeKaart type"].ToString();

                            harddisk.IdHarddisk = (int)reader["idHarddisk"];
                            harddisk.FabrieksNummer = reader["harddisk fabrieksnummer"].ToString();
                            harddisk.Grootte = (int)reader["harddisk grootte"];
                            harddisk.Merk = reader["harddisk merk"].ToString();

                            hardware.Id = (int)reader["idHardware"];
                            hardware.Cpu = cpu;
                            hardware.Device = device;
                            hardware.GrafischeKaart = grafischeKaart;
                            hardware.Harddisk = harddisk;

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
            Cpu cpu = new Cpu();
            Device device = new Device();
            GrafischeKaart grafischeKaart = new GrafischeKaart();
            Harddisk harddisk = new Harddisk();
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
                        cpu.IdCpu = (int)reader["idCpu"];
                        cpu.FabrieksNummer = reader["cpu fabrieksnummer"].ToString();
                        cpu.Merk = reader["cpu merk"].ToString();
                        cpu.Snelheid = (int)reader["cpu snelheid"];
                        cpu.Type = reader["cpu type"].ToString();

                        device.IdDevice = (int)reader["idDevice"];
                        device.FabrieksNummer = reader["device fabrieksnummer"].ToString();
                        device.IsPcCompatibel = (bool)reader["device isPcCompatibel"];
                        device.Merk = reader["device merk"].ToString();
                        device.Serienummer = reader["device serienummer"].ToString();
                        device.Type = reader["device type"].ToString();

                        grafischeKaart.IdGrafischeKaart = (int)reader["idGrafischeKaart"];
                        grafischeKaart.Driver = reader["grafischeKaart driver"].ToString();
                        grafischeKaart.FabrieksNummer = reader["grafischeKaart fabrieksnummer"].ToString();
                        grafischeKaart.Merk = reader["grafischeKaart merk"].ToString();
                        grafischeKaart.Type = reader["grafischeKaart type"].ToString();

                        harddisk.IdHarddisk = (int)reader["idHarddisk"];
                        harddisk.FabrieksNummer = reader["harddisk fabrieksnummer"].ToString();
                        harddisk.Grootte = (int)reader["harddisk grootte"];
                        harddisk.Merk = reader["harddisk merk"].ToString();

                        hardware.Id = (int)reader["idHardware"];
                        hardware.Cpu = cpu;
                        hardware.Device = device;
                        hardware.GrafischeKaart = grafischeKaart;
                        hardware.Harddisk = harddisk;
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
                command.Parameters.AddWithValue("@idHardware", t.Id);
                command.Parameters.AddWithValue("@idCpu", t.Cpu.IdCpu);
                command.Parameters.AddWithValue("@idDevice", t.Device.IdDevice);
                command.Parameters.AddWithValue("@idGrafischeKaart", t.GrafischeKaart.IdGrafischeKaart);
                command.Parameters.AddWithValue("@idHarddisk", t.Harddisk.IdHarddisk);
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

        public List<Hardware> Rapportering(string s, string[] keuzeKolommen)
        {
            List<Hardware> hardwares = new List<Hardware>();
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
                            Hardware hardware = new Hardware();
                            Cpu cpu = new Cpu();
                            Device device = new Device();
                            GrafischeKaart grafischeKaart = new GrafischeKaart();
                            Harddisk harddisk = new Harddisk();

                            if (keuzeKolommen.Contains("TblHardware.idHardware")) { hardware.Id = (int)result["idHardware"]; }
                            if (keuzeKolommen.Contains("TblCpu.merk cm")) { cpu.Merk = result["cm"].ToString(); }
                            if (keuzeKolommen.Contains("TblDevice.merk dm")) { device.Merk = result["dm"].ToString(); }
                            if (keuzeKolommen.Contains("TblGrafischeKaart.merk gm")) { grafischeKaart.Merk = result["gm"].ToString(); }
                            if (keuzeKolommen.Contains("TblHarddisk.merk hm")) { harddisk.Merk = result["hm"].ToString(); }

                            hardware.Cpu = cpu;
                            hardware.Device = device;
                            hardware.GrafischeKaart = grafischeKaart;
                            hardware.Harddisk = harddisk;
                            hardwares.Add(hardware);
                        }
                    }
                }
                catch
                {
                }
            }
            return hardwares;
        }
    }
}