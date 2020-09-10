using Model.Entities;

namespace Business.Abstract
{
    public interface IUserService
    {
        Users GetUserByEmailAndPassword(string email, string password);
        Users GetUserById(int? id);
        void Add(Users entity);
        void Update(Users entity);
        void Delete(Users entity);
    }
}
