using _153502_Tolstoi.UI.ViewModels;

namespace _153502_Tolstoi.UI.Pages;

public partial class AddingTeamPage : ContentPage
{
    private AddingTeamViewModel _viewModel;
	public AddingTeamPage(AddingTeamViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}