using BoardR.Helpers;
using System;
using System.Text;

namespace BoardR
{
    public class BoardItem
    {
        protected string _title;
        protected DateTime _dueDate;
        protected Status _status;
        private List<EventLog> _history = new List<EventLog>();
        protected string dateFormat = "dd-MM-yyyy";
        protected string _titleStatusDueDate;
 
        

        public BoardItem(string title, DateTime dueDate, Status status = Status.Open)
        {
            ValidationHelpers.ValidateString(title, "Title");
            _title = title;
            _dueDate = dueDate;
            _status = status;
            _titleStatusDueDate = $"'{_title}', [{_status}|{_dueDate.ToString(dateFormat)}]";

    }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                ValidationHelpers.ValidateString(value, "Title");
                _history.Add(new EventLog($"Title changed from '{_title}' to '{value}'"));
                _title = value;
            }
        }

        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                if (value >= DateTime.Now)
                {
                    string message = $"DueDate changed from '{_dueDate.ToString(dateFormat)}' to '{value.ToString(dateFormat)}'";
                    _history.Add(new EventLog(message));
                    _dueDate = value;
                }
                else
                {
                    string message = "Due date must be in the future.";
                    throw new ArgumentException(message);
                }
            }
        }

        public Status Status
        {
            get
            {
                return _status;
            }
        }

        public void AdvanceStatus()
        {
            if (_status != Status.Verified)
            {
                Status previousStatus = _status;
                _status++;
                _history.Add(new EventLog($"Status changed from {previousStatus} to {_status}"));
            }
            else
            {
                _history.Add(new EventLog("Can't advance, already at Verified"));
            }
        }

        public void RevertStatus()
        {
            if (_status != Status.Open)
            {
                Status previousStatus = _status;
                _status--;
                _history.Add(new EventLog($"Status changed from {previousStatus} to {_status}"));
            }
            else
            {
                _history.Add(new EventLog("Can't revert, already at Open"));
            }
        }

        public string ViewInfo()
        {
            return $"'{_title}', [{_status}|{_dueDate.ToString("dd-MM-yyyy")}] - {this.GetType().Name}";
        }

        public string ViewHistory()
        {
            if (_history == null || !_history.Any())
            {
                return "No history available.";
            }
            StringBuilder historyLog = new StringBuilder();
            foreach (var eventLog in _history)
            {
                string eventInfo = eventLog.ViewInfo();
                historyLog.AppendLine(eventInfo);
            }

            return historyLog.ToString();
        }

        protected void AddActivityLog(string message)
        {
            _history.Add(new EventLog(message));
        }
    }
}
