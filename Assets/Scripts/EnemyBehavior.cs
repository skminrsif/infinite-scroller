using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody _rgbd;

    [SerializeField] private float _movementSpeed;
    // private float _moveHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody>();
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

    
}
