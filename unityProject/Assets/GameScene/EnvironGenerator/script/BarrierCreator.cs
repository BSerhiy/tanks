using UnityEngine;
using System;

namespace GameScene.EnvironGenerator
{
    public class BarrierCreator : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] barrierPrefabs = new GameObject[] { };


        private Vector3 targetPos = new Vector3(0, 31, 0);
        private Quaternion targetRotation = Quaternion.identity;

        public void Create (int id, int count, Action callback)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject tank = Instantiate(barrierPrefabs[id], targetPos, targetRotation) as GameObject;
                tank.name = "Barrier";
            }
            callback();
        }
    }
}
