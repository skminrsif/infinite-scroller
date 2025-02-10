using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class EntityMovement : MonoBehaviour
{
    private Rigidbody _rgbd;

    private EnemyData entity;

    [SerializeField] private float _movementSpeed;
    
    // private float _moveHorizontal;

    private Vector3 _originalPosition;
    private Quaternion _originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody>();
        _originalPosition = transform.position;
        _originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate() {
        Move(_movementSpeed);

    }

    private void Move(float speed) {
        _rgbd.velocity = new Vector3(speed, 0, 0);
        
    }

    // TO DO : tp back to assigned spawner once it reaches the end boundary
    private void TeleportToSpawn() {
        transform.position = _originalPosition;
        transform.rotation = _originalRotation;
        _rgbd.velocity = new Vector3(0, 0, 0);
        _rgbd.angularVelocity = new Vector3(0, 0, 0);
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("EndBoundary")) {
            TeleportToSpawn();
            gameObject.SetActive(false);
        }
    }
}
