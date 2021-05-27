using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsDoneCommand : Notifiable<Notification>, ICommand
    {
        public MarkTodoAsDoneCommand() {}
        public MarkTodoAsDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract<MarkTodoAsDoneCommand>()
                    .Requires()
                    .IsLowerThan(User, 6, "User","Usuário inválido!")        
            );
        }
    }
}