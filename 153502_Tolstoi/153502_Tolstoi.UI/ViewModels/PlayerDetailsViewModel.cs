using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Tolstoi.Application.Abstractions;
using _153502_Tolstoi.Domain.Entities;
using _153502_Tolstoi.UI.Pages;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _153502_Tolstoi.UI.ViewModels
{
    [QueryProperty(nameof(Player), "Player")]
    public partial class PlayerDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Player player;

        [ObservableProperty] private string teamName = string.Empty;

        [RelayCommand]
        private async void UpdateTeams()
        {
            IsBusy = true;
            var _teams = await _teamService.GetAllAsync();
            foreach (var team in _teams)
            {
                if (Player.TeamId == team.Id)
                {
                    TeamName = team.Name;
                }
            }
            IsBusy = false;
        }

        [RelayCommand]
        private async void DeletePlayer()
        {
            IsBusy = true;
            var _teams = await _teamService.GetAllAsync();
            foreach (var team in _teams)
            {
                if (Player.TeamId == team.Id)
                {
                    team.Players.Remove(Player);
                    await _teamService.AddAsync(team);
                }
            }

            await _playerService.DeleteAsync(Player);
            IsBusy = false;

            await Shell.Current.GoToAsync($"//{nameof(TeamsPage)}");
        }

        [RelayCommand]
        private async void ChangeTeam()
        {
            await Shell.Current.GoToAsync($"{nameof(PageForSelectingTeam)}", true, new Dictionary<string, object>
            {
                { "Player", Player }
            });
        }

        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;
        public PlayerDetailsViewModel(ITeamService teamService, IPlayerService
            playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }
    }
}
