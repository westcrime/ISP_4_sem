using Lab3.Entities;
using SQLite;

namespace Lab3.Services
{
    public class SQLiteService : IDbService
    {
        SQLiteConnection _db;
        public string DatabasePath;
        private static SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite |
                                               SQLite.SQLiteOpenFlags.Create |
                                               SQLite.SQLiteOpenFlags.SharedCache;


        public const string DatabaseFilename = "db.db";

        public IEnumerable<FootballClub> GetAllClubs()
        {
            return _db.Table<FootballClub>().ToList();
        }

        public IEnumerable<FootballPlayer> GetFootballPlayers(int id)
        {
            return _db.Table<FootballPlayer>().Where(s => s.FootballClubId == id).ToList();
        }

        public SQLiteService()
        {
            DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
            _db = new SQLiteConnection(DatabasePath, Flags);
        }

        public void Init()
        {
            _db.DropTable<FootballClub>();
            _db.DropTable<FootballPlayer>();
            _db.CreateTable<FootballClub>();
            _db.CreateTable<FootballPlayer>();

            _db.Insert(new FootballClub(1, "Real Madrid"));
            _db.Insert(new FootballClub(2, "Manchester United"));
            _db.Insert(new FootballClub(3, "Barcelona"));

            _db.Insert(new FootballPlayer(1, 1, "Benzema"));
            _db.Insert(new FootballPlayer(2, 1, "Courtois"));
            _db.Insert(new FootballPlayer(1, 2, "Sterling"));
            _db.Insert(new FootballPlayer(2, 2, "Rashford"));
            _db.Insert(new FootballPlayer(1, 3, "Gavi"));
            _db.Insert(new FootballPlayer(2, 3, "Iniesta"));




        }
    }
}
