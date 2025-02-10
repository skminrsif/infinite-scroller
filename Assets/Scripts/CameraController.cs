using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private GameObject _povCamObj;
    private Camera _povCam;
    private Plane[] _camFrustrum;
    private Dictionary<GameObject, Bounds> _sceneryObjects;


    // get colliders of all scenery objects in a list?
    // scenery manager get all active scenery method

    // scenery manager 

    // Start is called before the first frame update
    void Start()
    {
        _povCam = GetComponent<Camera>();
        _camFrustrum = GeometryUtility.CalculateFrustumPlanes(_povCam);
        _sceneryObjects = GameManager.Instance.SceneryManager.GetSceneryObjects();

        Debug.Log("camFrus: " );
        foreach (var plane in _camFrustrum) {
            Debug.Log(plane);
        }
        
    }

    void Update()
    {
        DetectObject(_camFrustrum, _sceneryObjects);
    }

    public void DetectObject(Plane[] planes, Dictionary<GameObject, Bounds> sceneryObjects) {
        foreach (var sceneryPair in sceneryObjects) {
            GameObject sceneryObject = sceneryPair.Key;
            Bounds sceneryBounds = sceneryPair.Value;

            Debug.Log(sceneryObject.name);
            Debug.Log(sceneryBounds);

            if (GeometryUtility.TestPlanesAABB(planes, sceneryBounds)) {
                Debug.Log(sceneryObject.name + " has been detected.");

            } else {
                Debug.Log("nothing");
            }
        }



        // for (int i = 0; i < _sceneryColliders.Count; i++){
        //     if (GeometryUtility.TestPlanesAABB(_camFrustrum, _sceneryColliders[i].bounds)) {
        //         Debug.Log("detected");

        //     }


        // }
            
        
    }

    // m = data, v = ui, c= logic 
}
