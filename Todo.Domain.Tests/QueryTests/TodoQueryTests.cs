using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", System.DateTime.Now, "usuarioA"));
            _items.Add(new TodoItem("Tarefa 2", System.DateTime.Now, "usuarioA"));
            _items.Add(new TodoItem("Tarefa 3", System.DateTime.Now, "renanPadovani"));
            _items.Add(new TodoItem("Tarefa 4", System.DateTime.Now, "usuarioA"));
            _items.Add(new TodoItem("Tarefa 5", System.DateTime.Now, "renanPadovani"));
        }

        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_renanPadovani()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("renanPadovani"));
            Assert.AreEqual(2, result.Count());
        }
    }
}