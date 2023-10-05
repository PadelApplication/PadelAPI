using MediatR;
using PadelAPI.Models;

namespace PadelAPI.Commands
{
    public class DeletePadelSessionCommand : IRequest<PadelSession>
    {
        public Guid Id { get; set; }

        public DeletePadelSessionCommand(Guid id)
        {
            Id = id;
        }
    }
}
