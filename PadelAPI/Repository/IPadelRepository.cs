using MediatR;
using PadelAPI.Models;

namespace PadelAPI.Repository
{
    public interface IPadelRepository
    {
        Task<IEnumerable<PadelSession>> GetAllPadelSessionsAsync();
        Task<PadelSession> GetPadelSessionByIdAsync(Guid id);
        Task<PadelSession> CreateNewPadelSessionAsync(PadelSession padel);
        Task UpdatePadelSessionAsync(PadelSession padel);
        Task DeletePadelSessionAsync(Guid id);
    }
}
