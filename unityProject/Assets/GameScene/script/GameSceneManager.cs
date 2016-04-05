using UnityEngine;
using System.Collections;

using GameScene.EnvironGenerator;

namespace GameScene
{
    public class GameSceneManager : MonoBehaviour
    {
        [SerializeField] private GameObject EIEnvironGen;

        void Start()
        {
            GameObject generator = Instantiate(EIEnvironGen);
            generator.GetComponent<EIEnvironGenerator>().Init();
        }      
    }
}
