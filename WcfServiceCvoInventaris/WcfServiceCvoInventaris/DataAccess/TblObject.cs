using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblObject : ICrudable<Object>
    {
        SqlConnection connection = new SqlConnection("Data Source=92.222.220.213,1500;Initial Catalog=CvoInventarisdb;Persist Security Info=True;User ID=sa;Password=grati#s1867");

        public int Create(Object obj)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("TblObjectInsert", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idObjectType", obj.ObjectType.Id));
                    command.Parameters.Add(new SqlParameter("@kenmerken", obj.Kenmerken));
                    command.Parameters.Add(new SqlParameter("@idLeverancier", obj.Leverancier.IdLeverancier));
                    command.Parameters.Add(new SqlParameter("@idFactuur", obj.Factuur.IdFactuur));
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("TblObjectDelete", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", id));
                    command.ExecuteReader();
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Object> GetAll()
        {
            List<Object> list = new List<Object>();
            WcfServiceCvoInventaris.Object obj;
            Leverancier leverancier;
            Factuur factuur;
            ObjectTypes objType;
            try
            {
                using (SqlCommand command = new SqlCommand("TblObjectReadAll", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader mySqlDataReader = command.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {
                        obj = new WcfServiceCvoInventaris.Object();
                        leverancier = new Leverancier();
                        factuur = new Factuur();
                        objType = new ObjectTypes();

                        leverancier.IdLeverancier = (int)mySqlDataReader["idLeverancier"];
                        leverancier.Afkorting = mySqlDataReader["afkorting"].ToString();
                        leverancier.Bic = mySqlDataReader["bic"].ToString();
                        leverancier.BtwNummer = mySqlDataReader["btwNummer"].ToString();
                        leverancier.BusNummer = (int)mySqlDataReader["busNummer"];
                        leverancier.Email = mySqlDataReader["email"].ToString();
                        leverancier.Fax = mySqlDataReader["fax"].ToString();
                        leverancier.HuisNummer = (int)mySqlDataReader["huisNummer"];
                        leverancier.Iban = mySqlDataReader["iban"].ToString();
                        leverancier.Naam = mySqlDataReader["naam"].ToString();
                        leverancier.Postcode = (int)mySqlDataReader["postcode"];
                        leverancier.Straat = mySqlDataReader["straat"].ToString();
                        leverancier.Telefoon = mySqlDataReader["telefoon"].ToString();
                        leverancier.ToegevoegdOp = (DateTime)mySqlDataReader["toegevoegdOp"];
                        leverancier.Website = mySqlDataReader["website"].ToString();

                        factuur.IdFactuur = (int)mySqlDataReader["idFactuur"];
                        factuur.Afschrijfperiode = (int)mySqlDataReader["Afschrijfperiode"];
                        factuur.Boekjaar = mySqlDataReader["Boekjaar"].ToString();
                        factuur.CvoVolgNummer = mySqlDataReader["CvoVolgNummer"].ToString();
                        factuur.DatumInsert = (DateTime)mySqlDataReader["DatumInsert"];
                        factuur.DatumModified = (DateTime)mySqlDataReader["DatumModified"];
                        factuur.FactuurDatum = (DateTime)mySqlDataReader["FactuurDatum"];
                        factuur.FactuurNummer = mySqlDataReader["FactuurNummer"].ToString();
                        factuur.Garantie = (int)mySqlDataReader["Garantie"];
                        factuur.Leverancier = leverancier;
                        factuur.Omschrijving = mySqlDataReader["Omschrijving"].ToString();
                        factuur.Opmerking = mySqlDataReader["Opmerking"].ToString();
                        factuur.Prijs = (decimal)mySqlDataReader["Prijs"];
                        factuur.UserInsert = mySqlDataReader["UserInsert"].ToString();
                        factuur.UserModified = mySqlDataReader["UserModified"].ToString();

                        objType.Id = (int)mySqlDataReader["idObjectType"];
                        objType.Omschrijving = mySqlDataReader["omschrijving"].ToString();

                        obj.Id = (int)mySqlDataReader["idObject"];
                        obj.Kenmerken = mySqlDataReader["kenmerken"].ToString();
                        obj.Leverancier = leverancier;
                        obj.Factuur = factuur;
                        obj.ObjectType = objType;
                        list.Add(obj);
                    }
                    return list;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public Object GetById(int id)
        {
            WcfServiceCvoInventaris.Object obj = new WcfServiceCvoInventaris.Object();
            Leverancier leverancier;
            Factuur factuur;
            ObjectTypes objType;
            try
            {
                using (SqlCommand command = new SqlCommand("TblObjectReadOne", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader mySqlDataReader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);

                    while (mySqlDataReader.Read())
                    {
                        leverancier = new Leverancier();
                        factuur = new Factuur();
                        objType = new ObjectTypes();

                        leverancier.IdLeverancier = (int)mySqlDataReader["idLeverancier"];
                        leverancier.Afkorting = mySqlDataReader["afkorting"].ToString();
                        leverancier.Bic = mySqlDataReader["bic"].ToString();
                        leverancier.BtwNummer = mySqlDataReader["btwNummer"].ToString();
                        leverancier.BusNummer = (int)mySqlDataReader["busNummer"];
                        leverancier.Email = mySqlDataReader["email"].ToString();
                        leverancier.Fax = mySqlDataReader["fax"].ToString();
                        leverancier.HuisNummer = (int)mySqlDataReader["huisNummer"];
                        leverancier.Iban = mySqlDataReader["iban"].ToString();
                        leverancier.Naam = mySqlDataReader["naam"].ToString();
                        leverancier.Postcode = (int)mySqlDataReader["postcode"];
                        leverancier.Straat = mySqlDataReader["straat"].ToString();
                        leverancier.Telefoon = mySqlDataReader["telefoon"].ToString();
                        leverancier.ToegevoegdOp = (DateTime)mySqlDataReader["toegevoegdOp"];
                        leverancier.Website = mySqlDataReader["website"].ToString();

                        factuur.IdFactuur = (int)mySqlDataReader["idFactuur"];
                        factuur.Afschrijfperiode = (int)mySqlDataReader["Afschrijfperiode"];
                        factuur.Boekjaar = mySqlDataReader["Boekjaar"].ToString();
                        factuur.CvoVolgNummer = mySqlDataReader["CvoVolgNummer"].ToString();
                        factuur.DatumInsert = (DateTime)mySqlDataReader["DatumInsert"];
                        factuur.DatumModified = (DateTime)mySqlDataReader["DatumModified"];
                        factuur.FactuurDatum = (DateTime)mySqlDataReader["FactuurDatum"];
                        factuur.FactuurNummer = mySqlDataReader["FactuurNummer"].ToString();
                        factuur.Garantie = (int)mySqlDataReader["Garantie"];
                        factuur.Leverancier = leverancier;
                        factuur.Omschrijving = mySqlDataReader["Omschrijving"].ToString();
                        factuur.Opmerking = mySqlDataReader["Opmerking"].ToString();
                        factuur.Prijs = (decimal)mySqlDataReader["Prijs"];
                        factuur.UserInsert = mySqlDataReader["UserInsert"].ToString();
                        factuur.UserModified = mySqlDataReader["UserModified"].ToString();

                        objType.Id = (int)mySqlDataReader["idObjectType"];
                        objType.Omschrijving = mySqlDataReader["omschrijving"].ToString();

                        obj.Id = (int)mySqlDataReader["idObject"];
                        obj.Kenmerken = mySqlDataReader["kenmerken"].ToString();
                        obj.Leverancier = leverancier;
                        obj.Factuur = factuur;
                        obj.ObjectType = objType;

                    }
                    return obj;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Update(Object obj)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("TblObjectUpdate", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", obj.Id));
                    command.Parameters.Add(new SqlParameter("@idObjectType", obj.ObjectType.Id));
                    command.Parameters.Add(new SqlParameter("@kenmerken", obj.Kenmerken));
                    command.Parameters.Add(new SqlParameter("@idLeverancier", obj.Leverancier.IdLeverancier));
                    command.Parameters.Add(new SqlParameter("@idFactuur", obj.Factuur.IdFactuur));
                    command.ExecuteReader();
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}