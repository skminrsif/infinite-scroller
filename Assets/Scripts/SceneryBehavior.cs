using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryBehavior : MonoBehaviour
{
    [SerializeField] public GameObject _povCamObjec;
    private Camera _povCam;
    private Plane[] _camFrustrum;
    private Bounds _bounds;
    // private Dictionary<GameObject, Bounds> _sceneryObjects;


    // get colliders of all scenery objects in a list?
    // scenery manager get all active scenery method

    // scenery manager 

    // Start is called before the first frame update
    void Start()
    {
        // _povCam = _povCamObject.GetComponent<Camera>();
        _camFrustrum = GeometryUtility.CalculateFrustumPlanes(_povCam);
        // _sceneryObjects = GameManager.Instance.SceneryManager.GetSceneryObjects();

        _bounds = GetComponent<Collider>().bounds;

        // Debug.Log("camFrus: " );
        // foreach (var plane in _camFrustrum) {
        //     Debug.Log(plane);
        // }
        
    }

    void Update()
    {
        // DetectObject(_camFrustrum, _sceneryObjects);

        DetectObject(_camFrustrum, _bounds);
    }

    // public void DetectObject(Plane[] planes, Dictionary<GameObject, Bounds> sceneryObjects) {
    //     foreach (var sceneryPair in sceneryObjects) {
    //         GameObject sceneryObject = sceneryPair.Key;
    //         Bounds sceneryBounds = sceneryPair.Value;

    //         Debug.Log(sceneryObject.name);
    //         Debug.Log(sceneryBounds);

    //         if (GeometryUtility.TestPlanesAABB(planes, sceneryBounds)) {
    //             Debug.Log(sceneryObject.name + " has been detected.");

    //         } else {
    //             Debug.Log("nothing");
    //         }
    //     }
        
    // }
    

    public void DetectObject(Plane[] planes, Bounds bounds) {
        if (GeometryUtility.TestPlanesAABB(planes, bounds)) {
            Debug.Log(name + " has been detected.");

        } else {
            Debug.Log("nothing");
        }

        
    }
}
