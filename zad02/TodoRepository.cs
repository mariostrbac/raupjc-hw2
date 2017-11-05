using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad02
{
    /// <summary>
    /// Class that encapsulates all the logic for accessing TodoItems.
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList <TodoItem> _inMemoryTodoDateBase;
		
        public TodoRepository (IGenericList <TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDateBase = initialDbState;
            }
            else
            {
                _inMemoryTodoDateBase = new GenericList<TodoItem>();
            }
        }


        public TodoItem Get(Guid todoId) //mozda bez ovih if-ova, samo return
        {
            if (_inMemoryTodoDateBase.Any(t => t.Id.Equals(todoId)))
            {
                return _inMemoryTodoDateBase.First(t => t.Id.Equals(todoId));
            }

            return null;
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (todoItem != null)
            {
                if (Get(todoItem.Id) != null)
                {
                    throw new System.ArgumentException("duplicate id:",
                        todoItem.Id.ToString()); //DuplicateTodoItemException
                }

                _inMemoryTodoDateBase.Add(todoItem);
                return todoItem;
            }
            return null;
        }

        public bool Remove(Guid todoId)
        {
            if (Get(todoId) != null)
            {
                TodoItem removeItem = Get(todoId);
                _inMemoryTodoDateBase.Remove(removeItem);
                return true;
            }
            return false;
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (todoItem != null)
            {
                if (Get(todoItem.Id) == null)
                {
                    Add(todoItem);
                }
                else
                {
                    Remove(todoItem.Id);
                    Add(todoItem);
                }
                return todoItem;
            }
            return null;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            if (Get(todoId) != null)
            {
                return Get(todoId).MarkAsCompleted();
            }
            return false;
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDateBase.AsEnumerable().OrderByDescending(i => i.Id).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return GetAll().FindAll(item => !item.IsCompleted);
        }

        public List<TodoItem> GetCompleted()
        {
            return GetAll().FindAll(item => item.IsCompleted);
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return GetAll().Where(filterFunction).ToList();
        }
    }
}
