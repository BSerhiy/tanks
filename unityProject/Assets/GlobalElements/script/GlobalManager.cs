using UnityEngine;

namespace GlobalElement
{
    public class GlobalManager : MonoBehaviour
    {
        private static GlobalManager instance = null;
        public static GlobalManager Instance { get { return instance; } }

        private PlayerData _playerData = new PlayerData();
        public PlayerData _PlayerData { get { return _playerData; }}

        private void Awake()
        {
            // if the singleton hasn't been initialized yet
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
