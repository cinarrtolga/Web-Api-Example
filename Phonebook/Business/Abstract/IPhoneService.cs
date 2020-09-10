using System.Collections.Generic;
using Model.Entities;

namespace Business.Abstract
{
    public interface IPhoneService
    {
        Phones GetPhoneByPhoneId(int? phoneId);
        List<Phones> GetPhoneListByUserId(int userId);
        void Add(Phones entity);
        void Update(Phones entity);
        void Delete(Phones entity);
    }
}
