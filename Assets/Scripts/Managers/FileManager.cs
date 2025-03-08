using System.Collections.Generic;
using System.IO;
using UnityEngine.Events;
using UnityEngine;
using UnityEditor;

public class FileManager : MonoBehaviour
{
    private string _folderPath;
    private string _tempFileName;
    private string _tempFolderPath;
    private string _fileType;
    public List<string> TemporaryScreenshotsFilePathList { get; private set; }
    public List<string> TemporaryScreenshotsFileNameList { get; private set; }

    private string _permanentFolderPath;
    private string _permanentFileName;

    private int _cursor;

    public UnityEvent onVeryStartOfTemporaryScreenshots;
    public UnityEvent onVeryEndOfTemporaryScreenshots;


    public static FileManager Instance {
        get;
        private set;

    }

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;
            TemporaryScreenshotsFilePathList = new List<string>();
            TemporaryScreenshotsFileNameList = new List<string>();
            _tempFolderPath = Directory.GetCurrentDirectory() + @"\temp_screenshots";

            if (!Directory.Exists(_tempFolderPath)) {
                Directory.CreateDirectory(_tempFolderPath);
            }

            _tempFileName = "temporaryScreenshot_";

            _permanentFolderPath = Directory.GetCurrentDirectory() + @"\Screenshots";

            if (!Directory.Exists(_permanentFolderPath)) {
                Directory.CreateDirectory(_permanentFolderPath);
            }

            _permanentFileName = "Screenshot_";

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
        string tempScreenshotName = _tempFileName + TemporaryScreenshotsFilePathList.Count + _fileType;
        TemporaryScreenshotsFileNameList.Add(tempScreenshotName);

        string tempScreenshot = Path.Combine(_tempFolderPath, tempScreenshotName);
        TemporaryScreenshotsFilePathList.Add(tempScreenshot);
        return tempScreenshot;
    }

    public void DeleteTempScreenshotFolder() {
        if (Directory.Exists(_tempFolderPath)) {
            Directory.Delete(_tempFolderPath, true);
        }
        
    }

    public void SwitchImageShown(int cursor) {
        if (cursor == TemporaryScreenshotsFilePathList.Count - 1) {
            onVeryEndOfTemporaryScreenshots.Invoke();

        } else if (cursor <= 0) {
            onVeryStartOfTemporaryScreenshots.Invoke();
        }


        GameManager.Instance.UIManager.ShowImage(TemporaryScreenshotsFilePathList[cursor]);

    }

    public void MoveCursorToRight() {
        _cursor++;
        SwitchImageShown(_cursor);        
    }

    public void MoveCursorToLeft() {
        _cursor--;
        SwitchImageShown(_cursor);

    }

    public void SavePermanentScreenshot() {
        string tempScreenshot = TemporaryScreenshotsFilePathList[_cursor];
        string newScreenshot = _permanentFileName + System.DateTime.Now.ToString("MM-dd-yy (HH-mm-ss)") + _fileType;
        string newScreenshotPath = Path.Combine(_permanentFolderPath, newScreenshot);
        FileUtil.CopyFileOrDirectory(tempScreenshot, newScreenshotPath);

    }

    
}
