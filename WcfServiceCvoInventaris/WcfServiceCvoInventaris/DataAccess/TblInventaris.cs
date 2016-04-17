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
                    command.Parameters.Add(new SqlParameter("@Label", inventaris.Label));
                    command.Parameters.Add(new SqlParameter("@idLokaal", inventaris.IdLokaal));
                    command.Parameters.Add(new SqlParameter("@idObject", inventaris.IdObject));
                    command.Parameters.Add(new SqlParameter("@aankoopjaar", inventaris.Aankoopjaar));
                    command.Parameters.Add(new SqlParameter("@afschrijvingsjaar", inventaris.Afschrijvingsperiode));
                    command.Parameters.Add(new SqlParameter("@historiek", inventaris.Historiek));
                    command.Parameters.Add(new SqlParameter("@isActief", Convert.ToInt32(inventaris.IsActief)));
                    command.Parameters.Add(new SqlParameter("@isAanwezig", Convert.ToInt32(inventaris.IsAanwezig)));
                    command.Parameters.Add(new SqlParameter("@idVerzekering", inventaris.IdVerzekering));
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
                        inventaris.Id = (int)mySqlDataReader["idInventaris"];
                        inventaris.Label = mySqlDataReader["Label"].ToString();
                        inventaris.IdLokaal = (int)mySqlDataReader["idLokaal"];
                        inventaris.IdObject = (int)mySqlDataReader["idObject"];
                        inventaris.Aankoopjaar = (int)mySqlDataReader["aankoopjaar"];
                        inventaris.Afschrijvingsperiode = (int)mySqlDataReader["afschrijvingsperiode"];
                        inventaris.Historiek = mySqlDataReader["historiek"].ToString();
                        inventaris.IsActief = Convert.ToBoolean(mySqlDataReader["isActief"]);
                        inventaris.IsAanwezig = Convert.ToBoolean(mySqlDataReader["isAanwezig"]);
                        inventaris.IdVerzekering = (int)mySqlDataReader["idVerzekering"];
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
                        inventaris.Id = (int)mySqlDataReader["idInventaris"];
                        inventaris.Label = mySqlDataReader["Label"].ToString();
                        inventaris.IdLokaal = (int)mySqlDataReader["idLokaal"];
                        inventaris.IdObject = (int)mySqlDataReader["idObject"];
                        inventaris.Aankoopjaar = (int)mySqlDataReader["aankoopjaar"];
                        inventaris.Afschrijvingsperiode = (int)mySqlDataReader["afschrijvingsperiode"];
                        inventaris.Historiek = mySqlDataReader["historiek"].ToString();
                        inventaris.IsActief = Convert.ToBoolean(mySqlDataReader["isActief"]);
                        inventaris.IsAanwezig = Convert.ToBoolean(mySqlDataReader["isAanwezig"]);
                        inventaris.IdVerzekering = (int)mySqlDataReader["idVerzekering"];
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
                    command.Parameters.Add(new SqlParameter("@id", inventaris.Id));
                    command.Parameters.Add(new SqlParameter("@Label", inventaris.Label));
                    command.Parameters.Add(new SqlParameter("@idLokaal", inventaris.IdLokaal));
                    command.Parameters.Add(new SqlParameter("@idObject", inventaris.IdObject));
                    command.Parameters.Add(new SqlParameter("@aankoopjaar", inventaris.Aankoopjaar));
                    command.Parameters.Add(new SqlParameter("@afschrijvingsjaar", inventaris.Afschrijvingsperiode));
                    command.Parameters.Add(new SqlParameter("@historiek", inventaris.Historiek));
                    command.Parameters.Add(new SqlParameter("@isActief", Convert.ToInt32(inventaris.IsActief)));
                    command.Parameters.Add(new SqlParameter("@isAanwezig", Convert.ToInt32(inventaris.IsAanwezig)));
                    command.Parameters.Add(new SqlParameter("@idVerzekering", inventaris.IdVerzekering));
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