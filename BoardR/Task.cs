using BoardR.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BoardR
{
    public class Task : BoardItem
    {
        private string _assignee;
        public Task(string title, string asignee, DateTime dueDate, Status status = Status.ToDo)
            : base(title, dueDate, status)
        {
            ValidationHelpers.ValidateString(asignee, "Asignee");
            _assignee = asignee;
            CreateEventLog();
        }

        public string Assignee
        {
            get
            {
                return _assignee;
            }
            set
            {

                ValidationHelpers.ValidateString(value, "Asignee");
                ChangeEventLog(_assignee, value, "Asignee");
                _assignee = value;
            }
        }
    }
}
