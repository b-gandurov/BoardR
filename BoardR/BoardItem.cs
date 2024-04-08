using System;
using System.Text;

namespace BoardR
{
    public class BoardItem
    {
        protected internal string _title;
        protected internal DateTime _dueDate;
        protected internal Status _status;
        protected internal List<EventLog> _history = new List<EventLog>();
        protected internal string dateFormat = "dd-MM-yyyy";

        public BoardItem(string title, DateTime dueDate, Status status)
        {
            
            _title = title;
            _dueDate = dueDate;
            _status = status;
            //_history.Add(new EventLog($"Created {this.GetType().Name}: '{title}', [{_status}|{_dueDate.ToString(dateFormat)}]"));
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value.Length >= 5 && value.Length <= 30 && !string.IsNullOrWhiteSpace(value))
                {
                    _history.Add(new EventLog($"Title changed from '{_title}' to '{value}'"));
                    _title = value;
                }
                else
                {
                    throw new ArgumentException("Title must be between 5 and 30 characters long.");
                }
            }
        }

        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }
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
            return $"'{_title}', [{_status}|{_dueDate.ToString(dateFormat)}]";
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

        public void AddEventLog(string description = "No description")
        {
            if (this.GetType().Name == "Task")
            {
                _history.Add(new EventLog($"Created {this.GetType().Name}: '{_title}', [{_status}|{_dueDate.ToString(dateFormat)}]"));
            }
            else if (this.GetType().Name =="Issue")
            {
                _history.Add(new EventLog($"Created {this.GetType().Name}: '{_title}', [{_status}|{_dueDate.ToString(dateFormat)}]. Description: {description}"));
            }
            
        }
    }
}
