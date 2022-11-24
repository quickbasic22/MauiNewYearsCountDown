using Microsoft.Maui.Dispatching;
using System.Collections.ObjectModel;

namespace MauiNewYearsCountDown;

public partial class MainPage : ContentPage
{   
    private DateTime CurrentTime;
    private DateTime Midnight;
    private double dayOfYear = 0;
    public MainPage()
    {
        InitializeComponent();
        CurrentTime = DateTime.Now;
        Midnight = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Local);
        dayOfYear = Double.Parse(DateTime.Now.DayOfYear.ToString());    
        LabelTotalHours.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), MyTimerCallBack);
    }

    private bool MyTimerCallBack()
    {
        var CurrentDateTimeDifference = Midnight - DateTime.Now;
        double PercentLeft = dayOfYear / 365.0;
        YearProgressBar.Progress = PercentLeft;
        LabelTotalHours.Dispatcher.Dispatch(() => 
        {
            LabelTotalHours.Text = String.Format("{0:N0} Hours to go.", CurrentDateTimeDifference.TotalHours);
            LabelDays.Text = String.Format("{0:N0}", CurrentDateTimeDifference.Days);
            LabelHours.Text = String.Format("{0:N0}", CurrentDateTimeDifference.Hours);
            LabelMinutes.Text = String.Format("{0:N0}", CurrentDateTimeDifference.Minutes);
            LabelSeconds.Text = String.Format("{0:N0}", CurrentDateTimeDifference.Seconds);
        });
        return true;
    }
}

