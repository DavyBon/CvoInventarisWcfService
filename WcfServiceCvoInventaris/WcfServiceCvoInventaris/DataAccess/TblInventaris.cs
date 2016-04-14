using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblInventaris : ICrudable<Inventaris>
    {
        SqlConnection connection = new SqlConnection("Data Source=92.222.220.213,1500;Initial Catalog=CvoInventarisdb;Persist Security Info=True;User ID=sa;Password=grati#s1867");

        public int Create(Inventaris inventaris)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("TblInventarisInsert", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@label", inventaris.label));
                    command.Parameters.Add(new SqlParameter("@idLokaal", inventaris.idLokaal));
                    command.Parameters.Add(new SqlParameter("@idObject", inventaris.idObject));
                    command.Parameters.Add(new SqlParameter("@aankoopjaar", inventaris.aankoopjaar));
                    command.Parameters.Add(new SqlParameter("@afschrijvingsjaar", inventaris.afschrijvingsperiode));
                    command.Parameters.Add(new SqlParameter("@historiek", inventaris.historiek));
                    command.Parameters.Add(new SqlParameter("@isActief", Convert.ToInt32(inventaris.isActief)));
                    command.Parameters.Add(new SqlParameter("@isAanwezig", Convert.ToInt32(inventaris.isAanwezig)));
                    command.Parameters.Add(new SqlParameter("@idVerzekering", inventaris.idVerzekering));
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch(Exception e)
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
                using (SqlCommand command = new SqlCommand("TblInventarisDelete", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", id));
                    command.ExecuteReader();
                }
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Inventaris> GetAll()
        {
            List<Inventaris> list = new List<Inventaris>();
            Inventaris inventaris;
            try
            {
                using (SqlCommand command = new SqlCommand("TblInventarisReadAll", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader mySqlDataReader = command.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {
                        inventaris = new Inventaris();
                        inventaris.id = (int)mySqlDataReader["idInventaris"];
                        inventaris.label = mySqlDataReader["label"].ToString();
                        inventaris.idLokaal = (int)mySqlDataReader["idLokaal"];
                        inventaris.idObject = (int)mySqlDataReader["idObject"];
                        inventaris.aankoopjaar = (int)mySqlDataReader["aankoopjaar"];
                        inventaris.afschrijvingsperiode = (int)mySqlDataReader["afschrijvingsperiode"];
                        inventaris.historiek = mySqlDataReader["historiek"].ToString();
                        inventaris.isActief = Convert.ToBoolean(mySqlDataReader["isActief"]);
                        inventaris.isAanwezig = Convert.ToBoolean(mySqlDataReader["isAanwezig"]);
                        inventaris.idVerzekering = (int)mySqlDataReader["idVerzekering"];
                        list.Add(inventaris);
                    }
                    return list;
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

        public Inventaris GetById(int id)
        {
            Inventaris inventaris = new Inventaris();
            try
            {
                using (SqlCommand command = new SqlCommand("TblInventarisReadOne", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader mySqlDataReader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);

                    while (mySqlDataReader.Read())
                    {
                        inventaris = new Inventaris();
                        inventaris.id = (int)mySqlDataReader["idInventaris"];
                        inventaris.label = mySqlDataReader["label"].ToString();
                        inventaris.idLokaal = (int)mySqlDataReader["idLokaal"];
                        inventaris.idObject = (int)mySqlDataReader["idObject"];
                        inventaris.aankoopjaar = (int)mySqlDataReader["aankoopjaar"];
                        inventaris.afschrijvingsperiode = (int)mySqlDataReader["afschrijvingsperiode"];
                        inventaris.historiek = mySqlDataReader["historiek"].ToString();
                        inventaris.isActief = Convert.ToBoolean(mySqlDataReader["isActief"]);
                        inventaris.isAanwezig = Convert.ToBoolean(mySqlDataReader["isAanwezig"]);
                        inventaris.idVerzekering = (int)mySqlDataReader["idVerzekering"];
                    }
                    return inventaris;
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

        public bool Update(Inventaris inventaris)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("TblInventarisUpdate", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", inventaris.id));
                    command.Parameters.Add(new SqlParameter("@label", inventaris.label));
                    command.Parameters.Add(new SqlParameter("@idLokaal", inventaris.idLokaal));
                    command.Parameters.Add(new SqlParameter("@idObject", inventaris.idObject));
                    command.Parameters.Add(new SqlParameter("@aankoopjaar", inventaris.aankoopjaar));
                    command.Parameters.Add(new SqlParameter("@afschrijvingsjaar", inventaris.afschrijvingsperiode));
                    command.Parameters.Add(new SqlParameter("@historiek", inventaris.historiek));
                    command.Parameters.Add(new SqlParameter("@isActief", Convert.ToInt32(inventaris.isActief)));
                    command.Parameters.Add(new SqlParameter("@isAanwezig", Convert.ToInt32(inventaris.isAanwezig)));
                    command.Parameters.Add(new SqlParameter("@idVerzekering", inventaris.idVerzekering));
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