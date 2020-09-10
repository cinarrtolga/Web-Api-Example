using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Model.Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class PhonesDal : EntityFrameworkBase<Phones, MSSQLDatabaseContext> , IPhonesDal
    {
    }
}
