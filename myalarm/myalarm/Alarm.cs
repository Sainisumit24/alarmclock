namespace myalarm
{
    public class Alarm
    {
        public DateTime AlarmTime { get; set; }
        public bool IsActive { get; set; }

        public Alarm(DateTime alarmTime)
        {
            AlarmTime = alarmTime;
            IsActive = true;
        }

        public void DisableAlarm()
        {
            IsActive = false;
        }
    }
}
