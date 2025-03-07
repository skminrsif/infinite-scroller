using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : EntityController
{
    
    private EnemyManager _enemyManager;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        _enemyManager = GetComponent<EnemyManager>();
        
    }

    void FixedUpdate() {
        Debug.Log(_enemyManager.IsOnBoundary);
        Debug.Log("EnemyBehavior FU");

        if (_enemyManager == null) {
            if (!_enemyManager.IsOnBoundary) {
                base.Move(movementSpeed);

            } else {
                base.StopMove();

            }
        }
        
        

    }


    
}
