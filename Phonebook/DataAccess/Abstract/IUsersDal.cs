using Core.DataAccess;
using Model.Entities;

namespace DataAccess.Abstract
{
    public interface IUsersDal : IEntityRepository<Users>
    {
    }
}
