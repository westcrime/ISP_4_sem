using _153502_Tolstoi.UI.ViewModels;

namespace _153502_Tolstoi.UI.Pages;

public partial class PlayerDetailsPage : ContentPage
{
	private PlayerDetailsViewModel _viewModel;
	public PlayerDetailsPage(PlayerDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}