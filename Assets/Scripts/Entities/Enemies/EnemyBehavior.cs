using System.Collections;
using UnityEngine;

public class EnemyBehavior : EntityController
{
    [SerializeField] private float _maxWaitTime;
    private bool _haveWaited;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    void OnEnable() {
        _haveWaited = false;
    }

    void OnDisable() {
        _haveWaited = false;
    }

    public override void FixedUpdate() {
        base.Move(movementSpeed);

    }

    private IEnumerator WaitAndGo(float waitTime) {
        rgbd.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(waitTime);
        rgbd.constraints = RigidbodyConstraints.None;
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "PlayerBoundary") {
            if (!_haveWaited) {
                _haveWaited = true;
                float waitTime = Random.Range(0,_maxWaitTime);
                Debug.Log(waitTime);
                StartCoroutine(WaitAndGo(waitTime));
            }
            
        }
    }


    
}
