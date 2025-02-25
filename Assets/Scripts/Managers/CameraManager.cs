using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject _povCameraObject;
    [SerializeField] private GameObject _isoCameraObject;
    private Camera _povCamera;
    private Camera _isometricCamera;

    [SerializeField] private CinemachineVirtualCamera _fadeInAndOutCameraVM;
    [SerializeField] private CinemachineVirtualCamera _povCameraVM;
    [SerializeField] private CinemachineVirtualCamera _isoCameraVM;

    public static CameraManager Instance {
        get;
        private set;

    }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;
            _povCamera = _povCameraObject.GetComponent<Camera>();
            _isometricCamera = _isoCameraObject.GetComponent<Camera>();
        }
    }

    public Camera GetPOVCamera() {
        return _povCamera;

    }

    public Camera GetIsometricCamera() {
        return _isometricCamera;

    }

    public CinemachineVirtualCamera GetFadeInAndOutCameraVM() {
        return _fadeInAndOutCameraVM;

    }

    public CinemachineVirtualCamera GetPOVCameraVM() {
        return _povCameraVM; 

    }

    public CinemachineVirtualCamera GetIsometricCameraVM() {
        return _isoCameraVM;

    }


}
