using MediatR;
using PadelAPI.Models;

namespace PadelAPI.Queries
{
    public class GetPadelSessionByIdQuery : IRequest<PadelSession>
    {
        public Guid Id { get; }

        public GetPadelSessionByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
