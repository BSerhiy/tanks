using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
    [SerializeField] private Transform barrel;
    [SerializeField] private GameObject shell;
    [SerializeField] private float shotPower = 40f;

    private GameObject shellInstance;
    private Quaternion barrelRotation;

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Fire
            barrelRotation = Quaternion.Euler(barrel.TransformDirection(barrel.eulerAngles));
            shellInstance = Instantiate(shell, barrel.position, barrelRotation) as GameObject;
            shellInstance.GetComponent<Rigidbody>().velocity = barrel.TransformDirection(Vector3.forward * shotPower);
        }
	}
}
