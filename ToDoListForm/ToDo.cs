using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListForm
{
    public class ToDo
    {
        public enum Levels
        {
            NotImportant,
            Important,
            Urgent
        }

        public ToDo(string category, string description, DateTime date, Levels priority)
        {
            Category = category;
            Description = description;
            Date = date;
            Priority = priority;
        }

        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Levels Priority { get; set; }

        public override string ToString()
        {
            return this.Date + " - " + this.Category + " - " + this.Description + " (" + this.Priority + " )";
        }
    }
}
