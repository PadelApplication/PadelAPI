using MediatR;
using PadelAPI.Models;

namespace PadelAPI.Queries
{
    public class GetPadelSessionByIdQuery : IRequest<Padel>
    {
        public Guid Id { get; }

        public GetPadelSessionByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
