using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Tolstoi.Application.Abstractions;
using _153502_Tolstoi.Domain.Entities;
using _153502_Tolstoi.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;

namespace _153502_Tolstoi.UI.ViewModels
{
    public partial class AddingTeamViewModel : BaseViewModel
    {
        [ObservableProperty] private string name;

        [ObservableProperty] private string leaguePoints;

        private Team _team = new();

        private string photoPath = string.Empty;

        private readonly ITeamService _teamService;

        private readonly IPlayerService _playerService;

        public AddingTeamViewModel(ITeamService teamService, IPlayerService
            playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }

        [RelayCommand]
        private async void ChoosingFile()
        {
            IsBusy = true;
            await LoagImage();
            IsBusy = false;
        }

        private async Task LoagImage()
        {
            try
            {
                PickOptions options = new()
                {
                    PickerTitle = "Please select a png file",
                    FileTypes = FilePickerFileType.Png,
                };
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        var directory = Path.Combine(FileSystem.AppDataDirectory, "Images");
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }
                        var fileFullPath = Path.Combine(directory, $"{_team.Id}.png");
                        photoPath = fileFullPath;

                        SaveStreamToFile(fileFullPath, stream);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Alert", "Wrong file format!", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        public void SaveStreamToFile(string fileFullPath, Stream stream)
        {
            if (stream.Length == 0) return;

            // Create a FileStream object to write a stream to a file
            using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
            {
                // Fill the bytes[] array with the stream data
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

                // Use FileStream object to write to the specified file
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }

        [RelayCommand]
        private async void Confirm()
        {
            IsBusy = true;
            try
            {
                var team = new Team();
                int points = 0;
                try
                {
                    if (string.IsNullOrEmpty(LeaguePoints))
                    {
                        await App.Current.MainPage.DisplayAlert("Alert", "Wrong league points format!", "OK");
                        return;
                    }

                    points = Convert.ToInt32(LeaguePoints);
                }
                catch (Exception e)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Wrong league points format!", "OK");
                    return;
                }

                if (string.IsNullOrEmpty(Name))
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Wrong name of the team format!", "OK");
                    return;
                }

                team.LeaguePoints = points;
                team.Name = Name;
                team.Players = new();
                team.Photo = photoPath;

                await _teamService.AddAsync(team);

                await App.Current.MainPage.DisplayAlert("Alert", "Team was successfully added!", "OK");
                await Shell.Current.GoToAsync($"//{nameof(TeamsPage)}");
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "OK");
                return;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
