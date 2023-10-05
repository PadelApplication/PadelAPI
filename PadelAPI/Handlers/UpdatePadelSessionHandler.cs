using Amazon.Runtime.Internal;
using MediatR;
using PadelAPI.Commands;
using PadelAPI.Repository;

namespace PadelAPI.Handlers
{
    public class UpdatePadelSessionCommandHandler : IRequestHandler<UpdatePadelSessionCommand, bool>
    {
        private readonly IPadelRepository _padelRepository;

        public UpdatePadelSessionCommandHandler(IPadelRepository padelRepository)
        {
            _padelRepository = padelRepository;
        }

        public async Task<bool> Handle(UpdatePadelSessionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _padelRepository.UpdatePadelSessionAsync(request.UpdatedPadel);
                return true; // Indicate success
            }
            catch
            {
                return false; // Handle exceptions or validation errors as needed.
            }
        }
    }


}
