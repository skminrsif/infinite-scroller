using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Experimental;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rgbd;

    [SerializeField] private float _movementSpeed;
    private float _moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody>();
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

}
