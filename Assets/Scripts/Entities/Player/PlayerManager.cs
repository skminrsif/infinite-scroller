using System;
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
    public GameObject PlayerObject { get; private set; }

    // events
    public DoubleIntEvent onPlayerInitialize;
    public IntEvent onPlayerHit;
    public UnityEvent onPlayerDeath;
    public UnityEvent onPlayerRespawn;
    public FloatEvent onPlayerInvulPowerUp;
    public IntEvent onPlayerScreenshot;
    public UnityEvent onPlayerFilmEmpty;

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

        PlayerObject = gameObject;

        onPlayerInitialize.Invoke(_lives, _filmCount);
        
        
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
                onPlayerDeath.Invoke();
                
            } else {
                onPlayerHit.Invoke(_lives);

            }

        }
        
    }


    public void PlayerInvulPowerUp() {
        IsInvulnerable = true;    
        onPlayerInvulPowerUp.Invoke(_playerData.invulTime);
    }

    public void PlayerRecover() {
        IsHurt = false;
        
    }

    public void PlayerNotInvulnerable() {
        IsInvulnerable = false;
    }

    public void PlayerScreenshot() {
        if (GameManager.Instance.GetGameState() == GameManager.GameState.Play) {
            if (_filmCount > 0) {
                _filmCount--;
                onPlayerScreenshot.Invoke(_filmCount);
                
            } else {
                onPlayerFilmEmpty.Invoke();

            }
        }
        
        
        
    }

    public void RespawnPlayer() {

        IsInvulnerable = false;
        IsHurt = false;

        onPlayerRespawn.Invoke();

    }

    public Vector3 GetPlayerLastPosition() {
        return PlayerObject.transform.position;
    }

}
