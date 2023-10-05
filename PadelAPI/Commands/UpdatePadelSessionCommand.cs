using MediatR;
using PadelAPI.Models;
using static MongoDB.Driver.WriteConcern;

namespace PadelAPI.Commands
{
    public class UpdatePadelSessionCommand : IRequest<bool>
    {
        public Padel UpdatedPadel {  get; set; }
    }
}
