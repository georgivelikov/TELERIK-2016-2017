using System.Linq;
using System.Threading.Tasks;

using Chat.Models.Contracts;

namespace Chat.MongoDb
{
    public interface IRepository<T>
        where T : IEntity
    {
        Task Add(T value);

        Task<IQueryable<T>> All();

        Task Delete(object id);

        Task Delete(T obj);
    }
}
