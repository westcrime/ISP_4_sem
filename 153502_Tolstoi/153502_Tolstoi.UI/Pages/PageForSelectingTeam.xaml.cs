using _153502_Tolstoi.UI.ViewModels;
using CommunityToolkit.Maui.Views;

namespace _153502_Tolstoi.UI.Pages;

public partial class PageForSelectingTeam : ContentPage
{
    private PageForSelectingTeamViewModel _viewModel;
	public PageForSelectingTeam(PageForSelectingTeamViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}