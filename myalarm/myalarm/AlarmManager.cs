using System.Collections.Generic;

namespace myalarm
{
    public class AlarmManager
    {
        private List<Alarm> alarms = new List<Alarm>();

        public void AddAlarm(DateTime alarmTime)
        {
            alarms.Add(new Alarm(alarmTime));
        }

        public void RemoveAlarm(Alarm alarm)
        {
            alarms.Remove(alarm);
        }

        public List<Alarm> GetActiveAlarms()
        {
            return alarms.FindAll(alarm => alarm.IsActive);
        }
    }
}
