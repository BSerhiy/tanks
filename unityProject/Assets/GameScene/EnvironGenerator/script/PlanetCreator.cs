using UnityEngine;
using System;

namespace GameScene.EnvironGenerator
{
    public class PlanetCreator : MonoBehaviour
    {
        [SerializeField] private GameObject[] planetPrefabs = new GameObject[] { };

        public void CreatePlanet(int id, Action callback)
        {
            GameObject planet = Instantiate(planetPrefabs[id], Vector3.zero, Quaternion.identity) as GameObject;
            planet.name = "Planet";
            callback();
        }
    }
}
