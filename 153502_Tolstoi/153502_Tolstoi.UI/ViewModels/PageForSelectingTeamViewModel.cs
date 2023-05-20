using _153502_Tolstoi.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using _153502_Tolstoi.Application.Abstractions;
using System.Collections.ObjectModel;
using _153502_Tolstoi.UI.Pages;

namespace _153502_Tolstoi.UI.ViewModels
{
    [QueryProperty(nameof(Player), "Player")]
    public partial class PageForSelectingTeamViewModel : BaseViewModel
    {
        [ObservableProperty]
        Player player;

        [ObservableProperty]
        private Team teamOfPlayer;

        [ObservableProperty]
        Team selectedTeam;

        public ObservableCollection<Team> Teams { get; set; } = new();

        [RelayCommand]
        private async void GetTeams()
        {
            if (IsBusy == true)
                return;
            IsBusy = true;
            try
            {
                var teams = await _teamService.GetAllAsync();
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Teams.Clear();
                    if (teams.Count != 0)
                    {
                        foreach (var team in teams)
                        {
                            if (team.Id == Player.TeamId)
                                TeamOfPlayer = team;
                            Teams.Add(team);
                        }
                    }
                });
                if (Teams.Count != 0)
                    SelectedTeam = Teams[0];
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

        [RelayCommand]
        private async void Confirm()
        {
            if (IsBusy == true)
                return;
            IsBusy = true;
            try
            {
                if (SelectedTeam != TeamOfPlayer)
                {
                    foreach (var player in TeamOfPlayer.Players)
                    {
                        if (Player.Id == player.Id)
                        {
                            TeamOfPlayer.Players.Remove(player);
                            break;
                        }
                    }
                    await _teamService.UpdateAsync(TeamOfPlayer);
                    Player.TeamId = SelectedTeam.Id;
                    await _playerService.UpdateAsync(Player);
                    SelectedTeam.Players.Add(Player);
                    await _teamService.UpdateAsync(SelectedTeam);
                    await Shell.Current.GoToAsync($"//{nameof(TeamsPage)}");
                }
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

        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public PageForSelectingTeamViewModel(ITeamService teamService, IPlayerService
            playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }
    }
}
