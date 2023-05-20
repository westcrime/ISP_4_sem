using _153502_Tolstoi.Application.Abstractions;
using _153502_Tolstoi.Application.Services;
using _153502_Tolstoi.Domain.Abstractions;
using _153502_Tolstoi.Domain.Entities;
using _153502_Tolstoi.Persistence.Data;
using _153502_Tolstoi.Persistence.Repositories;
using _153502_Tolstoi.UI.Pages;
using _153502_Tolstoi.UI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;


namespace _153502_Tolstoi.UI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        SetupServices(builder.Services);
        return builder.Build();
    }
    private static void SetupServices(IServiceCollection services)
    {
        services.AddSingleton<FirebaseDbClient>();
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IPlayerService, PlayerService>();
        services.AddSingleton<ITeamService, TeamService>();

		//viewmodels
        services.AddSingleton<TeamsPageViewModel>();
        services.AddSingleton<AddingPlayerViewModel>();
        services.AddSingleton<AddingTeamViewModel>();
        services.AddSingleton<PlayerDetailsViewModel>();
        services.AddSingleton<PageForSelectingTeamViewModel>();

        //pages
        services.AddSingleton<TeamsPage>();
        services.AddSingleton<AddingPlayerPage>();
        services.AddSingleton<AddingTeamPage>();
        services.AddSingleton<PlayerDetailsPage>();
        services.AddSingleton<PageForSelectingTeam>();
    }
}
