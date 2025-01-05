using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float _gameTime;

    // Start is called before the first frame update
    void Start()
    {
        _gameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _gameTime += Time.deltaTime;
        
    }

    public float GetGameTime() {
        return _gameTime;
    }
}
