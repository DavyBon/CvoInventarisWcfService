using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblSession : ICrudable<Session>
    {
        #region Get Connection String
        private string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["CvoInventarisDBConnection"].ConnectionString;
        }
        #endregion

        #region CRUD TblSession
        public Session GetById(int id)
        {
            Session ses = new Session();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblSessionReadOne", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        result.Read();
                        ses.IdSession = (int)result["IdSession"];
                        ses.IdAccount = (int)result["IdAccount"];
                        ses.Device = result["Device"].ToString();
                        ses.Tijdstip = (DateTime)result["Tijdstip"];
                    }
                }
                catch
                {
                }
            }
            return ses;
        }

        public List<Session> GetAll()
        {
            List<Session> sess = new List<Session>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblSessionReadAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            Session ses = new Session();
                            ses.IdSession = (int)result["IdSession"];
                            ses.IdAccount = (int)result["IdAccount"];
                            ses.Device = result["Device"].ToString();
                            ses.Tijdstip = (DateTime)result["Tijdstip"];
                            sess.Add(ses);
                        }
                    }
                }
                catch
                {
                }
            }
            return sess;
        }

        public int Create(Session ses)
        {
            int affected = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblSessionInsert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdAccount", ses.IdAccount);
                cmd.Parameters.AddWithValue("@Device", ses.Device);
                cmd.Parameters.AddWithValue("@Tijdstip", ses.Tijdstip);

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

        public bool Update(Session ses)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblSessionUpdate", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdSession", ses.IdSession);
                cmd.Parameters.AddWithValue("@IdAccount", ses.IdAccount);
                cmd.Parameters.AddWithValue("@Device", ses.Device);
                cmd.Parameters.AddWithValue("@Tijdstip", ses.Tijdstip);

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
                SqlCommand cmd = new SqlCommand("TblSessionDelete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdSession", id);

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