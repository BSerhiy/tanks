using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// physics simulation only for objects in layer PhysicsOn
/// air drag calculate only for object in tag AirDragOn
/// </summary>
public class PlanetSimulator : MonoBehaviour
{
    /// <summary>
    /// active object in atmosphere of planet
    /// </summary>
    private class ObjectInAtmosph
    {
        public Rigidbody RigBody;
        public Vector3 PreviousPosition;             //for calculate air drag direction
        public Transform myTransform;
        public bool isAirDragOn;
        public Vector3 CurrentPosition { get { return myTransform.position; } }
        public bool isExist { get { return myTransform != null; } }
    }

    [SerializeField] private GameObject planetObject;
    [SerializeField] private float atmosphereSize = 30;
    [SerializeField] private float gravityForce = 10f, airDrag = -1f;

    private List<ObjectInAtmosph> needSimulatePhysics = new List<ObjectInAtmosph>();
    private SphereCollider atmosphereLimit;
    private Rigidbody myRigidbody;
    private Vector3 directionToGravityCentr = Vector3.zero, airDragDirection = Vector3.zero;

    void Awake ()
    {
        Init();
    }

    private void Init()
    {
        //create physique system in planet object
        myRigidbody = gameObject.GetComponent<Rigidbody>();
        atmosphereLimit = gameObject.GetComponent<SphereCollider>();

        if (myRigidbody != null)
        {
            DestroyImmediate(myRigidbody);
        }

        if (atmosphereLimit != null)
        {
            DestroyImmediate(atmosphereLimit);
        }

        planetObject.AddComponent<Rigidbody>();
        myRigidbody = gameObject.GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;
        myRigidbody.isKinematic = true;

        //added surface of planet
        planetObject.AddComponent<MeshCollider>();

        //added atmosphere
        planetObject.AddComponent<SphereCollider>();
        atmosphereLimit = gameObject.GetComponent<SphereCollider>();
        atmosphereLimit.isTrigger = true;
        atmosphereLimit.radius = atmosphereLimit.radius * 3;            //atmosphere radius = 3*planetRadius

    }

    //if object has entered in atmosphere
    private void OnTriggerEnter(Collider other)
    {
        //Added object in physics simulation
        if (other.gameObject.layer == 8)
        {
            ObjectInAtmosph newObj = new ObjectInAtmosph();
            newObj.RigBody = other.gameObject.GetComponent<Rigidbody>();
            newObj.myTransform = other.transform;
            newObj.PreviousPosition = other.transform.position;
            needSimulatePhysics.Add(newObj);
            if(other.gameObject.tag == "AirDragOn")
            {
                newObj.isAirDragOn = true;
            }
        }
    }

    //if object has exit from atmosphere
    private void OnTriggerExit(Collider other)
    {
        //remove object from dictionary (from calculation)
        Destroy(other.gameObject, 3);
    }

    void Update()
    {
        //calculate behavior for all objects in atmosphere
        for(int i=0; i<needSimulatePhysics.Count; i++)
        {
            if (needSimulatePhysics[i].isExist)
            {
                //gravity force for objects in atmosphere
                //calculate direction on center of planet
                directionToGravityCentr = (transform.position - needSimulatePhysics[i].CurrentPosition).normalized;
                //added gravity impulse
                needSimulatePhysics[i].RigBody.AddForce(directionToGravityCentr * gravityForce * Time.deltaTime, ForceMode.Impulse);


                //air drag for objects in atmosphere
                if (needSimulatePhysics[i].isAirDragOn)
                {
                    //calculate direction of air drag force
                    airDragDirection = (needSimulatePhysics[i].CurrentPosition - needSimulatePhysics[i].PreviousPosition).normalized;
                    //added air drag impulse
                    needSimulatePhysics[i].RigBody.AddForce(airDragDirection * airDrag * Time.deltaTime, ForceMode.Impulse);
                    //remember position
                    needSimulatePhysics[i].PreviousPosition = needSimulatePhysics[i].CurrentPosition;
                }
            }
            else
            {
                needSimulatePhysics.RemoveAt(i);
            }
        }
    }
}
