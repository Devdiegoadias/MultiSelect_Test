using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class OperadorDAL : IOperador
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-Sample-MultiSelect-20151216084603;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        public void AddOperador(Operador Operador)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"Insert into operador (Id, Nome) 
                                                        Values(@Id, @Nome)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", Operador.Id);
                cmd.Parameters.AddWithValue("@Nome", Operador.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteOperador(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from Operador where Id = @OperadorId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@OperadorId", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public IEnumerable<Operador> GetAllOperadors()
        {
            List<Operador> lstOperador = new List<Operador>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT id, Nome from Operador", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Operador Operador = new Operador();
                    Operador.Id = Convert.ToInt32(rdr["Id"]);
                    Operador.Nome = rdr["Nome"].ToString();

                    lstOperador.Add(Operador);
                }
                con.Close();
            }
            return lstOperador;
        }

        public Operador GetOperador(int? id)
        {
            Operador Operador = new Operador();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Operador WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Operador.Id = Convert.ToInt32(rdr["Id"]);
                    Operador.Nome = rdr["Nome"].ToString();
                }
            }
            return Operador;
        }

        public void UpdateOperador(Operador Operador)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Update operador set Nome = @Nome where FuncionarioId = @OperadorId";

                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@OperadorId", Operador.Id);
                cmd.Parameters.AddWithValue("@Nome", Operador.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<Role> GetRolesOperador(int? id)
        {
            Role r = new Role();
            List<Role> lst = new List<Role>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM OperadorRole o join role r on r.id= o.idRole WHERE IdOperador= " + id;

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    r = new Role();
                    r.Id = Convert.ToInt32(rdr["IdRole"]);
                    r.Nome = rdr["NomeRole"].ToString();
                    lst.Add(r);

                }
            }
            return lst;
        }

        public List<Role> GetRoles()
        {
            Role r = new Role();
            List<Role> lst = new List<Role>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Role ";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    r = new Role();
                    r.Id = Convert.ToInt32(rdr["Id"]);
                    r.Nome = rdr["NomeRole"].ToString();
                    lst.Add(r);

                }
            }
            return lst;
        }

    }
}