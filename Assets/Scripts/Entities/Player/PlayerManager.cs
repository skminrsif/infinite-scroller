using UnityEngine;
using UnityEngine.Events;


[System.Serializable] public class IntEvent : UnityEvent<int> { }
[System.Serializable] public class DoubleIntEvent : UnityEvent<int, int> { }
[System.Serializable] public class FloatEvent : UnityEvent<float> { }

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    private int _lives;
    private int _filmCount;    
    private int _originalLayer;

    // events
    public DoubleIntEvent OnPlayerInitialize;
    public IntEvent OnPlayerHit;
    public UnityEvent OnPlayerDeath;
    public UnityEvent OnPlayerRespawn;
    public FloatEvent OnPlayerInvulPowerUp;
    public IntEvent OnPlayerScreenshot;
    public UnityEvent OnPlayerFilmEmpty;

    // player states
    public bool IsInvulnerable { get; private set; }
    public bool IsHurt { get; private set; }

     public static PlayerManager Instance {
        get;
        private set;

    }

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;
            PlayerInitialize();

        }

    }

    private void PlayerInitialize() {
        _lives = _playerData.lives;
        _filmCount = _playerData.filmCount;
        
        _originalLayer = gameObject.layer;

        IsInvulnerable = false;
        IsHurt = false;

        OnPlayerInitialize.Invoke(_lives, _filmCount);
        
        
    }

    public void SwitchToInvulnerableState() {
        if (IsInvulnerable) {
            gameObject.layer = LayerMask.NameToLayer("Invulnerable");
        }
    }

    public void SwitchToDefaultState() {
        if (IsInvulnerable) {
            gameObject.layer = _originalLayer;
            Debug.Log("wah");
        }

    }

    public void PlayerHit() {
        if (!IsHurt && !IsInvulnerable) {
            _lives--;
            IsInvulnerable = true;
            IsHurt = true;

            if (_lives <= 0) {
                OnPlayerDeath.Invoke();
                
            } else {
                OnPlayerHit.Invoke(_lives);
            }

        }
        

    }

    public void PlayerInvulPowerUp() {
        IsInvulnerable = true;    
        OnPlayerInvulPowerUp.Invoke(_playerData.invulTime);
    }

    public void PlayerRecover() {
        IsHurt = false;
    }

    public void PlayerNotInvulnerable() {
        IsInvulnerable = false;
    }

    public void PlayerScreenshot() {
        if (_filmCount > 0) {
            OnPlayerScreenshot.Invoke(_filmCount);
        }
        
        _filmCount--;
    }

    public void RespawnPlayer() {

        IsInvulnerable = false;
        IsHurt = false;

        OnPlayerRespawn.Invoke();

    }

}
