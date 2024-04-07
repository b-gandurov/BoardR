using BoardR.Helpers;
using System;

namespace BoardR
{
    public class Issue : BoardItem
    {
        private string _description;

        public Issue(string title, string description, DateTime dueDate)
            : base(title, dueDate, Status.Open)
        {
            ValidationHelpers.ValidateString(title, "Description");
            _description = description;
            AddActivityLog($"Created Issue: {_titleStatusDueDate}. Description: {Description}");
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                ValidationHelpers.ValidateString(value, "Asignee");
                AddActivityLog($"Description changed from '{_description}' to '{value}'.");
                _description = value;
            }
        }
    }
}
