using System;

public class EventLog
{
    private static string logFormat = "[{0:yyyyMMdd|HH:mm:ss.ffff}]{1}";

    public EventLog(string log)
    {
        if (string.IsNullOrWhiteSpace(log))
        {
            throw new ArgumentException("Log cannot be Null,Empty or Whitespace");
        }
        Description = log;
        Time = DateTime.Now;
       
    }

    public string Description { 
        get;
    }
    public DateTime Time { 
        get; 
    }

    public string ViewInfo()
    {
        return string.Format(logFormat, this.Time, Description);
    }


}


