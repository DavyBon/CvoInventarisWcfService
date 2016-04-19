using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblGrafischeKaart : ICrudable<GrafischeKaart>
    {
        #region Get Connection String
        private string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["CvoInventarisDBConnection"].ConnectionString;
        }
        #endregion

        #region CRUD TblGrafischeKaart
        public GrafischeKaart GetById(int id)
        {
            GrafischeKaart gk = new GrafischeKaart();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblGrafischeKaartReadOne", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        result.Read();
                        gk.IdGrafischeKaart = (int)result["IdGrafischeKaart"];
                        gk.Merk = result["Merk"].ToString();
                        gk.Type = result["Type"].ToString();
                        gk.Driver = result["Driver"].ToString();
                        gk.FabrieksNummer = result["FabrieksNummer"].ToString();
                    }
                }
                catch
                {
                }
            }
            return gk;
        }

        public List<GrafischeKaart> GetAll()
        {
            List<GrafischeKaart> gks = new List<GrafischeKaart>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblGrafischeKaartReadAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            GrafischeKaart gk = new GrafischeKaart();
                            gk.IdGrafischeKaart = (int)result["IdGrafischeKaart"];
                            gk.Merk = result["Merk"].ToString();
                            gk.Type = result["Type"].ToString();
                            gk.Driver = result["Driver"].ToString();
                            gk.FabrieksNummer = result["FabrieksNummer"].ToString();
                            gks.Add(gk);
                        }
                    }
                }
                catch
                {
                }
            }
            return gks;
        }

        public int Create(GrafischeKaart gk)
        {
            int affected = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblGrafischeKaartInsert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Merk", gk.Merk);
                cmd.Parameters.AddWithValue("@Type", gk.Type);
                cmd.Parameters.AddWithValue("@Driver", gk.Driver);
                cmd.Parameters.AddWithValue("@FabrieksNummer", gk.FabrieksNummer);

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

        public bool Update(GrafischeKaart gk)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblGrafischeKaartUpdate", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdGrafischeKaart", gk.IdGrafischeKaart);
                cmd.Parameters.AddWithValue("@Merk", gk.Merk);
                cmd.Parameters.AddWithValue("@Type", gk.Type);
                cmd.Parameters.AddWithValue("@Driver", gk.Driver);
                cmd.Parameters.AddWithValue("@FabrieksNummer", gk.FabrieksNummer);

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
                SqlCommand cmd = new SqlCommand("TblGrafischeKaartDelete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdGrafischeKaart", id);

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
        public List<GrafischeKaart> Rapportering(string s, string[] keuzeKolommen)
        {
            List<GrafischeKaart> gks = new List<GrafischeKaart>();
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
                            GrafischeKaart gk = new GrafischeKaart();
                            if (keuzeKolommen.Contains("idGrafischeKaart")) { gk.IdGrafischeKaart = (int)result["IdGrafischeKaart"]; }
                            if (keuzeKolommen.Contains("merk")) { gk.Merk = result["Merk"].ToString(); }
                            if (keuzeKolommen.Contains("type")) { gk.Type = result["Type"].ToString(); }
                            if (keuzeKolommen.Contains("driver")) { gk.Driver = result["Driver"].ToString(); }
                            if (keuzeKolommen.Contains("fabrieksNummer")) { gk.FabrieksNummer = result["FabrieksNummer"].ToString(); }
                            gks.Add(gk);
                        }
                    }
                }
                catch
                {
                }
            }
            return gks;
        }
    }
}