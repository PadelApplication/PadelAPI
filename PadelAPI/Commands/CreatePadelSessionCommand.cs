using MediatR;
using PadelAPI.Models;

namespace PadelAPI.Commands
{
    public class CreatePadelSessionCommand : IRequest<Padel>
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Place { get; set; }
        public string Court { get; set; }
        public int People { get; set; }

        public CreatePadelSessionCommand(string title, string date, string time, string place, string court ,int people)
        {
            Title = title;
            Date = date;
            Time = time;
            Place = place;
            Court = court;
            People = people;
        }
    }
}
