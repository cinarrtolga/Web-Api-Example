using Business.Abstract;
using DataAccess.Abstract;
using Model.Entities;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUsersDal _usersDal;
        
        public UserManager(IUsersDal usersDal)
        {   
            _usersDal = usersDal;
        }

        public void Add(Users entity)
        {
            _usersDal.Add(entity);
        }

        public void Delete(Users entity)
        {
            _usersDal.Delete(entity);
        }

        public Users GetUserByEmailAndPassword(string email, string password)
        {
            return _usersDal.Get(x => x.Email == email && x.Password == x.Password && x.Status);
        }

        public Users GetUserById(int? id)
        {
            return _usersDal.Get(x => x.UserId == id && x.Status);
        }

        public void Update(Users entity)
        {
            _usersDal.Update(entity);
        }
    }
}
