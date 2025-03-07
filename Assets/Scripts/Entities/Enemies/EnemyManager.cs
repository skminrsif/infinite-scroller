using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float _waitTime;
    public static EnemyManager Instance {
        get;
        private set;

    }

    public bool IsOnBoundary { get; private set; }

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;
            IsOnBoundary = false;
        }
    }

    void OnEnable() {
        PlayerBoundary.Instance.onEnemyCrossingPlayerBoundary.AddListener(StartWaitAndGo);

    }

    void OnDisable() {
        PlayerBoundary.Instance.onEnemyCrossingPlayerBoundary.RemoveListener(StartWaitAndGo);
    }
    
    public void StartWaitAndGo() {
        StartCoroutine(WaitAndGo(_waitTime));
    }


    private IEnumerator WaitAndGo(float waitTime) {
        IsOnBoundary = true;
        yield return new WaitForSeconds(waitTime);
        IsOnBoundary = false;
        
    }


    

}
