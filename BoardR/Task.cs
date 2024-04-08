using BoardR.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR
{
    public class Task : BoardItem
    {
        private string _assignee;
        public Task(string title, string asignee, DateTime dueDate)
            : base(title, dueDate, Status.ToDo)
        {
            ValidationHelpers.ValidateString(asignee, "Asignee");
            _assignee = asignee;
            AddEventLog();
        }

        public string Assignee
        {
            get
            {
                return _assignee;
            }
            set
            {
                
                ValidationHelpers.ValidateString(value,"Asignee");
                _history.Add(new EventLog($"Asignee changed from '{_assignee}' to '{value}'"));
                _assignee = value;
            }
        }
    }
}
