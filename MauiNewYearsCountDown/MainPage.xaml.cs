using Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific;
using Microsoft.Maui.Dispatching;
using System.Collections.ObjectModel;

namespace MauiNewYearsCountDown;

public partial class MainPage : ContentPage
{
    
    private DateTime CurrentTime;
    private DateTime Midnight;
    private TimeSpan CountDown;
    TimerCallback tc;
    private System.Threading.Timer t;

    public MainPage()
    {
        InitializeComponent();
        CurrentTime = DateTime.Now;
        Midnight = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Local);
        int dayOfYear = DateTime.Now.DayOfYear;
       
        LabelDays.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), MyTimerCallBackDays);
        LabelHours.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), MyTimerCallBackHours);
        LabelMinutes.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), MyTimerCallBackMinutes);
        LabelSeconds.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), MyTimerCallBackSeconds);
        LabelTotalHours.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), MyTimerCallBackTotalHours);
    }

    private bool MyTimerCallBackTotalHours()
    {
        var CurrentTotalHours = Midnight - DateTime.Now;
        LabelTotalHours.Dispatcher.Dispatch(() => { LabelTotalHours.Text = String.Format("{0:N0} Hours to go.", CurrentTotalHours.TotalHours); });
        return true;
    }

    bool MyTimerCallBackDays()
    {
        var CurrentDays = Midnight - DateTime.Now;
        LabelDays.Dispatcher.Dispatch(() => { LabelDays.Text = String.Format("{0:N0}", CurrentDays.TotalDays); });
        return true;
    }
    bool MyTimerCallBackHours()
    {
        var CurrentHours = Midnight - DateTime.Now;
        LabelHours.Dispatcher.Dispatch(() => { LabelHours.Text = String.Format("{0:N0}", CurrentHours.Hours); });
        return true;
    }
    bool MyTimerCallBackMinutes()
    {
        var CurrentMinutes = Midnight - DateTime.Now;
        LabelMinutes.Dispatcher.Dispatch(() => { LabelMinutes.Text = String.Format("{0:N0}", CurrentMinutes.Minutes); });
        return true;
    }
    bool MyTimerCallBackSeconds()
    {
        var CurrentSeconds = Midnight - DateTime.Now;
        LabelSeconds.Dispatcher.Dispatch(() => { LabelSeconds.Text = String.Format("{0:N0}", CurrentSeconds.Seconds); });
        return true;
    }

}

