﻿using System;
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
