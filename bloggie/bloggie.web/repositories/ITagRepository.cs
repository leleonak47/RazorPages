using bloggie.web.Models.Domain;

namespace bloggie.web.repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
