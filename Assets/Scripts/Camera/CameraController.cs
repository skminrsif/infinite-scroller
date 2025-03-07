using System;
using UnityEngine;
using UnityEngine.Events;

public class CameraController : MonoBehaviour
{
    // public UnityEvent onCameraScreenshot;
    // public UnityEvent onFilmEmpty;

    public void TakeScreenshot() {
        string temporaryScreenshot = GameManager.Instance.FileManager.AddTemporaryScreenshot();
        ScreenCapture.CaptureScreenshot(temporaryScreenshot);
        Debug.Log(temporaryScreenshot);
    }



    // m = data, v = ui, c= logic 
}
