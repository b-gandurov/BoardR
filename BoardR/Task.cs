using BoardR.Helpers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace BoardR
{
    public class Task : BoardItem
    {
        private string _assignee;

        public string Assignee
        {
            get
            {
                return _assignee;
            }
            set
            {
                ValidationHelpers.ValidateString(value,"Asignee");
                AddActivityLog($"Assignee changed from '{_assignee}' to '{value}'.");
                _assignee = value;
            }
        }

        public Task(string title, string assignee, DateTime dueDate)
            : base(title, dueDate, Status.ToDo)
        {
            ValidationHelpers.ValidateString(assignee, "Asignee");
            _assignee = assignee;
            AddActivityLog($"Created Task: {_titleStatusDueDate}");
        }


    }
}
