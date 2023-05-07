using Lab4.Services;
using Lab4.ViewModels;

namespace Lab4;

public partial class MainPage : ContentPage
{
    private MainPageViewModel viewModel;
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = this.viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await this.viewModel.GetAllRates();
    }
}