using System.Net;
using UserLoginWpf.Models;

namespace UserLoginWpf.Interfaces
{
    public interface IUserRepository
    {
        bool Authenticate(NetworkCredential credential);
        User? GetByName(string name);
        void Add(User user);
        void Edit(User user);
        void Remove(Guid id);
        User GetById(Guid id);
        IEnumerable<User> GetAll();

        //.........
    }
}
