using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR
{
    class Issue : BoardItem
    {
        private string _description;
        public Issue(string title, string description, DateTime dueDate, Status status = Status.Open)
            : base(title, dueDate, status)
        {

            if (string.IsNullOrEmpty(description))
            {
                _description = "No description";
            }
            else
            {
                _description = description;
            }

            CreateEventLog(_description);
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }


    }
}
