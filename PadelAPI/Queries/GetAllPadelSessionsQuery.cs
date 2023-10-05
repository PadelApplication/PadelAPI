using MediatR;
using PadelAPI.Models;

namespace PadelAPI.Queries
{
    public class GetAllPadelSessionsQuery : IRequest<IEnumerable<PadelSession>>
    {
    }
}
