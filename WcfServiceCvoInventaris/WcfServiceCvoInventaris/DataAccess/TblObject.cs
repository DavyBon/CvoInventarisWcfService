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
                    //command.Parameters.Add(new SqlParameter("@idObjectType", obj.IdObjectType));
                    command.Parameters.Add(new SqlParameter("@kenmerken", obj.Kenmerken));
                    //command.Parameters.Add(new SqlParameter("@idLeverancier", obj.IdLeverancier));
                    //command.Parameters.Add(new SqlParameter("@idFactuur", obj.IdFactuur));
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
            Object obj;
            try
            {
                using (SqlCommand command = new SqlCommand("TblObjectReadAll", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader mySqlDataReader = command.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {
                        obj = new Object();
                        obj.Id = (int)mySqlDataReader["idObject"];
                        //obj.IdObjectType = (int)mySqlDataReader["idObjectType"];
                        obj.Kenmerken = mySqlDataReader["kenmerken"].ToString();
                        //obj.IdLeverancier = (int)mySqlDataReader["idLeverancier"];
                        //obj.IdFactuur = (int)mySqlDataReader["idFactuur"];
                        list.Add(obj);
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

        public Object GetById(int id)
        {
            Object obj = new Object();
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

                        obj.Id = (int)mySqlDataReader["idObject"];
                        //obj.IdObjectType = (int)mySqlDataReader["idObjectType"];
                        obj.Kenmerken = mySqlDataReader["kenmerken"].ToString();
                        //obj.IdLeverancier = (int)mySqlDataReader["idLeverancier"];
                        //obj.IdFactuur = (int)mySqlDataReader["idFactuur"];

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
                    //command.Parameters.Add(new SqlParameter("@idObjectType", obj.IdObjectType));
                    command.Parameters.Add(new SqlParameter("@kenmerken", obj.Kenmerken));
                    //command.Parameters.Add(new SqlParameter("@idLeverancier", obj.IdLeverancier));
                    //command.Parameters.Add(new SqlParameter("@idFactuur", obj.IdFactuur));
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