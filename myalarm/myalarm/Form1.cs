using System;
using System.Drawing;
using System.Media;  // Required for SoundPlayer
using System.Windows.Forms;

namespace myalarm
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private DateTime alarmTime;
        private bool isAlarmSet = false;
        private SoundPlayer soundPlayer;

        public Form1()
        {
            InitializeComponent();
            InitializeAlarmClock();

            // Initialize SoundPlayer with your alarm sound file
            soundPlayer = new SoundPlayer(@"C:\\Users\\Rascal\\Downloads\\alarm.wav"); // Ensure the .wav file is in the output directory
        }

        private void InitializeAlarmClock()
        {
            this.Text = "Alarm Clock";
            this.Size = new Size(300, 200);

            // Labels
            Label lblCurrentTime = new Label() { Text = "Current Time:", Location = new Point(20, 20) };
            Label lblTime = new Label() { Location = new Point(120, 20), AutoSize = true };
            Label lblSetAlarm = new Label() { Text = "Set Alarm (HH:MM):", Location = new Point(20, 60) };

            // TextBox for setting alarm
            TextBox txtAlarmTime = new TextBox() { Location = new Point(150, 60), Width = 60 };

            // Button to set alarm
            Button btnSetAlarm = new Button() { Text = "Set Alarm", Location = new Point(150, 100) };
            btnSetAlarm.Click += (sender, e) =>
            {
                if (DateTime.TryParse(txtAlarmTime.Text, out alarmTime))
                {
                    isAlarmSet = true;
                    MessageBox.Show("Alarm is set for " + alarmTime.ToShortTimeString());
                }
                else
                {
                    MessageBox.Show("Invalid time format. Please enter a valid time (HH:MM).");
                }
            };

            // Timer for checking time and alarm
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second interval
            timer.Tick += (sender, e) =>
            {
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
                if (isAlarmSet && DateTime.Now >= alarmTime)
                {
                    timer.Stop();
                    isAlarmSet = false;
                    soundPlayer.Play();  // Play the alarm sound
                    MessageBox.Show("Alarm Time!");
                    timer.Start();
                }
            };
            timer.Start();

            // Adding controls to the form
            Controls.Add(lblCurrentTime);
            Controls.Add(lblTime);
            Controls.Add(lblSetAlarm);
            Controls.Add(txtAlarmTime);
            Controls.Add(btnSetAlarm);
        }
    }
}
