using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblNetwerk : ICrudable<Netwerk>
    {
        SqlConnection connection = new SqlConnection("Data Source=92.222.220.213,1500;Initial Catalog=CvoInventarisdb;Persist Security Info=True;User ID=sa;Password=grati#s1867");

        public int Create(Netwerk netwerk)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("TblNetwerkInsert", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@merk", netwerk.Merk));
                    command.Parameters.Add(new SqlParameter("@type", netwerk.Type));
                    command.Parameters.Add(new SqlParameter("@snelheid", netwerk.Snelheid));
                    command.Parameters.Add(new SqlParameter("@driver", netwerk.Driver));
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch
            {
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
                using (SqlCommand command = new SqlCommand("TblNetwerkDelete", connection))
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

        public List<Netwerk> GetAll()
        {
            List<Netwerk> list = new List<Netwerk>();
            Netwerk netwerk;
            try
            {
                using (SqlCommand command = new SqlCommand("TblNetwerkReadAll", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader mySqlDataReader = command.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {
                        netwerk = new Netwerk();
                        netwerk.Id = (int)mySqlDataReader["idNetwerk"];
                        netwerk.Merk = mySqlDataReader["merk"].ToString();
                        netwerk.Type = mySqlDataReader["type"].ToString();
                        netwerk.Snelheid = mySqlDataReader["snelheid"].ToString();
                        netwerk.Driver = mySqlDataReader["driver"].ToString();
                        list.Add(netwerk);
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

        public Netwerk GetById(int id)
        {
            Netwerk netwerk = new Netwerk();
            try
            {
                using (SqlCommand command = new SqlCommand("TblNetwerkReadOne", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader mySqlDataReader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);

                    while (mySqlDataReader.Read())
                    {
                        netwerk = new Netwerk();
                        netwerk.Id = (int)mySqlDataReader["idNetwerk"];
                        netwerk.Merk = mySqlDataReader["merk"].ToString();
                        netwerk.Type = mySqlDataReader["type"].ToString();
                        netwerk.Snelheid = mySqlDataReader["snelheid"].ToString();
                        netwerk.Driver = mySqlDataReader["driver"].ToString();
                    }
                    return netwerk;
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

        public bool Update(Netwerk netwerk)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("TblNetwerkUpdate", connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", netwerk.Id));
                    command.Parameters.Add(new SqlParameter("@merk", netwerk.Merk));
                    command.Parameters.Add(new SqlParameter("@type", netwerk.Type));
                    command.Parameters.Add(new SqlParameter("@snelheid", netwerk.Snelheid));
                    command.Parameters.Add(new SqlParameter("@driver", netwerk.Driver));
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