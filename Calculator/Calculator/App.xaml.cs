namespace Calculator;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var windows = base.CreateWindow(activationState);

        //windows.Height = 100;
        //windows.Width = 100;
        // Add here your positioning code

        return windows;
    }
}
	

