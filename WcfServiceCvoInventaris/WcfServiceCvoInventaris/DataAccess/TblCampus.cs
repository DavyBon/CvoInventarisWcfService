using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblCampus : ICrudable<Campus>
    {
        #region Fields

        private string message;

        #endregion

        #region Connectionstring

        private string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["CvoInventarisDBConnection"].ConnectionString;
        }

        #endregion

        #region Message

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        #endregion

        #region GetAll

        public List<Campus> GetAll()
        {
            List<Campus> list = new List<Campus>();

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblCampusReadAll", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            Campus c = new Campus();
                            c.IdCampus = (int)dr["idCampus"];
                            c.Naam = dr["naam"].ToString();
                            c.Postcode = dr["postcode"].ToString();
                            c.Straat = dr["straat"].ToString();
                            c.Nummer = dr["nummer"].ToString();
                            list.Add(c);
                        }
                        return list;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region GetById

        public Campus GetById(int id)
        {
            Campus c = null;

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblCampusReadOne", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idCampus", id);
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            c = new Campus();
                            c.IdCampus = (int)dr["idCampus"];
                            c.Naam = dr["naam"].ToString();
                            c.Postcode = dr["postcode"].ToString();
                            c.Straat = dr["straat"].ToString();
                            c.Nummer = dr["nummer"].ToString();
                        }
                        return c;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Create

        public int Create(Campus c)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblCampusInsert", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("naam", c.Naam);
                        cmd.Parameters.AddWithValue("postcode", c.Postcode);
                        cmd.Parameters.AddWithValue("straat", c.Straat);
                        cmd.Parameters.AddWithValue("nummer", c.Nummer);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }

        #endregion

        #region Update

        public bool Update(Campus c)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblCampusUpdate", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idCampus", c.IdCampus);
                        cmd.Parameters.AddWithValue("naam", c.Naam);
                        cmd.Parameters.AddWithValue("postcode", c.Postcode);
                        cmd.Parameters.AddWithValue("straat", c.Straat);
                        cmd.Parameters.AddWithValue("nummer", c.Nummer);
                        cmd.ExecuteReader();
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Delete

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblCampusDelete", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idCampus", id);
                        cmd.ExecuteReader();
                    }
                    return true;
                }
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        #endregion
        public List<Campus> Rapportering(string s, string[] keuzeKolommen)
        {
            List<Campus> list = new List<Campus>();

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s, con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            Campus c = new Campus();
                            if (keuzeKolommen.Contains("idCampus")) { c.IdCampus = (int)dr["idCampus"]; }
                            if (keuzeKolommen.Contains("naam")) { c.Naam = dr["naam"].ToString(); }
                            if (keuzeKolommen.Contains("postcode")) { c.Postcode = dr["postcode"].ToString(); }
                            if (keuzeKolommen.Contains("straat")) { c.Straat = dr["straat"].ToString(); }
                            if (keuzeKolommen.Contains("nummer")) { c.Nummer = dr["nummer"].ToString(); }
                            list.Add(c);
                        }
                        return list;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}