using MediatR;

namespace MyAwesomeDecks.Application.Commands.CardCommands.DeleteCard
{
    public class DeleteCardCommand : IRequest
    {
        public DeleteCardCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
