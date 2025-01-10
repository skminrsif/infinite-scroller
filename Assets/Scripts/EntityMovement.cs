using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    private Rigidbody _rgbd;

    private EnemyEntity entity;

    [SerializeField] private float _movementSpeed;
    
    // private float _moveHorizontal;

    private Vector3 _originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody>();
        _originalPosition = transform.position;
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
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("EndBoundary")) {
            TeleportToSpawn();
            gameObject.SetActive(false);
        }
    }
}
