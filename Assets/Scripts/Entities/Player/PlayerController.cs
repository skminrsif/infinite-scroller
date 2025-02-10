using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rgbd;
    private Renderer _renderer;
    private Color _originalColor; // remove this once art assets are done

    [SerializeField] private float _movementSpeed;
    private float _moveVertical;

    private int _lives;
    
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    private int _originalLayer;

    [SerializeField] private float _invulTime;
    [SerializeField] private float _deathInvulTime;
    [SerializeField] private float _deathTime;
    [SerializeField] private float _invulPowerTime;


    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
        _originalLayer = gameObject.layer;

        _lives = 10;
        
        // move this later to a separate class (PlayerManager) - controller should only be input
        GameManager.Instance.UIManager.ChangeLivesText(_lives); 

        _originalPosition = transform.position;
        _originalRotation = transform.rotation;

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
            Vector3 deathPosition = transform.position;
            DecreaseLives();    
            // lock down state to death invul
            StartCoroutine(GainDeathInvulnerability(_deathTime, _deathInvulTime, deathPosition));

        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Invulnerability") {
            other.gameObject.SetActive(false);
            StartCoroutine(GainInvulnerability(_invulTime, Color.yellow));
            // lock down state to invul power up
        }
    }

    // change these to respective animations once art assets are done
    private IEnumerator GainDeathInvulnerability(float deathTime, float deathInvulTime, Vector3 deathPosition) {
        _renderer.material.color = Color.black;
        yield return new WaitForSeconds(deathTime);
        _renderer.material.color = _originalColor;

        transform.position = deathPosition;
        transform.rotation = _originalRotation;
        StartCoroutine(GainInvulnerability(deathInvulTime, Color.white));
    }

    private IEnumerator GainInvulnerability(float invulTime, Color color) {
        int LayerInvulnerable = LayerMask.NameToLayer("Invulnerable");
        _renderer.material.color = color;
        Debug.Log("invulnerability starts: time: " + invulTime);
        
        gameObject.layer = LayerInvulnerable;
        yield return new WaitForSeconds(invulTime);
        Debug.Log("invulnerability ends");
        _renderer.material.color = _originalColor;
        gameObject.layer = _originalLayer;
        
    }

    private void DecreaseLives() {
        _lives -= 1;
        GameManager.Instance.UIManager.ChangeLivesText(_lives);

        if (_lives == 0) {
            GameManager.Instance.Quit();
        }

    }

    // private void TakePicture() {

    // }

    

}

