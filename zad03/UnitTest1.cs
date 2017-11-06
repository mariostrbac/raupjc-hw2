using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zad02;

namespace zad03
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetTodoItem()
        {
            TodoItem testItem = new TodoItem("Test item");
            Guid testId = testItem.Id;
            var repositoty = GetTodoRepository();

            repositoty.Add(testItem);

            Assert.AreEqual(testItem, repositoty.Get(testId));
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException),"Adding existing item.")]
        public void AddDuplicateItem()
        {
            TodoItem testItem = new TodoItem("Test item");
            var repositoty = GetTodoRepository();

            repositoty.Add(testItem);
            repositoty.Add(testItem);
        }

        [TestMethod]
        public void RemoveTodoItem()
        {
            TodoItem testItem = new TodoItem("Test item");
            Guid testId = testItem.Id;
            var repositoty = GetTodoRepository();

            repositoty.Add(testItem);
            Assert.AreEqual(testItem, repositoty.Get(testId));          //item added
            Assert.IsTrue(repositoty.Remove(testId));                   //item removed
            Assert.AreEqual(null, repositoty.Get(testId));              //returns null
        }

        [TestMethod]
        public void UpdateTodoItem()
        {
            TodoItem testItem = new TodoItem("Test item");
            Guid testId = testItem.Id;
            var repositoty = GetTodoRepository();

            Assert.AreEqual(testItem, repositoty.Update(testItem));     //new item 
            Assert.AreEqual(testItem, repositoty.Get(testId));          //item added
            Assert.IsFalse(repositoty.Get(testId).IsCompleted);         //item not completed
            testItem.MarkAsCompleted();
            Assert.AreEqual(testItem, repositoty.Update(testItem));     //already in repository
            Assert.AreEqual(testItem, repositoty.Get(testId));
            Assert.IsTrue(repositoty.Get(testId).IsCompleted);          //item updated
            Assert.AreEqual(null, repositoty.Update(null));             //invalid input
        }

        [TestMethod]
        public void MarkAsCompletedTest()
        {
            TodoItem testItem = new TodoItem("Test item");
            Guid testId = testItem.Id;
            var repositoty = GetTodoRepository();

            repositoty.Add(testItem);

            Assert.IsFalse(repositoty.Get(testId).IsCompleted);         //item not completed
            Assert.IsTrue(repositoty.MarkAsCompleted(testId));     
            Assert.IsTrue(repositoty.Get(testId).IsCompleted);          //item updated
            Assert.IsFalse(repositoty.MarkAsCompleted(testId));         //already completed
        }

        [TestMethod]
        public void GetAllItemsFromRepository()
        {
            var repositoty = GetTodoRepository();

            Assert.AreEqual(12, repositoty.GetAll().Count);
        }

        [TestMethod]
        public void GetActiveItemsFromRepository()
        {
            var repositoty = GetTodoRepository();
            var arrayRepository = repositoty.GetAll().ToArray();

            arrayRepository[0].MarkAsCompleted();
            arrayRepository[4].MarkAsCompleted();
            arrayRepository[7].MarkAsCompleted();

            Assert.AreEqual(9, repositoty.GetActive().Count);
        }

        [TestMethod]
        public void GetCompletedItemsFromRepository()
        {
            var repositoty = GetTodoRepository();
            var arrayRepository = repositoty.GetAll().ToArray();

            arrayRepository[0].MarkAsCompleted();
            arrayRepository[4].MarkAsCompleted();
            arrayRepository[7].MarkAsCompleted();

            Assert.AreEqual(3, repositoty.GetCompleted().Count);
        }

        [TestMethod]
        public void GetFilteredTest()
        {
            var repository = GetTodoRepository();

            Assert.AreEqual(0, repository.GetFiltered(item => item.IsCompleted).Count);
        }

        private static TodoRepository GetTodoRepository()
        {
            return new TodoRepository(new GenericList<TodoItem>
            {
                new TodoItem("todoItem01"),
                new TodoItem("todoItem02"),
                new TodoItem("todoItem03"),
                new TodoItem("todoItem04"),
                new TodoItem("todoItem05"),
                new TodoItem("todoItem06"),
                new TodoItem("todoItem07"),
                new TodoItem("todoItem08"),
                new TodoItem("todoItem09"),
                new TodoItem("todoItem10"),
                new TodoItem("todoItem11"),
                new TodoItem("todoItem12"),
            });

        }
    }
}
