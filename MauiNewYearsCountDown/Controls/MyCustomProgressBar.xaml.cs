namespace MauiNewYearsCountDown.Controls;

public partial class MyCustomProgressBar : Frame
{
	public static readonly BindableProperty NewYearsTextProperty = BindableProperty.Create("NewYearsText", typeof(string), typeof(MyCustomProgressBar), "New Years 2023", BindingMode.TwoWay);


	public MyCustomProgressBar()
	{
		InitializeComponent();	
	}

    public string NewYearsText
	{ 
		get => (string)GetValue(NewYearsTextProperty);
		set
		{
			SetValue(NewYearsTextProperty, value);
		}
	}
}