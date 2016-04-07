using UnityEngine;
using System;

namespace GameScene.EnvironGenerator
{
    public class TankCreator : MonoBehaviour
    {
        [SerializeField] private GameObject[] tankPrefabs = new GameObject[] { };
        private Transform point;

        private Vector3 targetPos = new Vector3(0,31,0);
        private Quaternion targetRotation = Quaternion.identity;

        public void Create (int id, int count, Action callback)
        {
            AdvancedCreate();
            for (int i=0; i<count; i++)
            {
                GameObject tank = Instantiate(tankPrefabs[id], targetPos, targetRotation) as GameObject;
                tank.name = "Tank";
            }
            callback();
        }

        private void AdvancedCreate()
        {
            point = GameObject.Find("point").transform;
            Vector3 fwd = point.TransformDirection(Vector3.forward);

            Debug.Log("проверка");
            if (Physics.Raycast(point.position, fwd, 10000))
            {
                Debug.Log("There is something in front of the object!");
            }

            ////calculate position
            //Ray ray = new Ray(Vector3.zero, Vector3.forward);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit, 100))
            //{
            //    Debug.Log("Collider = ");
            //}
        }
}
}
