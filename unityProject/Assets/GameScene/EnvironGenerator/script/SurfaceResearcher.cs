using UnityEngine;
using System.Collections;

namespace GameScene.EnvironGenerator
{
    public class SurfaceResearcher : MonoBehaviour
    {

        //set surfResearcher in orbit
        private void SetOrbitAltitude()
        {
            //calculate the radius of the planet
            GameObject planet = GameObject.Find("Planet");
            float radius = planet.GetComponent<MeshCollider>().bounds.extents.x;
            float dist = radius * 1.1F;
        }

        private void CastRay()
        {
            //direction in front
            //Vector3 fwd = transform.TransformDirection(Vector3.forward);
            //direction in target
            Vector3 fwd = (transform.position - Vector3.zero).normalized;
            Debug.Log("проверка");
            if (Physics.Raycast(transform.position, fwd, 100))
            {
                Debug.Log("There is something in front of the object!");
            }
        }


    }
}
