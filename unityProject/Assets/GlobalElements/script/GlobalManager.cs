using UnityEngine;

namespace GlobalElement
{
    public class GlobalManager : MonoBehaviour
    {
        private static GlobalManager instance = null;
        public static GlobalManager Instance { get { return instance; } }


        private PlayerData _playerData;
        public PlayerData _PlayerData { get { return _playerData; }}



        private void Awake()
        {
            // if the singleton hasn't been initialized yet
            if (instance != null)
            {
                Debug.Log("Экземпляр синглтона уже есть");
                Destroy(this.gameObject);
                return;
            }
            else
            {
                Debug.Log("Новый синглтон");
                _playerData = new PlayerData();

                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
