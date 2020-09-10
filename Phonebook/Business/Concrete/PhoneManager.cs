using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Model.Entities;

namespace Business.Concrete
{
    public class PhoneManager : IPhoneService
    {
        private readonly IPhonesDal _phonesDal;

        public PhoneManager(IPhonesDal phonesDal)
        {
            _phonesDal = phonesDal;
        }

        public void Add(Phones entity)
        {
            _phonesDal.Add(entity);
        }

        public void Delete(Phones entity)
        {
            _phonesDal.Delete(entity);
        }

        public Phones GetPhoneByPhoneId(int? phoneId)
        {
            return _phonesDal.Get(x => x.PhoneId == phoneId && x.Status);
        }

        public List<Phones> GetPhoneListByUserId(int userId)
        {
            return _phonesDal.GetList(x => x.UserId == userId && x.Status);
        }

        public void Update(Phones entity)
        {
            _phonesDal.Update(entity);
        }
    }
}
