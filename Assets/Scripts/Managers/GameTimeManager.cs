using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    private float _gameTime;

     public static GameTimeManager Instance {
        get;
        private set;

    }

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;
            _gameTime = 0;
            
        }
    }

    // Start is called before the first frame update
    // void Start()
    // {
    //     _gameTime = 0;
    // }

    // Update is called once per frame
    void Update()
    {
        _gameTime += Time.deltaTime;
        GameManager.Instance.UIManager.ChangeSurvivalTimeText(_gameTime);
        
    }

    public float GetGameTime() {
        return _gameTime;
    }

    public void Pause() {
        Time.timeScale = 0;
    }

    public void Unpause() {
        Time.timeScale = 1;
    }
}
