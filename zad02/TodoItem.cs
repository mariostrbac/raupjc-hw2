using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad02
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get { return DateCompleted.HasValue; } }
        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public TodoItem(string text)
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;

            Text = text;
        }

        public bool MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }
            return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            if (!(obj is TodoItem)) return false;

            TodoItem s = (TodoItem)obj;

            return s.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
