using _153502_Tolstoi.UI.Pages;

namespace _153502_Tolstoi.UI;

public partial class App : Microsoft.Maui.Controls.Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    }
}
