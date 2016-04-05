using UnityEngine;
using System.Collections;
using GlobalElement;
using UnityEngine.SceneManagement;

public class TestMenuScene : MonoBehaviour
{
    //тестовый генератор установок пользователя

    public void TestPlay()
    {
        GlobalManager globalManager = GlobalManager.Instance;
        globalManager._PlayerData.GameType = 0;
        globalManager._PlayerData.PlanetID = 0;
        globalManager._PlayerData.TanksCount = 1;
        SceneManager.LoadSceneAsync("game");
    }

}
