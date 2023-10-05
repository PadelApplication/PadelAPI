using MediatR;
using PadelAPI.Models;

namespace PadelAPI.Repository
{
    public interface IPadelRepository
    {
        Task<IEnumerable<Padel>> GetAllPadelSessionsAsync();
        Task<Padel> GetPadelSessionByIdAsync(Guid id);
        Task<Padel> CreateNewPadelSessionAsync(Padel padel);
        Task UpdatePadelSessionAsync(Padel padel);

    }
}
