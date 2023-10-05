using MediatR;
using PadelAPI.Commands;
using PadelAPI.Models;
using PadelAPI.Repository;
using static PadelAPI.Commands.DeletePadelSessionCommand;

namespace PadelAPI.Handlers
{
    public class DeletePadelSessionHandler : IRequestHandler<DeletePadelSessionCommand, PadelSession>
    {
        private readonly IPadelRepository _padelRepository;

        public DeletePadelSessionHandler(IPadelRepository padelRepository)
        {
            _padelRepository = padelRepository;
        }

        public async Task<PadelSession> Handle(DeletePadelSessionCommand command, CancellationToken cancellationToken)
        {
            var padeldetails = await _padelRepository.GetPadelSessionByIdAsync(command.Id);
            if (padeldetails == null)
            {
                return null;
            }
           
            await _padelRepository.DeletePadelSessionAsync(padeldetails.Id);
            return padeldetails; 
        }
    }
}
