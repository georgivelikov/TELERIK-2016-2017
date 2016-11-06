using MongoDB.Bson;

namespace Chat.Models.Contracts
{
    public interface IEntity
    {
        string Id { get; set; }
    }
}
