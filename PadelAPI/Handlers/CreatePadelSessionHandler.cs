using MediatR;
using PadelAPI.Commands;
using PadelAPI.Models;
using PadelAPI.Repository;

namespace PadelAPI.Handlers
{
    public class CreatePadelSessionHandler : IRequestHandler<CreatePadelSessionCommand, PadelSession>
    {
        private readonly IPadelRepository _repository;

        public CreatePadelSessionHandler(IPadelRepository repository)
        {
            _repository = repository;
        }

        public async Task<PadelSession> Handle(CreatePadelSessionCommand command, CancellationToken cancellationToken)
        {
            var padel = new PadelSession()
            {
                Title = command.Title,
                Date = command.Date,
                Time = command.Time,
                Place = command.Place,
                Court = command.Court,
                People = command.People

            };

            return await _repository.CreateNewPadelSessionAsync(padel);
        }

    }

}
