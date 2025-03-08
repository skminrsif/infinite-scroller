using UnityEngine;

public class EntityController : MonoBehaviour
{
    protected Rigidbody rgbd;

    protected EnemyData entity;

    [SerializeField] protected float movementSpeed;
    
    // private float _moveHorizontal;

    protected Vector3 originalPosition;
    protected Quaternion originalRotation;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public virtual void FixedUpdate() {
        Move(movementSpeed);
        Debug.Log("EntityController FU");

    }

    public void Move(float speed) {
        rgbd.velocity = new Vector3(speed, 0, 0);
        
    }

    public void StopMove() {
        rgbd.velocity = new Vector3(0, 0, 0);
    }

    protected virtual void TeleportToSpawn() {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        rgbd.velocity = new Vector3(0, 0, 0);
        rgbd.angularVelocity = new Vector3(0, 0, 0);
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("EndBoundary")) {
            TeleportToSpawn();
            gameObject.SetActive(false);
        }
    }
}
