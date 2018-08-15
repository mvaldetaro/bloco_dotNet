using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Domain;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Repository
{
    public class FriendsRepository
    {
        public IEnumerable<Friend> GetAllFriends()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C: \Users\Magno\Google Drive\ADS\dotNet\02_fundamentos_asp_net\pratica\WebApplication\WebApplication\App_Data\Database.mdf';Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Friends";
                var selectCommand = new SqlCommand(commandText, connection);

                var friends = new List<Friend>();

                try
                {
                    connection.Open();

                    using(var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read()) {
                            var friend = new Friend();

                            friend.FriendId = (int)reader["FriendId"];
                            friend.FirstName = reader["FirstName"].ToString();
                            friend.LastName = reader["LastName"].ToString();
                            friend.BirthDate = (DateTime)reader["BirthDate"];

                            friends.Add(friend);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }

                return friends;
            }
        }
    }
}