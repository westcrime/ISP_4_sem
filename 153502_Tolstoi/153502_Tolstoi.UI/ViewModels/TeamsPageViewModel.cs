using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using _153502_Tolstoi.Application.Abstractions;
using _153502_Tolstoi.Domain.Entities;
using _153502_Tolstoi.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _153502_Tolstoi.UI.ViewModels
{
    public partial class TeamsPageViewModel : BaseViewModel
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;
        public TeamsPageViewModel(ITeamService teamService, IPlayerService
            playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }

        public ObservableCollection<Team> Teams { get; set; } = new();
        public ObservableCollection<Player> Players { get; set; } = new();

        [ObservableProperty]
        Team selectedTeam;

        [RelayCommand]
        async void UpdateGroupList() => await GetTeams();

        [RelayCommand]
        async void UpdateMembersList() => await GetPlayers();

        [RelayCommand]
        async Task UpdateAll()
        {
            await GetTeams();
            await GetPlayers();
        }

        [RelayCommand]
        async void AddPlayer()
        {
            await Shell.Current.GoToAsync(nameof(AddingPlayerPage), true, new Dictionary<string, object>
            {
                { "Team", SelectedTeam }
            });
        }

        [RelayCommand]
        async void ShowDetails(Player player) => await GotoDetailsPage(player);
        private async Task GotoDetailsPage(Player player)
        {
            await Shell.Current.GoToAsync(nameof(PlayerDetailsPage), true, new Dictionary<string, object>
            {
                { "Player", player }
            });
        }

        [RelayCommand]
        async void AddTeam()
        {
            await Shell.Current.GoToAsync(nameof(AddingTeamPage), true);
        }

        [RelayCommand]
        async void DeleteTeam()
        {
            try
            {
                if (selectedTeam != null)
                {
                    await _teamService.DeleteAsync(SelectedTeam);
                }
                await this.UpdateAll();
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "OK");
                return;
            }
        }

        public async Task GetTeams()
        {
            if (IsBusy == true)
                return;
            IsBusy = true;
            var teams = await _teamService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Teams.Clear();
                if (teams.Count != 0)
                    foreach (var team in teams)
                        Teams.Add(team);
            });
            if (Teams.Count != 0)
                SelectedTeam = Teams[0];
            IsBusy = false;
        }

        public async Task GetPlayers()
        {
            if (IsBusy == true)
                return;
            IsBusy = true;
            var players = (await _teamService.GetByIdAsync(SelectedTeam.Id)).Players;
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Players.Clear();
                if (players.Count != 0)
                    foreach (var player in players)
                        Players.Add(player);
            });
            IsBusy = false;
        }
        
    }
}
