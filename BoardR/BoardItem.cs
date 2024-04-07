using System;
using System.Text;

namespace BoardR
{
    public class BoardItem
    {
        private string _title;
        private DateTime _dueDate;
        private Status _status;
        private List<EventLog> _history = new List<EventLog>();
        private string dateFormat = "dd-MM-yyyy";

        public BoardItem(string title, DateTime dueDate)
        {

            _title = title;
            _dueDate = dueDate;
            _status = Status.Open;
            _history.Add(new EventLog($"Item created: '{title}', [{_status}|{_dueDate.ToString(dateFormat)}]"));
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
            return $"'{_title}', [{_status}|{_dueDate.ToString("dd-MM-yyyy")}]";
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
    }
}
