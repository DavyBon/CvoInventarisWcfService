using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblTicketing : ICrudable<Ticket>
    {
        #region Get Connection String
        private string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["CvoInventarisDBConnection"].ConnectionString;
        }
        #endregion

        #region CRUD TblTicketing
        public Ticket GetById(int id)
        {
            Ticket tic = new Ticket();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblTicketingReadOne", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        result.Read();
                        tic.IdTicket = (int)result["IdTicket"];
                        tic.Verzender = result["Verzender"].ToString();
                        tic.Ontvanger = result["Ontvanger"].ToString();
                        tic.Tijdstip = (DateTime)result["Tijdstip"];
                        tic.Bericht = result["Bericht"].ToString();
                        tic.Status = result["Status"].ToString();
                    }
                }
                catch
                {
                }
            }
            return tic;
        }

        public List<Ticket> GetAll()
        {
            List<Ticket> tics = new List<Ticket>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblTicketingReadAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            Ticket tic = new Ticket();
                            tic.IdTicket = (int)result["IdTicket"];
                            tic.Verzender = result["Verzender"].ToString();
                            tic.Ontvanger = result["Ontvanger"].ToString();
                            tic.Tijdstip = (DateTime)result["Tijdstip"];
                            tic.Bericht = result["Bericht"].ToString();
                            tic.Status = result["Status"].ToString();
                            tics.Add(tic);
                        }
                    }
                }
                catch
                {
                }
            }
            return tics;
        }

        public int Create(Ticket tic)
        {
            int affected = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblTicketingInsert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Verzender", tic.Verzender);
                cmd.Parameters.AddWithValue("@Ontvanger", tic.Ontvanger);
                cmd.Parameters.AddWithValue("@Tijdstip", tic.Tijdstip);
                cmd.Parameters.AddWithValue("@Bericht", tic.Bericht);
                cmd.Parameters.AddWithValue("@Status", tic.Status);

                try
                {
                    con.Open();
                    affected = cmd.ExecuteNonQuery();
                }
                catch
                {
                }
            }
            return affected;
        }

        public bool Update(Ticket tic)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblTicketingUpdate", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdTicket", tic.IdTicket);
                cmd.Parameters.AddWithValue("@Verzender", tic.Verzender);
                cmd.Parameters.AddWithValue("@Ontvanger", tic.Ontvanger);
                cmd.Parameters.AddWithValue("@Tijdstip", tic.Tijdstip);
                cmd.Parameters.AddWithValue("@Bericht", tic.Bericht);
                cmd.Parameters.AddWithValue("@Status", tic.Status);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblTicketingDelete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdTicket", id);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        #endregion
    }
}