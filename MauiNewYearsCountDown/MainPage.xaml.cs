using Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific;
using System.Collections.ObjectModel;

namespace MauiNewYearsCountDown;

public partial class MainPage : ContentPage
{
    public ObservableCollection<int> Days { get; set; }
    public ObservableCollection<int> Hours { get; set; }
    public ObservableCollection<int> Minutes { get; set; }
    public ObservableCollection<int> Seconds { get; set; }
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
        Device.StartTimer(TimeSpan.FromSeconds(1.0), MyTimerCallBack);
        LabelDays.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), MyTimerCallBack);
        LabelHours.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), MyTimerCallBack);
        LabelMinutes.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), MyTimerCallBack);
        LabelSeconds.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), MyTimerCallBack);

    }

    bool MyTimerCallBack()
    {
        tc = new TimerCallback(CheckTime);
        t = new System.Threading.Timer(tc, null, 1000, 1000);
        return true;
    }
    
    private void CheckTime(object state)
    {
        CurrentTime = DateTime.Now;
        CountDown = Midnight - CurrentTime;  
    }
}

