using MegaMaster_Domain.Business;
using MySql.Data.MySqlClient;
using MySql.Data;   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMaster_Domain.Persistence
{
    internal class Persistcode
    {

        //fields
        private string _connectionString;
        //properties

        //constructor
        public Persistcode()
        {
            _connectionString = "server = localhost; database = masterminddb; user id = root; password = 1234";
        }
        public Persistcode(string connstring)
        {
            _connectionString = connstring;
        }




        //methode

        public List<GameResult> GetScoreFromDB()
        {
            List<GameResult> Scorebord = new List<GameResult>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            string command = "SELECT * FROM masterminddb.user";
            MySqlCommand cmd = new MySqlCommand(command, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                GameResult score = new GameResult
                (
                   Convert.ToString(dr[1]),
                   Convert.ToInt32(dr[0])
                );
                Scorebord.Add(score);
            }
            conn.Close();
            return Scorebord;
        }

        public void InsertIntoDB(string playerName, Int32 attempts)
        {
            string invoer = "INSERT INTO masterminddb.user (nameUser, pogingen) VALUES (@play, @attem)";
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd_insert = new MySqlCommand(invoer, conn);

            
            cmd_insert.Parameters.AddWithValue("@play", playerName);
            cmd_insert.Parameters.AddWithValue("@attem", attempts);

            conn.Open();
            cmd_insert.ExecuteNonQuery();
            conn.Close();
        }

    }
}

