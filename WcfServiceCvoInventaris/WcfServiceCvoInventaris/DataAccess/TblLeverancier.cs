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
    public class TblLeverancier : ICrudable<Leverancier>
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

        public List<Leverancier> GetAll()
        {
            List<Leverancier> list = new List<Leverancier>();

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblLeverancierReadAll", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            Leverancier l = new Leverancier();
                            l.IdLeverancier = (int)dr["idLeverancier"];
                            l.Naam = dr["naam"].ToString();
                            l.Afkorting = dr["afkorting"].ToString();
                            l.Straat = dr["straat"].ToString();
                            l.HuisNummer = (int)dr["huisNummer"];
                            l.BusNummer = (int)dr["busNummer"];
                            l.Postcode = (int)dr["postcode"];
                            l.Telefoon = dr["telefoon"].ToString();
                            l.Fax = dr["fax"].ToString();
                            l.Email = dr["email"].ToString();
                            l.Website = dr["website"].ToString();
                            l.BtwNummer = dr["btwNummer"].ToString();
                            l.Iban = dr["iban"].ToString();
                            l.Bic = dr["bic"].ToString();
                            l.ToegevoegdOp = (DateTime)dr["toegevoegdOp"];
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

        public Leverancier GetById(int id)
        {
            Leverancier l = null;

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblLeverancierReadOne", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idLeverancier", id);
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            l = new Leverancier();
                            l.IdLeverancier = (int)dr["idLeverancier"];
                            l.Naam = dr["naam"].ToString();
                            l.Afkorting = dr["afkorting"].ToString();
                            l.Straat = dr["straat"].ToString();
                            l.HuisNummer = (int)dr["huisNummer"];
                            l.BusNummer = (int)dr["busNummer"];
                            l.Postcode = (int)dr["postcode"];
                            l.Telefoon = dr["telefoon"].ToString();
                            l.Fax = dr["fax"].ToString();
                            l.Email = dr["email"].ToString();
                            l.Website = dr["website"].ToString();
                            l.BtwNummer = dr["btwNummer"].ToString();
                            l.Iban = dr["iban"].ToString();
                            l.Bic = dr["bic"].ToString();
                            l.ToegevoegdOp = (DateTime)dr["toegevoegdOp"];
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

        public int Create(Leverancier l)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblLeverancierInsert", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("naam", l.Naam);
                        cmd.Parameters.AddWithValue("afkorting", l.Afkorting);
                        cmd.Parameters.AddWithValue("straat", l.Straat);
                        cmd.Parameters.AddWithValue("huisNummer", l.HuisNummer);
                        cmd.Parameters.AddWithValue("busNummer", l.BusNummer);
                        cmd.Parameters.AddWithValue("postcode", l.Postcode);
                        cmd.Parameters.AddWithValue("telefoon", l.Telefoon);
                        cmd.Parameters.AddWithValue("fax", l.Fax);
                        cmd.Parameters.AddWithValue("email", l.Email);
                        cmd.Parameters.AddWithValue("website", l.Website);
                        cmd.Parameters.AddWithValue("btwNummer", l.BtwNummer);
                        cmd.Parameters.AddWithValue("iban", l.Iban);
                        cmd.Parameters.AddWithValue("bic", l.Bic);
                        cmd.Parameters.AddWithValue("toegevoegdOp", l.ToegevoegdOp);
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

        public bool Update(Leverancier l)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblLeverancierUpdate", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idLeverancier", l.IdLeverancier);
                        cmd.Parameters.AddWithValue("naam", l.Naam);
                        cmd.Parameters.AddWithValue("afkorting", l.Afkorting);
                        cmd.Parameters.AddWithValue("straat", l.Straat);
                        cmd.Parameters.AddWithValue("huisNummer", l.HuisNummer);
                        cmd.Parameters.AddWithValue("busNummer", l.BusNummer);
                        cmd.Parameters.AddWithValue("postcode", l.Postcode);
                        cmd.Parameters.AddWithValue("telefoon", l.Telefoon);
                        cmd.Parameters.AddWithValue("fax", l.Fax);
                        cmd.Parameters.AddWithValue("email", l.Email);
                        cmd.Parameters.AddWithValue("website", l.Website);
                        cmd.Parameters.AddWithValue("btwNummer", l.BtwNummer);
                        cmd.Parameters.AddWithValue("iban", l.Iban);
                        cmd.Parameters.AddWithValue("bic", l.Bic);
                        cmd.Parameters.AddWithValue("toegevoegdOp", l.ToegevoegdOp);
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
                    using (SqlCommand cmd = new SqlCommand("TblLeverancierDelete", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idLeverancier", id);
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

        public List<Leverancier> Rapportering(string s, string[] keuzeKolommen)
        {
            List<Leverancier> list = new List<Leverancier>();

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
                            Leverancier l = new Leverancier();
                            if (keuzeKolommen.Contains("idLeverancier")) { l.IdLeverancier = (int)dr["idLeverancier"]; }
                            if (keuzeKolommen.Contains("naam")) { l.Naam = dr["naam"].ToString(); }
                            if (keuzeKolommen.Contains("afkorting")) { l.Afkorting = dr["afkorting"].ToString(); }
                            if (keuzeKolommen.Contains("straat")) { l.Straat = dr["straat"].ToString(); }
                            if (keuzeKolommen.Contains("huisNummer")) { l.HuisNummer = (int)dr["huisNummer"]; }
                            if (keuzeKolommen.Contains("busNummer")) { l.BusNummer = (int)dr["busNummer"]; }
                            if (keuzeKolommen.Contains("postcode")) { l.Postcode = (int)dr["postcode"]; }
                            if (keuzeKolommen.Contains("telefoon")) { l.Telefoon = dr["telefoon"].ToString(); }
                            if (keuzeKolommen.Contains("fax")) { l.Fax = dr["fax"].ToString(); }
                            if (keuzeKolommen.Contains("email")) { l.Email = dr["email"].ToString(); }
                            if (keuzeKolommen.Contains("website")) { l.Website = dr["website"].ToString(); }
                            if (keuzeKolommen.Contains("btwNummer")) { l.BtwNummer = dr["btwNummer"].ToString(); }
                            if (keuzeKolommen.Contains("iban")) { l.Iban = dr["iban"].ToString(); }
                            if (keuzeKolommen.Contains("bic")) { l.Bic = dr["bic"].ToString(); }
                            if (keuzeKolommen.Contains("toegevoegdOp")) { l.ToegevoegdOp = (DateTime)dr["toegevoegdOp"]; }
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
    }
}