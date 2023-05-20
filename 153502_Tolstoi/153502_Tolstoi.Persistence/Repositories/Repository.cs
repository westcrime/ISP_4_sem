using System.Linq.Expressions;
using System.Numerics;
using _153502_Tolstoi.Domain.Abstractions;
using _153502_Tolstoi.Domain.Entities;
using _153502_Tolstoi.Persistence.Data;
using Firebase.Database.Query;
using FireSharp.Response;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace _153502_Tolstoi.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly FirebaseDbClient _client;

        public Repository(FirebaseDbClient client)
        {
            this._client = client;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            string path = string.Empty;
            if (typeof(T) == typeof(Team))
            {
                path = "Teams";
            }
            else
            {
                path = "Players";
            }

            var response = await _client.Client.SetAsync($"{path}/" + entity.Id, entity);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            string path;
            string other;
            if (typeof(T) == typeof(Team))
            {
                path = "Teams";
                other = "Players";
            }
            else
            {
                path = "Players";
                other = "Teams";
            }

            FirebaseResponse response1 = await _client.Client.GetAsync($"Players/");
            var dict1 = JsonConvert.DeserializeObject<IDictionary<string, Player>>(response1.Body);
            if (dict1 == null)
                return;
            List<Player> listOfPlayers = dict1.Values.ToList();

            FirebaseResponse response2 = await _client.Client.GetAsync($"Teams/");
            var dict2 = JsonConvert.DeserializeObject<IDictionary<string, Team>>(response2.Body);
            if (dict2 == null)
                return;
            List<Team> listOfTeams = dict2.Values.ToList();


            if (typeof(T) == typeof(Team))
            {
                foreach (var player in listOfPlayers)
                {
                    foreach (var team in listOfTeams)
                    {
                        if (player.TeamId == team.Id)
                        {
                            player.TeamId = string.Empty;
                        }
                    }
                    await _client.Client.SetAsync($"Players/" + player.Id, player);
                }
            }
            else
            {
                foreach (var team in listOfTeams)
                {
                    foreach (var player in team.Players)
                    {
                        if (player.Id == entity.Id)
                        {
                            team.Players.Remove(player);
                            break;
                        }
                    }
                    await _client.Client.SetAsync($"Teams/" + team.Id, team);
                }
            }

            await _client.Client.DeleteAsync($"{path}/" + entity.Id);
        }

        public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            string path;
            if (typeof(T) == typeof(Team))
            {
                path = "Teams";
            }
            else
            {
                path = "Players";
            }
            var response = await _client.Client.GetAsync($"{path}/{id}");
            var item = JsonConvert.DeserializeObject<T>(response.Body);
            return item;
        }

        public async Task UpdateAsync(T entity,
            CancellationToken cancellationToken = default)
        {
            await this.AddAsync(entity, cancellationToken);
        }

        public async Task<List<T>> ListAllAsync(CancellationToken cancellationToken)
        {
            string path;
            if (typeof(T) == typeof(Team))
            {
                path = "Teams";
            }
            else
            {
                path = "Players";
            }
            FirebaseResponse response = await _client.Client.GetAsync($"{path}/");
            var dict = JsonConvert.DeserializeObject<IDictionary<string, T>>(response.Body);
            if (dict == null)
                return null;
            List<T> list = dict.Values.ToList();
            return list;
        }
    }
}
