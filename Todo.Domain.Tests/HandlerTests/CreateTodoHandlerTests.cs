using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    //Cada if dentro do handler significa a criação de 2 testes, um para o SIM e outro para o NÃO
     [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("",System.DateTime.Now, "");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da Tarefa",System.DateTime.Now, "RenanPadovani");
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        public CreateTodoHandlerTests()
        {
            
        }   

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(result.Success, true);
        }
    }
}