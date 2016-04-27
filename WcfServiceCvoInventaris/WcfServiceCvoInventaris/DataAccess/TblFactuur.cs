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
    public class TblFactuur : ICrudable<Factuur>
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

        public List<Factuur> GetAll()
        {
            List<Factuur> list = new List<Factuur>();

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblFactuurReadAll", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            Leverancier leverancier = new Leverancier();
                            leverancier.IdLeverancier = (int)dr["idLeverancier"];
                            leverancier.Afkorting = dr["afkorting"].ToString();
                            leverancier.Bic = dr["bic"].ToString();
                            leverancier.BtwNummer = dr["btwNummer"].ToString();
                            leverancier.BusNummer = (int)dr["busNummer"];
                            leverancier.Email = dr["email"].ToString();
                            leverancier.Fax = dr["fax"].ToString();
                            leverancier.HuisNummer = (int)dr["huisNummer"];
                            leverancier.Iban = dr["iban"].ToString();
                            leverancier.Naam = dr["naam"].ToString();
                            leverancier.Postcode = (int)dr["postcode"];
                            leverancier.Straat = dr["straat"].ToString();
                            leverancier.Telefoon = dr["telefoon"].ToString();
                            leverancier.ToegevoegdOp = (DateTime)dr["toegevoegdOp"];
                            leverancier.Website = dr["website"].ToString();

                            Factuur f = new Factuur();
                            f.IdFactuur = (int)dr["idFactuur"];
                            f.Boekjaar = dr["Boekjaar"].ToString();
                            f.CvoVolgNummer = dr["CvoVolgNummer"].ToString();
                            f.FactuurNummer = dr["FactuurNummer"].ToString();
                            f.FactuurDatum = (DateTime)dr["FactuurDatum"];
                            f.FactuurStatusGetekend = (bool)dr["FactuurStatusGetekend"];
                            f.VerwerkingsDatum = (DateTime)dr["VerwerkingsDatum"];
                            f.Leverancier = leverancier;
                            f.Prijs = (int)dr["Prijs"];
                            f.Garantie = (int)dr["Garantie"];
                            f.Omschrijving = dr["Omschrijving"].ToString();
                            f.Opmerking = dr["Opmerking"].ToString();
                            f.Afschrijfperiode = (int)dr["Afschrijfperiode"];
                            f.OleDoc = dr["OleDoc"].ToString();
                            f.OleDocPath = dr["OleDocPath"].ToString();
                            f.OleDocFileName = dr["OleDocFileName"].ToString();
                            f.DatumInsert = (DateTime)dr["DatumInsert"];
                            f.UserInsert = dr["UserInsert"].ToString();
                            f.DatumModified = (DateTime)dr["DatumModified"];
                            f.UserModified = dr["UserModified"].ToString();
                            list.Add(f);
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

        public Factuur GetById(int id)
        {
            Factuur f = null;

            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblFactuurReadOne", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idFactuur", id);
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            Leverancier leverancier = new Leverancier();
                            leverancier.IdLeverancier = (int)dr["idLeverancier"];
                            leverancier.Afkorting = dr["afkorting"].ToString();
                            leverancier.Bic = dr["bic"].ToString();
                            leverancier.BtwNummer = dr["btwNummer"].ToString();
                            leverancier.BusNummer = (int)dr["busNummer"];
                            leverancier.Email = dr["email"].ToString();
                            leverancier.Fax = dr["fax"].ToString();
                            leverancier.HuisNummer = (int)dr["huisNummer"];
                            leverancier.Iban = dr["iban"].ToString();
                            leverancier.Naam = dr["naam"].ToString();
                            leverancier.Postcode = (int)dr["postcode"];
                            leverancier.Straat = dr["straat"].ToString();
                            leverancier.Telefoon = dr["telefoon"].ToString();
                            leverancier.ToegevoegdOp = (DateTime)dr["toegevoegdOp"];
                            leverancier.Website = dr["website"].ToString();

                            f = new Factuur();
                            f.IdFactuur = (int)dr["idFactuur"];
                            f.Boekjaar = dr["Boekjaar"].ToString();
                            f.CvoVolgNummer = dr["CvoVolgNummer"].ToString();
                            f.FactuurNummer = dr["FactuurNummer"].ToString();
                            f.FactuurDatum = (DateTime)dr["FactuurDatum"];
                            f.FactuurStatusGetekend = (bool)dr["FactuurStatusGetekend"];
                            f.VerwerkingsDatum = (DateTime)dr["VerwerkingsDatum"];
                            f.Leverancier = leverancier;
                            f.Prijs = (int)dr["Prijs"];
                            f.Garantie = (int)dr["Garantie"];
                            f.Omschrijving = dr["Omschrijving"].ToString();
                            f.Opmerking = dr["Opmerking"].ToString();
                            f.Afschrijfperiode = (int)dr["Afschrijfperiode"];
                            f.OleDoc = dr["OleDoc"].ToString();
                            f.OleDocPath = dr["OleDocPath"].ToString();
                            f.OleDocFileName = dr["OleDocFileName"].ToString();
                            f.DatumInsert = (DateTime)dr["DatumInsert"];
                            f.UserInsert = dr["UserInsert"].ToString();
                            f.DatumModified = (DateTime)dr["DatumModified"];
                            f.UserModified = dr["UserModified"].ToString();
                        }
                        return f;
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

        public int Create(Factuur f)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblFactuurInsert", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Boekjaar", f.Boekjaar);
                        cmd.Parameters.AddWithValue("CvoVolgNummer", f.CvoVolgNummer);
                        cmd.Parameters.AddWithValue("FactuurNummer", f.FactuurNummer);
                        cmd.Parameters.AddWithValue("FactuurDatum", f.FactuurDatum);
                        cmd.Parameters.AddWithValue("FactuurStatusGetekend", f.FactuurStatusGetekend);
                        cmd.Parameters.AddWithValue("VerwerkingsDatum", f.VerwerkingsDatum);
                        cmd.Parameters.AddWithValue("idLeverancier", f.Leverancier.IdLeverancier);
                        cmd.Parameters.AddWithValue("Prijs", f.Prijs);
                        cmd.Parameters.AddWithValue("Garantie", f.Garantie);
                        cmd.Parameters.AddWithValue("Omschrijving", f.Omschrijving);
                        cmd.Parameters.AddWithValue("Opmerking", f.Opmerking);
                        cmd.Parameters.AddWithValue("Afschrijfperiode", f.Afschrijfperiode);
                        cmd.Parameters.AddWithValue("OleDoc", f.OleDoc);
                        cmd.Parameters.AddWithValue("OleDocPath", f.OleDocPath);
                        cmd.Parameters.AddWithValue("OleDocFileName", f.OleDocFileName);
                        cmd.Parameters.AddWithValue("DatumInsert", f.DatumInsert);
                        cmd.Parameters.AddWithValue("UserInsert", f.UserInsert);
                        cmd.Parameters.AddWithValue("DatumModified", f.DatumModified);
                        cmd.Parameters.AddWithValue("UserModified", f.UserModified);
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

        public bool Update(Factuur f)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("TblFactuurUpdate", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idFactuur", f.IdFactuur);
                        cmd.Parameters.AddWithValue("Boekjaar", f.Boekjaar);
                        cmd.Parameters.AddWithValue("CvoVolgNummer", f.CvoVolgNummer);
                        cmd.Parameters.AddWithValue("FactuurNummer", f.FactuurNummer);
                        cmd.Parameters.AddWithValue("FactuurDatum", f.FactuurDatum);
                        cmd.Parameters.AddWithValue("FactuurStatusGetekend", f.FactuurStatusGetekend);
                        cmd.Parameters.AddWithValue("VerwerkingsDatum", f.VerwerkingsDatum);
                        cmd.Parameters.AddWithValue("idLeverancier", f.Leverancier.IdLeverancier);
                        cmd.Parameters.AddWithValue("Prijs", f.Prijs);
                        cmd.Parameters.AddWithValue("Garantie", f.Garantie);
                        cmd.Parameters.AddWithValue("Omschrijving", f.Omschrijving);
                        cmd.Parameters.AddWithValue("Opmerking", f.Opmerking);
                        cmd.Parameters.AddWithValue("Afschrijfperiode", f.Afschrijfperiode);
                        cmd.Parameters.AddWithValue("OleDoc", f.OleDoc);
                        cmd.Parameters.AddWithValue("OleDocPath", f.OleDocPath);
                        cmd.Parameters.AddWithValue("OleDocFileName", f.OleDocFileName);
                        cmd.Parameters.AddWithValue("DatumInsert", f.DatumInsert);
                        cmd.Parameters.AddWithValue("UserInsert", f.UserInsert);
                        cmd.Parameters.AddWithValue("DatumModified", f.DatumModified);
                        cmd.Parameters.AddWithValue("UserModified", f.UserModified);
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
                    using (SqlCommand cmd = new SqlCommand("TblFactuurDelete", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idFactuur", id);
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
    }
}