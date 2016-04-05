namespace GlobalElement
{
    //data user settings from menu scene
    public class PlayerData
    {
        private int gameType = 0;
        public int GameType { get { return gameType; } set { gameType = value; } }

        private int planetID = 0;
        public int PlanetID { get { return planetID; } set { planetID = value; } }

        private int tanksCount = 1;
        public int TanksCount { get { return tanksCount; } set { tanksCount = value; } }
    }
}
