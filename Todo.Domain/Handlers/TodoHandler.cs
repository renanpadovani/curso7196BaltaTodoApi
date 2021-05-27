using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : 
        Notifiable<Notification>,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();

            if (command.IsValid == false)
                return new GenericCommandResult(false, "Ops, parece que algo deu errado", command.Notifications); 

            //Salvar to do no banco
            var todo = new TodoItem(command.Title, command.Date, command.User);

            _repository.Create(todo);
            
            //Notificar o usuário
            return new GenericCommandResult(true, "TODO criado com sucesso.", todo); 
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();

            if (command.IsValid == false)
                return new GenericCommandResult(false,"Ops, parece que sua tarefa está errada!", command.Notifications);

            //Recupera TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            //Altera o titulo
            todo.UpdateTitle(command.Title);

            //Salva no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true,"Tarefa salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            //Fail Fast Validation
            command.Validate();

            if (command.IsValid == false)
                return new GenericCommandResult(false,"Ops, parece que sua tarefa está errada!", command.Notifications);

            //Recupera TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            //Altera o estado
            todo.MarkAsDone();

            //Salva no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true,"Tarefa salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            //Fail Fast Validation
            command.Validate();

            if (command.IsValid == false)
                return new GenericCommandResult(false,"Ops, parece que sua tarefa está errada!", command.Notifications);

            //Recupera TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            //Altera o estado
            todo.MarkAsUndone();

            //Salva no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true,"Tarefa salva", todo);
        }
    }
}