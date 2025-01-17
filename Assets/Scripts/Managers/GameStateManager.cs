using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    public static GameStateManager Instance {
        get;
        private set;

    }

    public enum GameState {
        Play,
        Pause

    }

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;
            
        }
    }
    
}
