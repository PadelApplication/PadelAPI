using MediatR;
using PadelAPI.Models;
using PadelAPI.Queries;
using PadelAPI.Repository;

namespace PadelAPI.Handlers
{
    public class GetPadelSessionByIdHandler : IRequestHandler<GetPadelSessionByIdQuery, PadelSession>
    {
        private readonly IPadelRepository _repository;

        public GetPadelSessionByIdHandler(IPadelRepository repository)
        {
            _repository = repository;
        }

        public async Task<PadelSession> Handle(GetPadelSessionByIdQuery request, CancellationToken cancellationToken)
        {
            var padelSession = await _repository.GetPadelSessionByIdAsync(request.Id);
            return padelSession;
        }
    }
}
