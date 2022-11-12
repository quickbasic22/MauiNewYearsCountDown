using Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNewYearsCountDown
{
    public class Countdown
    {
        private DateTime CurrentTime;
        private DateTime Midnight;
        private TimeSpan CountDown;
        TimerCallback tc;
        private System.Threading.Timer t;
        // Timer timer1 = new Timer(tc);
        Microsoft.Maui.Controls.ProgressBar progressBar1 = new();

        public Countdown()
        {
            CurrentTime = DateTime.Now;

            Midnight = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Local);

            // timer1.Change(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            
            restart();
            int dayOfYear = DateTime.Now.DayOfYear;
            progressBar1.ProgressColor = Colors.Blue;
            progressBar1.Progress = 1;


        }

        private void restart()
        {
            tc = new TimerCallback(CheckTime);
            t = new System.Threading.Timer(tc, null, 1000, 1000);
        }

        private void CheckTime(object state)
        {
            CurrentTime = DateTime.Now;
            CountDown = Midnight - CurrentTime;
        }

    }
}
