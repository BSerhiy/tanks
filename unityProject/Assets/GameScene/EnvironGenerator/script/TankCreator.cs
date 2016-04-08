using UnityEngine;
using System;

namespace GameScene.EnvironGenerator
{
    public class TankCreator : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] tankPrefabs = new GameObject[] { };
        private Transform point;

        private Vector3 targetPos = new Vector3(0, 31, 0);
        private Quaternion targetRotation = Quaternion.identity;

        public void Create(int id, int count, Action callback)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject tank = Instantiate(tankPrefabs[id], targetPos, targetRotation) as GameObject;
                tank.name = "Tank";
            }
            callback();
        }
    }
}
