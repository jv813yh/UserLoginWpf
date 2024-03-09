using System.Net;
using UserLoginWpf.Models;

namespace UserLoginWpf.Interfaces
{
    public interface IUserRepository
    {
        bool Authenticate(NetworkCredential credential);
        void Add(User user);
        void Edit(User user);
        void Remove(Guid id);
        User GetById(Guid id);
        User? GetByName(string name);
        IEnumerable<User> GetAll();

        //.........
    }
}
