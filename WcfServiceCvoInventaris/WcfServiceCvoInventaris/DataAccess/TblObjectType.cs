using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using WcfServiceCvoInventaris.DataAccess.Interfaces;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblObjectType : ICrudable<ObjectTypes>
    {

        public int Create(ObjectTypes t)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TbIObjectTypeInsert", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Omschrijving", t.Omschrijving);
                SqlParameter id = new SqlParameter("@idObjectType", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                command.Parameters.Add(id);
                try
                {
                    con.Open();
                    result = command.ExecuteNonQuery();
                }
                catch   { }
            }

            return result;
        }

        public int Delete(int id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TbIObjectTypeDelete", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idObjectType", id);
                try
                {
                    con.Open();
                    result = command.ExecuteNonQuery();
                }
                catch   { }
            }

            return result;
        }

        public List<ObjectTypes> GetAll()
        {
            List<ObjectTypes> objectTypes = new List<ObjectTypes>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblObjectTypeReadAll", con);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ObjectTypes objectType = new ObjectTypes();
                            objectType.Id = (int)reader["idObjectType"];
                            objectType.Omschrijving = reader["omschrijving"].ToString();
                            objectTypes.Add(objectType);
                        }
                    }
                }
                catch{ }
            }

            return objectTypes;
        }

        public ObjectTypes GetById(int id)
        {
            ObjectTypes objectTypes = new ObjectTypes();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblObjectTypeReadOne", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idObjectType", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        objectTypes.Id = (int)reader["idObjectType"];
                        objectTypes.Omschrijving = reader["omschrijving"].ToString();
                    }
                }
                catch   { }
            }

            return objectTypes;
        }

        public int Update(ObjectTypes t)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("TblObjectTypeUpdate", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idObjectType", t.Id);
                command.Parameters.AddWithValue("@Omschrijving", t.Omschrijving);
                try
                {
                    con.Open();
                    result = command.ExecuteNonQuery();
                }
                catch   { }
            }

            return result;
        }

        private string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["CvoInventarisDBConnection"].ConnectionString;
        }

    }
}