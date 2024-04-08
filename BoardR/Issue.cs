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
        public Issue(string title, string description, DateTime dueDate)
            : base(title, dueDate, Status.Open)
        {

            if (string.IsNullOrEmpty(description))
            {
                _description = "No description";
            }
            else
            {
                _description = description;
            }

            AddEventLog(_description);
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
