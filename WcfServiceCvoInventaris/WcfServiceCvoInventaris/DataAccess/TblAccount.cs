﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServiceCvoInventaris.DataAccess.Interfaces;
using WcfServiceCvoInventaris.Helpers;

namespace WcfServiceCvoInventaris.DataAccess
{
    public class TblAccount : ICrudable<Account>
    {
        #region Get Connection String
        private string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["CvoInventarisDBConnection"].ConnectionString;
        }
        #endregion

        #region CRUD TblAccount
        public Account GetById(int id)
        {
            Account acc = new Account();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblAccountReadOne", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        result.Read();
                        acc.IdAccount = (int)result["IdAccount"];
                        acc.Type = result["Type"].ToString();
                        acc.Gebruikersnaam = result["Gebruikersnaam"].ToString();
                        acc.Voornaam = result["Voornaam"].ToString();
                        acc.Achternaam = result["Achternaam"].ToString();
                        acc.Telefoonnummer = result["Telefoonnummer"].ToString();
                        acc.Email = result["Email"].ToString();
                        acc.Wachtwoord = result["Wachtwoord"].ToString();
                    }
                }
                catch
                {
                }
            }
            return acc;
        }

        public List<Account> GetAll()
        {
            List<Account> accs = new List<Account>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblAccountReadAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            Account acc = new Account();
                            acc.IdAccount = (int)result["IdAccount"];
                            acc.Type = result["Type"].ToString();
                            acc.Gebruikersnaam = result["Gebruikersnaam"].ToString();
                            acc.Voornaam = result["Voornaam"].ToString();
                            acc.Achternaam = result["Achternaam"].ToString();
                            acc.Telefoonnummer = result["Telefoonnummer"].ToString();
                            acc.Email = result["Email"].ToString();
                            acc.Wachtwoord = result["Wachtwoord"].ToString();
                            accs.Add(acc);
                        }
                    }
                }
                catch
                {
                }
            }
            return accs;
        }

        public int Create(Account acc)
        {
            int affected = 0;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblAccountInsert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Type", acc.Type);
                cmd.Parameters.AddWithValue("@Gebruikersnaam", acc.Gebruikersnaam);
                cmd.Parameters.AddWithValue("@Voornaam", acc.Voornaam);
                cmd.Parameters.AddWithValue("@Achternaam", acc.Achternaam);
                cmd.Parameters.AddWithValue("@Telefoonnummer", acc.Telefoonnummer);
                cmd.Parameters.AddWithValue("@Email", acc.Email);
                cmd.Parameters.AddWithValue("@Wachtwoord", PasswordStorage.CreateHash(acc.Wachtwoord));

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

        public bool Update(Account acc)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblAccountUpdate", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdAccount", acc.IdAccount);
                cmd.Parameters.AddWithValue("@Type", acc.Type);
                cmd.Parameters.AddWithValue("@Gebruikersnaam", acc.Gebruikersnaam);
                cmd.Parameters.AddWithValue("@Voornaam", acc.Voornaam);
                cmd.Parameters.AddWithValue("@Achternaam", acc.Achternaam);
                cmd.Parameters.AddWithValue("@Telefoonnummer", acc.Telefoonnummer);
                cmd.Parameters.AddWithValue("@Email", acc.Email);
                cmd.Parameters.AddWithValue("@Wachtwoord", PasswordStorage.CreateHash(acc.Wachtwoord));

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
                SqlCommand cmd = new SqlCommand("TblAccountDelete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdAccount", id);

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

        public Account GetByEmail(string email)
        {
            Account acc = new Account();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TblAccountReadByEmail", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", email);

                try
                {
                    con.Open();
                    SqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        result.Read();
                        acc.IdAccount = (int)result["IdAccount"];
                        acc.Type = result["Type"].ToString();
                        acc.Gebruikersnaam = result["Gebruikersnaam"].ToString();
                        acc.Voornaam = result["Voornaam"].ToString();
                        acc.Achternaam = result["Achternaam"].ToString();
                        acc.Telefoonnummer = result["Telefoonnummer"].ToString();
                        acc.Email = result["Email"].ToString();
                        acc.Wachtwoord = result["Wachtwoord"].ToString();
                    }
                }
                catch
                {
                }
            }
            return acc;
        }
    }
}