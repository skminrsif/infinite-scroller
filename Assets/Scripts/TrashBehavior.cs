using System.Collections;
using UnityEngine;
public class TrashBehavior : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _despawnTime;
    private Vector3 _playerLastPosition;

    void Awake() {
        _playerLastPosition = PlayerManager.Instance.GetPlayerLastPosition();
        gameObject.GetComponent<Collider>().includeLayers = LayerMask.NameToLayer("Player");
    }

    

    void FixedUpdate()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _playerLastPosition, step);

    }

    void Update() {
        if (Vector3.Distance(transform.position, _playerLastPosition) < 0.3) {
            gameObject.GetComponent<Collider>().excludeLayers = LayerMask.NameToLayer("Player");
            StartCoroutine(Despawn());
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("touched player");
            StartCoroutine(Despawn());
        }

    }

    private IEnumerator Despawn() {
        yield return new WaitForSeconds(_despawnTime);

        gameObject.SetActive(false);
    }


}
