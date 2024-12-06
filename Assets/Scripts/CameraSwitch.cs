using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _isoCamObj;
    [SerializeField] private GameObject _povCamObj;

    private Camera _isoCam;
    private Camera _povCam;
    private Camera _mainCam;
    private Camera _subCam;
    
    private Rect _mainCamRect;
    private Rect _subCamRect;

    // Start is called before the first frame update
    void Start()
    {
        _isoCam = _isoCamObj.GetComponent<Camera>(); 
        _povCam = _povCamObj.GetComponent<Camera>();

        // default values
        _mainCam = _isoCam;    
        _subCam = _povCam;

        _mainCamRect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        _subCamRect = new Rect(0.7f, 0.7f, 0.3f, 0.3f); 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            SwitchCamera(_mainCam, _subCam);
        }
        
    }

    private void SwitchCamera(Camera oldCamera, Camera newCamera) {
        oldCamera.rect = _subCamRect;
        newCamera.rect = _mainCamRect;

        oldCamera.depth = 0;
        newCamera.depth = -1;

        if (oldCamera == _isoCam) {
            _mainCam = _povCam;
            _subCam = _isoCam;

        } else {
            _mainCam = _isoCam;
            _subCam = _povCam;

        }
    }
}
