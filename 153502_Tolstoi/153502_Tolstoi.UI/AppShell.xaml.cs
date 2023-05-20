using _153502_Tolstoi.UI.Pages;

namespace _153502_Tolstoi.UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(PlayerDetailsPage),
            typeof(PlayerDetailsPage));
        Routing.RegisterRoute(nameof(AddingTeamPage),
            typeof(AddingTeamPage));
        Routing.RegisterRoute(nameof(AddingPlayerPage),
            typeof(AddingPlayerPage));
        Routing.RegisterRoute(nameof(PageForSelectingTeam),
            typeof(PageForSelectingTeam));
    }
}
