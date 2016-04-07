using UnityEngine;

public class MarkerRotationCalculator : MonoBehaviour
{
    [SerializeField] Transform markersContainer_N, markersContainer_S;
    

	void Start ()
    {
        Debug.Log(FormingCoordinatesData(markersContainer_N));
    }

    private string FormingCoordinatesData(Transform _transform)
    {
        int childC = transform.childCount;
        string code = "";
        for (int i = 0; i < childC; i++)
        {
            code += _transform.GetChild(i).rotation.eulerAngles;
        }
        return code;
    }
}
