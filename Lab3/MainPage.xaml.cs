using Lab3.Entities;
using Lab3.Services;
using System.Collections.ObjectModel;

namespace Lab3;

public partial class MainPage : ContentPage
{
	public IDbService Db { get; init; }
	public string Name { get; set; }
	public ObservableCollection<FootballClub> ClubList { get; set; } = new();
	public List<FootballPlayer> PlayerList { get; set; }
    public MainPage(IDbService db)
	{
		InitializeComponent();
		Db = db;
		Db.Init();
		BindingContext = this;
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
		ClubList.Clear();
        var clubList = Db.GetAllClubs();
		foreach(var club in clubList)
		{
            ClubList.Add(club);

        }
    }

    private void PickerSelectedIndexChanged(object sender, EventArgs e)
	{
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

		if (selectedIndex != -1)
		{
            PlayerList = Db.GetFootballPlayers((picker.SelectedItem as FootballClub).Id).ToList();
			listView.ItemsSource = PlayerList;
        }
	}
}

