using UnityEngine;
using System;

namespace GameScene.EnvironGenerator
{
    public class TankCreator : MonoBehaviour
    {
        [SerializeField] private GameObject[] tankPrefabs = new GameObject[] { };


        private Vector3 targetPos = new Vector3(0,31,0);

        public void CreateTank(int id, int count, Action callback)
        {
            for(int i=0; i<count; i++)
            {
                GameObject tank = Instantiate(tankPrefabs[id], targetPos, Quaternion.identity) as GameObject;
                tank.name = "Tank";
            }
        }
    }
}
