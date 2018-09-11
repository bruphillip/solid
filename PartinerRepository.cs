using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AulaSolid
{
    class PartinerRepository : IPartinerRepository
    {

        public List<Partiner> GetAll()
        {
            List<Partiner> partiners = new List<Partiner>();
            using (var cn = new SqlConnection())
            {
                var cmd = new SqlCommand();

                cn.ConnectionString = "MinhaConnectionString";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT ID, NOME, EMAIL FROM PARTICIPANTE";
                cn.Open();
                IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    partiners.Add(new Partiner(int.Parse(reader["ID"].ToString()), reader["NOME"].ToString(), reader["EMAIL"].ToString()));
                }
            }
            return partiners;
        }

        public void Insert(Partiner partiner)
        {
            using (var cn = new SqlConnection())
            {
                var cmd = new SqlCommand();

                cn.ConnectionString = "MinhaConnectionString";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO PARTICIPANTE (NOME, EMAIL) VALUES (@nome, @email)";

                cmd.Parameters.AddWithValue("nome", partiner.Nome);
                cmd.Parameters.AddWithValue("email", partiner.Email);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
