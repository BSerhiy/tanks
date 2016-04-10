using UnityEngine;
using System.Collections;

namespace GameScene.EnvironGenerator
{
    /// <summary>
    /// SurfaceResearcher
    /// it's prefab (empty object and this script)
    /// This satellite is placed above the planet. Explore the planet's surface by means of laser beams. If space is still available - puts to the tank or elements of buildings.
    /// </summary>
    public class SurfaceResearcher : MonoBehaviour
    {
        private const float deflactionsValue = 5, altitudeOfSurfaceResearcher = 20;

        //matrix of deflactions
        private Vector2[] rayDeflactions = new Vector2[9] { new Vector2(1, 1), new Vector2(0, 1), new Vector2(-1, 1), new Vector2(1, 0), new Vector2(0, 0), new Vector2(-1, 0), new Vector2(1, -1), new Vector2(0, -1), new Vector2(-1, -1) };

        private Transform surfaceResearcherPivot;
        private Vector3 startPivotAngle = Vector3.zero, currentPivotAngle = Vector3.zero;

        public void Init()
        {
            //calculate angles of ray deflactions
            for (int i=0; i<rayDeflactions.Length; i++)
            {
                rayDeflactions[i] *= deflactionsValue;
            }

            //create base pivot
            surfaceResearcherPivot = new GameObject().transform;
            surfaceResearcherPivot.name = "surfaceResearcher_pivot";
            transform.SetParent(surfaceResearcherPivot);

            SetAltitude();
            SetAngle();
        }

        //set surfResearcher in orbit
        private void SetAltitude()
        {
            //calculate the radius of the planet
            GameObject planet = GameObject.Find("Planet");
            float radius = planet.GetComponent<MeshCollider>().bounds.extents.x;
            float altitude = radius + altitudeOfSurfaceResearcher;
            transform.localPosition = new Vector3(0, altitude, 0);
        }

        private void SetAngle()
        {
            startPivotAngle.y = Random.Range(0, 359.9F);
            startPivotAngle.z = Random.Range(0, 89.9F);
            //startPivotAngle.y = 0;
            //startPivotAngle.z = 0;
            surfaceResearcherPivot.localEulerAngles = startPivotAngle;
            CastRays();
        }

        /// <summary>
        /// check whether the free space on the surface
        /// examine area with the help of 9 rays (3x3)
        /// </summary>
        private void CastRays()
        {
            //direction in front
            //Vector3 fwd = transform.TransformDirection(Vector3.forward);
            //direction in target
            for(int i=0; i<9; i++)
            {
                //currentPivotAngle = startPivotAngle;
                //currentPivotAngle.y += rayDeflactions[i][0];
                //currentPivotAngle.z += rayDeflactions[i][1];

                //surfaceResearcherPivot.localEulerAngles = currentPivotAngle;
                currentPivotAngle = Vector3.zero;
                currentPivotAngle.x = rayDeflactions[i][0];
                currentPivotAngle.z = rayDeflactions[i][1];
                transform.localEulerAngles = currentPivotAngle;
                //Debug.Log(currentPivotAngle);
                //Vector3 fwd = (surfaceResearcherPivot.position - transform.position).normalized;
                Vector3 fwd = transform.TransformDirection(Vector3.down);
                RaycastHit hit;
                if (Physics.Raycast(transform.position, fwd, out hit))
                {
                    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    go.transform.localScale *= 0.5F;
                    go.transform.position = hit.point;
                    go.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

                    Debug.DrawLine(transform.position, hit.point, Color.red, 100);
                    //Debug.Log(hit.normal);

                    Debug.Log("Reesult = " + hit.collider.name);
                    //use RaycastHit.textureCoord for detexting pixel color
                }
            }

        }


    }
}
