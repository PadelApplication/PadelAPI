using MediatR;
using PadelAPI.Models;
using PadelAPI.Queries;
using PadelAPI.Repository;

namespace PadelAPI.Handlers
{
    public class GetAllPadelSessionsHandler : IRequestHandler<GetAllPadelSessionsQuery, IEnumerable<PadelSession>>
    {
        private readonly IPadelRepository _repository;

        public GetAllPadelSessionsHandler(IPadelRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PadelSession>> Handle(GetAllPadelSessionsQuery request, CancellationToken cancellationToken)
        {
            var padelSessions = await _repository.GetAllPadelSessionsAsync();
            return padelSessions;
        }
    }
}
