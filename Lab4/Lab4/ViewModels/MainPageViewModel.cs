using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab4.Models;
using Lab4.Services;

namespace Lab4.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private DateTime date = new DateTime(2023, 1, 1);

    [ObservableProperty] private bool isNotBusy;

    [ObservableProperty] private string value;
    
    [ObservableProperty] private string valueText = "1,0";
    
    [ObservableProperty] private Rate currentRate;
    
    [ObservableProperty] private string selectedRateString;
    public ObservableCollection<string> RateStrings { get; set; } = new();

    private List<Rate> rates = new();

    private List<Rate> ratesFromApi = new();

    private RateService rateService = new();

    private Rate GetRateByName(string rateName)
    {
        var value = (from rate in ratesFromApi where rate.Cur_Name == rateName select rate).First();
        return value;
    }

    public async Task GetAllRates()
    {
        IsNotBusy = false;
        var enumerable = await rateService.GetRates(Date);
        this.ratesFromApi = enumerable.ToList();
        GetRates();
        CurrentRate = rates[0];
        SelectedRateString = RateStrings[0];
        IsNotBusy = true;
    }

    partial void OnDateChanged(DateTime value)
    {
        IsNotBusy = false;
        if (value > DateTime.Today)
            return;
        UpdateRates();
        IsNotBusy = true;
    }

    [RelayCommand]
    private async void Translate()
    {
        Value = (Convert.ToDouble(ValueText) / (Convert.ToDouble(CurrentRate.Cur_OfficialRate) / (double)CurrentRate.Cur_Scale)).ToString();
    }

    private async void UpdateRates()
    {
        await GetAllRates();
        Value = (Convert.ToDouble(ValueText) / (Convert.ToDouble(CurrentRate.Cur_OfficialRate) / (double)CurrentRate.Cur_Scale)).ToString();
    }

    partial void OnSelectedRateStringChanged(string value)
    {
        var x = (from rate in rates where rate.Cur_Name == value select rate).First();
        CurrentRate = x;
        Value = (Convert.ToDouble(ValueText) / (Convert.ToDouble(x.Cur_OfficialRate) / (double)x.Cur_Scale)).ToString();
    }

    private void GetRates()
    {
        if (rates.Count > 0)
            rates.Clear();
        rates.Add(this.GetRateByName("Российских рублей"));
        rates.Add(this.GetRateByName("Евро"));
        rates.Add(this.GetRateByName("Доллар США"));
        rates.Add(this.GetRateByName("Швейцарский франк"));
        rates.Add(this.GetRateByName("Китайских юаней"));
        rates.Add(this.GetRateByName("Фунт стерлингов"));
    }
    
    public MainPageViewModel()
    {
        RateStrings.Add("Российских рублей");
        RateStrings.Add("Евро");
        RateStrings.Add("Доллар США");
        RateStrings.Add("Швейцарский франк");
        RateStrings.Add("Китайских юаней");
        RateStrings.Add("Фунт стерлингов");
    }
}