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
                    command.Parameters.Add(new SqlParameter("@merk", netwerk.merk));
                    command.Parameters.Add(new SqlParameter("@type", netwerk.type));
                    command.Parameters.Add(new SqlParameter("@snelheid", netwerk.snelheid));
                    command.Parameters.Add(new SqlParameter("@driver", netwerk.driver));
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
                        netwerk.id = (int)mySqlDataReader["idNetwerk"];
                        netwerk.merk = mySqlDataReader["merk"].ToString();
                        netwerk.type = mySqlDataReader["type"].ToString();
                        netwerk.snelheid = mySqlDataReader["snelheid"].ToString();
                        netwerk.driver = mySqlDataReader["driver"].ToString();
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
                        netwerk.id = (int)mySqlDataReader["idNetwerk"];
                        netwerk.merk = mySqlDataReader["merk"].ToString();
                        netwerk.type = mySqlDataReader["type"].ToString();
                        netwerk.snelheid = mySqlDataReader["snelheid"].ToString();
                        netwerk.driver = mySqlDataReader["driver"].ToString();
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
                    command.Parameters.Add(new SqlParameter("@id", netwerk.id));
                    command.Parameters.Add(new SqlParameter("@merk", netwerk.merk));
                    command.Parameters.Add(new SqlParameter("@type", netwerk.type));
                    command.Parameters.Add(new SqlParameter("@snelheid", netwerk.snelheid));
                    command.Parameters.Add(new SqlParameter("@driver", netwerk.driver));
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
        public List<Netwerk> Rapportering(string s, string[] keuzeKolommen)
        {
            List<Netwerk> list = new List<Netwerk>();
            Netwerk netwerk;
            try
            {
                using (SqlCommand command = new SqlCommand(s, connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader mySqlDataReader = command.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {
                        netwerk = new Netwerk();
                        if (keuzeKolommen.Contains("idNetwerk")) { netwerk.id = (int)mySqlDataReader["idNetwerk"]; }
                        if (keuzeKolommen.Contains("merk")) { netwerk.merk = mySqlDataReader["merk"].ToString(); }
                        if (keuzeKolommen.Contains("type")) { netwerk.type = mySqlDataReader["type"].ToString(); }
                        if (keuzeKolommen.Contains("snelheid")) { netwerk.snelheid = mySqlDataReader["snelheid"].ToString(); }
                        if (keuzeKolommen.Contains("driver")) { netwerk.driver = mySqlDataReader["driver"].ToString(); }
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
    }
}