using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryBehavior : MonoBehaviour
{
    private Camera _povCam;
    private Plane[] _camFrustrum;
    private Bounds _bounds;
    private MeshRenderer _meshRenderer;

    // Start is called before the first frame update
    void OnEnable()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _povCam = GameManager.Instance.CameraManager.GetPOVCamera();
        _bounds = GetComponent<Collider>().bounds;
        Debug.Log("enabled");
    }

    void FixedUpdate()
    {
        // DetectObject(_camFrustrum, _bounds);
        _camFrustrum = GeometryUtility.CalculateFrustumPlanes(_povCam); 
        DetectObject(_camFrustrum, _meshRenderer.bounds);

    }
    
    public void DetectObject(Plane[] planes, Bounds bounds) {
        if (GeometryUtility.TestPlanesAABB(planes, bounds)) {
            Debug.Log(name + " has been detected.");

        } else {
            Debug.Log("nothing");
        }

        
    }
}
