using BoardR.Helpers;
using System.Reflection;
using System.Text;

namespace BoardR
{
    public class BoardItem
    {
        protected string _title;
        protected DateTime _dueDate;
        protected Status _status;
        private List<EventLog> _history = new List<EventLog>(); //to remain private
        private string dateFormat = "dd-MM-yyyy"; //to remain private

        public BoardItem(string title, DateTime dueDate, Status status)
        {
            
            _title = title;
            _dueDate = dueDate;
            _status = status;
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
                ChangeEventLog(_title, value, "Title");
                _title = value;
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
                    ChangeEventLog(_dueDate.ToString(dateFormat), value.ToString(dateFormat), "DueDate");
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
                ChangeEventLog(previousStatus.ToString(), _status.ToString(), "Status");
                //_history.Add(new EventLog($"Status changed from {previousStatus} to {_status}"));
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
                ChangeEventLog(previousStatus.ToString(), _status.ToString(), "Status");
                //_history.Add(new EventLog($"Status changed from {previousStatus} to {_status}"));
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

        public string ViewInfoDetailed()
        {
            StringBuilder detailedInfo = new StringBuilder();
            FieldInfo[] fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (var field in fields)
            {
                var fieldValue = field.GetValue(this);
                if (fieldValue is DateTime dateTimeValue)
                {
                    //for displaying duedate field formated with a default dateFromat template
                    string formattedDate = dateTimeValue.ToString(dateFormat);
                    detailedInfo.AppendLine($"{field.Name}: {formattedDate}");
                }
                else
                {
                    string fieldInfo = $"{field.Name}: {(fieldValue != null ? fieldValue.ToString() : "null")}";
                    detailedInfo.AppendLine(fieldInfo);
                }
            }
            return detailedInfo.ToString();
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

        public void CreateEventLog(string description = "No description")
        {
            string generalLogDetails = $"{this.GetType().Name}: '{_title}', [{_status}|{_dueDate.ToString(dateFormat)}]";
            if (this.GetType().Name == "Task")
            {
                _history.Add(new EventLog($"Created {generalLogDetails}"));
            }
            else if (this.GetType().Name =="Issue")
            {
                _history.Add(new EventLog($"Created {generalLogDetails}. Description: {description}"));
            }
            
        }
        public void ChangeEventLog(string currentValue, string newValue, string stringValue)
        {
            _history.Add(new EventLog($"{stringValue} changed from '{currentValue}' to '{newValue}'"));

        }
    }
}
