using System.Collections.Generic;
using System.IO;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    private string _folderPath;
    private string _tempFileName;
    private string _tempFolderPath;
    private string _fileType;
    public List<string> TemporaryScreenshotsList { get; private set; }
    private int _cursor;

    public static FileManager Instance {
        get;
        private set;

    }

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;
            TemporaryScreenshotsList = new List<string>();
            _tempFolderPath = Directory.GetCurrentDirectory() + @"\temp_screenshots";

            if (!Directory.Exists(_tempFolderPath)) {
                Directory.CreateDirectory(_tempFolderPath);
            }

            _tempFileName = "temporaryScreenshot_";
            _fileType = ".png";
            _cursor = 0;
        }
    }

    public string GetFolderPath() {
        return _folderPath;
    }

    public string GetTempFolderPath() {
        return _tempFolderPath;
    }

    public void SetFolderPath(string folderPath) {
        _folderPath = folderPath;
    }

    public string AddTemporaryScreenshot() {
        string tempScreenshotName = _tempFileName + TemporaryScreenshotsList.Count + _fileType;
        string tempScreenshot = Path.Combine(_tempFolderPath, tempScreenshotName);
        TemporaryScreenshotsList.Add(tempScreenshot);
        return tempScreenshot;
    }

    public void DeleteTempScreenshotFolder() {
        Directory.Delete(_folderPath);
    }

    // public List<string> AddToScreenshotsList(string fileName) {
    //     ScreenshotsList.Add(fileName);
    //     return Screen
    // }

    public void SwitchImageShown(int cursor) {
        
    }

    // public 

    

    
}
