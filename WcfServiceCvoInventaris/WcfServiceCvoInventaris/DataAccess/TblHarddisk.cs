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
    public class TblHarddisk : ICrudable<Harddisk>
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

        public List<Harddisk> GetAll()
        {
            List<Harddisk> list = new List<Harddisk>();

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblHarddiskReadAll", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            Harddisk h = new Harddisk();
                            h.IdHarddisk = (int)dr["idHarddisk"];
                            h.Merk = dr["merk"].ToString();
                            h.Grootte = (int)dr["grootte"];
                            h.FabrieksNummer = dr["fabrieksNummer"].ToString();
                            list.Add(h);
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

        public Harddisk GetById(int id)
        {
            Harddisk h = null;

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblHarddiskReadOne", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idHarddisk", id); 
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            h = new Harddisk();
                            h.IdHarddisk = (int)dr["idHarddisk"];
                            h.Merk = dr["merk"].ToString();
                            h.Grootte = (int)dr["grootte"];
                            h.FabrieksNummer = dr["fabrieksNummer"].ToString();
                        }
                        return h;
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

        public int Create(Harddisk h)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblHarddiskInsert", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("merk", h.Merk);
                        cmd.Parameters.AddWithValue("grootte", h.Grootte);
                        cmd.Parameters.AddWithValue("fabrieksNummer", h.FabrieksNummer);
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

        public bool Update(Harddisk h)
        {
            try 
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblHarddiskUpdate", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idHarddisk", h.IdHarddisk);
                        cmd.Parameters.AddWithValue("merk", h.Merk);
                        cmd.Parameters.AddWithValue("grootte", h.Grootte);
                        cmd.Parameters.AddWithValue("fabrieksNummer", h.FabrieksNummer);
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
                    using (SqlCommand cmd = new SqlCommand("TblHarddiskDelete", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idHarddisk", id);
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
        public List<Harddisk> Rapportering(string s, string[] keuzeKolommen)
        {
            List<Harddisk> list = new List<Harddisk>();

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
                            Harddisk h = new Harddisk();
                            if (keuzeKolommen.Contains("idHarddisk")) { h.IdHarddisk = (int)dr["idHarddisk"]; }
                            if (keuzeKolommen.Contains("merk")) { h.Merk = dr["merk"].ToString(); }
                            if (keuzeKolommen.Contains("grootte")) { h.Grootte = (int)dr["grootte"]; }
                            if (keuzeKolommen.Contains("fabrieksNummer")) { h.FabrieksNummer = dr["fabrieksNummer"].ToString(); }
                            list.Add(h);
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