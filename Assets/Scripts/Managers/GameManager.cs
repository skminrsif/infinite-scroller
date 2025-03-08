using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public FileManager FileManager {
        get;
        private set;
    }

    public CameraManager CameraManager {
        get;
        private set;
    }

    public SceneryManager SceneryManager {
        get;
        private set;

    }

    public UIManager UIManager {
        get; 
        private set;
        
    }

    public GameTimeManager GameTimeManager {
        get; 
        private set;
        
    }

    public static GameManager Instance {
        get;
        private set;

    }

    public enum GameState {
        Play,
        Pause,
        Quit

    }

    private GameState _gameState;

    // events    
    public UnityEvent onTestButtonPressed;
    public UnityEvent onPause;
    public UnityEvent onUnpause;

    public void Start() {
        _gameState = GameState.Play;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q) && (_gameState == GameState.Quit)) {
            #if UNITY_EDITOR 
                UnityEditor.EditorApplication.ExitPlaymode();
            
            #endif

            #if UNITY_STANDALONE
                Application.Quit();
            
            #endif
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (_gameState == GameState.Play) {
                onPause.Invoke();

            } else if (_gameState == GameState.Pause) {
                onUnpause.Invoke();

            }
            
        }

    }

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;
            
            UIManager = GetComponentInChildren<UIManager>();
            GameTimeManager = GetComponentInChildren<GameTimeManager>();
            SceneryManager = GetComponentInChildren<SceneryManager>();
            CameraManager = GetComponentInChildren<CameraManager>();
            FileManager = GetComponentInChildren<FileManager>();
        }

    
    }


    public void Quit()
    {
        _gameState = GameState.Quit; 

        #if UNITY_EDITOR 
            UnityEditor.EditorApplication.ExitPlaymode();
        
        #endif

        #if UNITY_STANDALONE
            Application.Quit();
        
        #endif

    }

    public bool IsPlaying() {
        if (_gameState == GameState.Play) {
            return true;
        }

        return false;
    }

    public void Pause() {
        SetGameState(GameState.Pause);
    }

    public void Play() {
        SetGameState(GameState.Play);
    }

    public GameState GetGameState() {
        return _gameState; 
    }

    public void SetGameState(GameState gameState) { // same with this; public vs private
        _gameState = gameState;
    }


}
