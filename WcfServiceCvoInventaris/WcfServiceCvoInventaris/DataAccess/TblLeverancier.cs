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
                            l.idLeverancier = (int)dr["idLeverancier"];
                            l.naam = dr["naam"].ToString();
                            l.afkorting = dr["afkorting"].ToString();
                            l.straat = dr["straat"].ToString();
                            l.huisNummer = (int)dr["huisNummer"];
                            l.busNummer = (int)dr["busNummer"];
                            l.postcode = (int)dr["postcode"];
                            l.telefoon = dr["telefoon"].ToString();
                            l.fax = dr["fax"].ToString();
                            l.email = dr["email"].ToString();
                            l.website = dr["website"].ToString();
                            l.btwNummer = dr["btwNummer"].ToString();
                            l.iban = dr["iban"].ToString();
                            l.bic = dr["bic"].ToString();
                            l.toegevoegdOp = (DateTime)dr["toegevoegdOp"];
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
                            l.idLeverancier = (int)dr["idLeverancier"];
                            l.naam = dr["naam"].ToString();
                            l.afkorting = dr["afkorting"].ToString();
                            l.straat = dr["straat"].ToString();
                            l.huisNummer = (int)dr["huisNummer"];
                            l.busNummer = (int)dr["busNummer"];
                            l.postcode = (int)dr["postcode"];
                            l.telefoon = dr["telefoon"].ToString();
                            l.fax = dr["fax"].ToString();
                            l.email = dr["email"].ToString();
                            l.website = dr["website"].ToString();
                            l.btwNummer = dr["btwNummer"].ToString();
                            l.iban = dr["iban"].ToString();
                            l.bic = dr["bic"].ToString();
                            l.toegevoegdOp = (DateTime)dr["toegevoegdOp"];
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
                        cmd.Parameters.AddWithValue("naam", l.naam);
                        cmd.Parameters.AddWithValue("afkorting", l.afkorting);
                        cmd.Parameters.AddWithValue("straat", l.straat);
                        cmd.Parameters.AddWithValue("huisNummer", l.huisNummer);
                        cmd.Parameters.AddWithValue("busNummer", l.busNummer);
                        cmd.Parameters.AddWithValue("postcode", l.postcode);
                        cmd.Parameters.AddWithValue("telefoon", l.telefoon);
                        cmd.Parameters.AddWithValue("fax", l.fax);
                        cmd.Parameters.AddWithValue("email", l.email);
                        cmd.Parameters.AddWithValue("website", l.website);
                        cmd.Parameters.AddWithValue("btwNummer", l.btwNummer);
                        cmd.Parameters.AddWithValue("iban", l.iban);
                        cmd.Parameters.AddWithValue("bic", l.bic);
                        cmd.Parameters.AddWithValue("toegevoegdOp", l.toegevoegdOp);
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
                        cmd.Parameters.AddWithValue("idLeverancier", l.idLeverancier);
                        cmd.Parameters.AddWithValue("naam", l.naam);
                        cmd.Parameters.AddWithValue("afkorting", l.afkorting);
                        cmd.Parameters.AddWithValue("straat", l.straat);
                        cmd.Parameters.AddWithValue("huisNummer", l.huisNummer);
                        cmd.Parameters.AddWithValue("busNummer", l.busNummer);
                        cmd.Parameters.AddWithValue("postcode", l.postcode);
                        cmd.Parameters.AddWithValue("telefoon", l.telefoon);
                        cmd.Parameters.AddWithValue("fax", l.fax);
                        cmd.Parameters.AddWithValue("email", l.email);
                        cmd.Parameters.AddWithValue("website", l.website);
                        cmd.Parameters.AddWithValue("btwNummer", l.btwNummer);
                        cmd.Parameters.AddWithValue("iban", l.iban);
                        cmd.Parameters.AddWithValue("bic", l.bic);
                        cmd.Parameters.AddWithValue("toegevoegdOp", l.toegevoegdOp);
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
                            if (keuzeKolommen.Contains("idLeverancier")) { l.idLeverancier = (int)dr["idLeverancier"]; }
                            if (keuzeKolommen.Contains("naam")) { l.naam = dr["naam"].ToString(); }
                            if (keuzeKolommen.Contains("afkorting")) { l.afkorting = dr["afkorting"].ToString(); }
                            if (keuzeKolommen.Contains("straat")) { l.straat = dr["straat"].ToString(); }
                            if (keuzeKolommen.Contains("huisNummer")) { l.huisNummer = (int)dr["huisNummer"]; }
                            if (keuzeKolommen.Contains("busNummer")) { l.busNummer = (int)dr["busNummer"]; }
                            if (keuzeKolommen.Contains("postcode")) { l.postcode = (int)dr["postcode"]; }
                            if (keuzeKolommen.Contains("telefoon")) { l.telefoon = dr["telefoon"].ToString(); }
                            if (keuzeKolommen.Contains("fax")) { l.fax = dr["fax"].ToString(); }
                            if (keuzeKolommen.Contains("email")) { l.email = dr["email"].ToString(); }
                            if (keuzeKolommen.Contains("website")) { l.website = dr["website"].ToString(); }
                            if (keuzeKolommen.Contains("btwNummer")) { l.btwNummer = dr["btwNummer"].ToString(); }
                            if (keuzeKolommen.Contains("iban")) { l.iban = dr["iban"].ToString(); }
                            if (keuzeKolommen.Contains("bic")) { l.bic = dr["bic"].ToString(); }
                            if (keuzeKolommen.Contains("toegevoegdOp")) { l.toegevoegdOp = (DateTime)dr["toegevoegdOp"]; }
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