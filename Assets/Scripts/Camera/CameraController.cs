using System;
using UnityEngine;
using UnityEngine.Events;

public class CameraController : MonoBehaviour
{
    public void TakeScreenshot() {
        string temporaryScreenshot = GameManager.Instance.FileManager.AddTemporaryScreenshot();
        ScreenCapture.CaptureScreenshot(temporaryScreenshot);
        Debug.Log(temporaryScreenshot);
    }


}
