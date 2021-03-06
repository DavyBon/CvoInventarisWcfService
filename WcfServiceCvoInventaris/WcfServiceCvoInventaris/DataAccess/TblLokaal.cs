﻿using System;
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
    public class TblLokaal : ICrudable<Lokaal>
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

        public List<Lokaal> GetAll()
        {
            List<Lokaal> list = new List<Lokaal>();
            
            try 
            { 
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblLokaalReadAll", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        
                        while (dr.Read())
                        {
                            Lokaal l = new Lokaal();
                            l.IdLokaal = (int)dr["idLokaal"];
                            l.LokaalNaam = dr["lokaalNaam"].ToString();
                            l.AantalPlaatsen = (int)dr["aantalPlaatsen"];
                            l.IsComputerLokaal = (bool)dr["isComputerLokaal"];
                            list.Add(l);
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

        public Lokaal GetById(int id)
        {
            Lokaal l = null;

            try 
            { 
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblLokaalReadOne", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idLokaal", id);
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            l = new Lokaal();
                            l.IdLokaal = (int)dr["idLokaal"];
                            l.LokaalNaam = dr["lokaalNaam"].ToString();
                            l.AantalPlaatsen = (int)dr["aantalPlaatsen"];
                            l.IsComputerLokaal = (bool)dr["isComputerLokaal"];
                        }
                        return l;
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

        public int Create(Lokaal l)
        {
            try 
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblLokaalInsert", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("lokaalNaam", l.LokaalNaam);
                        cmd.Parameters.AddWithValue("aantalPlaatsen", l.AantalPlaatsen);
                        cmd.Parameters.AddWithValue("isComputerLokaal", l.IsComputerLokaal);
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

        public bool Update(Lokaal l)
        {
            try 
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblLokaalUpdate", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idLokaal", l.IdLokaal);
                        cmd.Parameters.AddWithValue("lokaalNaam", l.LokaalNaam);
                        cmd.Parameters.AddWithValue("aantalPlaatsen", l.AantalPlaatsen);
                        cmd.Parameters.AddWithValue("isComputerLokaal", l.IsComputerLokaal);
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
                    using (SqlCommand cmd = new SqlCommand("TblLokaalDelete", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idLokaal", id);
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
        public List<Lokaal> Rapportering(string s, string[] keuzeKolommen)
        {
            List<Lokaal> lokalen = new List<Lokaal>();
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
                            Lokaal lokaal = new Lokaal();
                            if (keuzeKolommen.Contains("TblLokaal.idLokaal")) { lokaal.IdLokaal = (int)result["idLokaal"]; }
                            if (keuzeKolommen.Contains("TblLokaal.lokaalNaam")) { lokaal.LokaalNaam = result["lokaalNaam"].ToString(); }
                            if (keuzeKolommen.Contains("TblLokaal.aantalPlaatsen")) { lokaal.AantalPlaatsen = (int)result["aantalPlaatsen"]; }
                            if (keuzeKolommen.Contains("TblLokaal.isComputerLokaal")) { lokaal.IsComputerLokaal = (bool)result["isComputerLokaal"]; }

                            lokalen.Add(lokaal);
                        }
                    }
                }
                catch
                {
                }
            }
            return lokalen;
        }
    }
}