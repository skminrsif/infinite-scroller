using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Experimental;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rgbd;

    [SerializeField] private float _movementSpeed;
    private float _moveVertical;

    private int _lives;

    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody>();
        _lives = 3;

    }

    // Update is called once per frame
    void Update()
    {
        _moveVertical = Input.GetAxis("Vertical");
    }

    public void FixedUpdate() {
        Move(_movementSpeed * _moveVertical);

    }

    private void Move(float speed) {
        _rgbd.AddForce(0, 0, speed);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            _lives -= 1;
            Debug.Log("Player Lives: " + _lives);
        }
    }

}

