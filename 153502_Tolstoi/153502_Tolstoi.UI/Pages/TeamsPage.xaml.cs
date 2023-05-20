using _153502_Tolstoi.UI.ViewModels;

namespace _153502_Tolstoi.UI.Pages;

public partial class TeamsPage : ContentPage
{
    private TeamsPageViewModel _teamsPageViewModel;
	public TeamsPage(TeamsPageViewModel teamsPageViewModel)
	{
		InitializeComponent();
		BindingContext = _teamsPageViewModel = teamsPageViewModel;
	}
}