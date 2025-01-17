using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

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
    }

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;
            
            UIManager = GetComponentInChildren<UIManager>();
            GameTimeManager = GetComponentInChildren<GameTimeManager>();
        }

    
    }

    public void Quit()
    {
        SetGameState(GameState.Quit); // change this part later

        GameTimeManager.Pause();
        UIManager.ShowQuitText();

    }

    public bool IsPlaying() {
        if (_gameState == GameState.Play) {
            return true;
        }

        return false;
    }

    public void Pause() {
        SetGameState(GameState.Pause);
        GameTimeManager.Pause();
        // might change this to return gamestate
    }

    public void Play() {
        SetGameState(GameState.Play);
    }

    public GameState GetGameState() {
        return _gameState; 
    }

    private void SetGameState(GameState gameState) { // same with this; public vs private
        _gameState = gameState;
    }

}
