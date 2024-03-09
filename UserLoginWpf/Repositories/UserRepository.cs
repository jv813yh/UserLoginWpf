using System.Data;
using System.Data.SqlClient;
using System.Net;
using UserLoginWpf.Interfaces;
using UserLoginWpf.Models;

namespace UserLoginWpf.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public bool Authenticate(NetworkCredential credential)
        {
            bool validUser = false;

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM [User] WHERE [Username]=@Username AND [Password]=@Password", connection))
                {
                    command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = credential.UserName;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = credential.Password;

                    validUser = (command.ExecuteScalar()) == null ? false : true;
                }
            }

            return validUser;
        }

        public User? GetByName(string name)
        {
            User? returnUser = null;

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM [User] WHERE [Username]=@Username", connection))
                {
                    command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = name;

                    using(var reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            returnUser = new User
                            {
                                Id = reader.GetGuid(0),
                                Username = reader.GetString(1),
                                Password = string.Empty,
                                Name = reader.GetString(3),
                                LastName = reader.GetString(4),
                                Email = reader.GetString(5)
                            };
                        }
                    }
                }
            }

            return returnUser;
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
