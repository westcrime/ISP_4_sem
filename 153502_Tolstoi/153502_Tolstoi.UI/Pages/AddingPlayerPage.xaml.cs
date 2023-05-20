using _153502_Tolstoi.UI.ViewModels;

namespace _153502_Tolstoi.UI.Pages;

public partial class AddingPlayerPage : ContentPage
{
    private AddingPlayerViewModel _viewModel;
	public AddingPlayerPage(AddingPlayerViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewmodel;
	}
}