using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServiceCvoInventaris.DataAccess;
using System.Data;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblVerzekering : ICrudable<Verzekering>
    {
        private string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["CvoInventarisDBConnection"].ConnectionString;
        }
        public int Create(Verzekering t)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblVerzekeringInsert", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Omschrijving", t.Omschrijving);
                SqlParameter id = new SqlParameter("@idVerzekering", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                command.Parameters.Add(id);
                try
                {
                    con.Open();
                    result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        result = (int)id.Value;
                    }
                }
                catch{ }
            }

            return result;
        }

        public int Delete(int id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblVerzekeringDelete", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("idVerzekering", id);
                try
                {
                    con.Open();
                    result = command.ExecuteNonQuery();
                }
                catch{ }
            }

            return result;
        }

        public List<Verzekering> GetAll()
        {
            List<Verzekering> verzekeringen = new List<Verzekering>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblVerzekeringReadAll", con);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Verzekering verzekering = new Verzekering();
                            verzekering.Id = (int)reader["idVerzekering"];
                            verzekering.Omschrijving = reader["omschrijving"].ToString();
                            verzekeringen.Add(verzekering);
                        }
                    }
                }
                catch  { }
            }

            return verzekeringen;
        }

        public Verzekering GetById(int id)
        {
            Verzekering verzekering = new Verzekering();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblVerzekeringReadOne", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idVerzekering", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        verzekering.Id = (int)reader["idVerzekering"];
                        verzekering.Omschrijving = reader["omschrijving"].ToString();
                    }
                }
                catch  { }
            }

            return verzekering;
        }

        public int Update(Verzekering t)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblVerzekeringUpdate", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idVerzekering", t.Id);
                command.Parameters.AddWithValue("@Omschrijving", t.Omschrijving);
                try
                {
                    con.Open();
                    result = command.ExecuteNonQuery();
                }
                catch  { }
            }

            return result;
        }
    }
}