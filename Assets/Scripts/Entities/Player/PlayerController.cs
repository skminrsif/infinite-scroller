using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rgbd;
    private Renderer _renderer;
    private Color _originalColor; // remove this once art assets are done
    private float _moveVertical;
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    
    private PlayerManager _playerManager;
    private RigidbodyConstraints _originalConstraints;
    [SerializeField] private PlayerData _playerData;

    void Awake() {
        _rgbd = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;

        _playerManager = GetComponent<PlayerManager>();
        _originalPosition = transform.position;
        _originalRotation = transform.rotation;
        _originalConstraints = _rgbd.constraints;

    }

    // Update is called once per frame
    void Update()
    {
        _moveVertical = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Q)) {
            GameManager.Instance.onTestButtonPressed.Invoke();
        }

    }

    void LateUpdate() {
        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("Screenshotting...");
            _playerManager.PlayerScreenshot();
        }
    }

    void FixedUpdate() {
        if (!_playerManager.IsHurt) {
            Move(_playerData.movementSpeed * _moveVertical);
        }
        
    }

    private void Move(float speed) {
        _rgbd.AddForce(0, 0, speed);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Obstacle") {
            if (!_playerManager.IsHurt && !_playerManager.IsInvulnerable) {
                _playerManager.PlayerHit();

            }
            
        }
    }

    public void OnPlayerHit() {
        StartCoroutine(GainDeathInvulnerability(_playerData.deathTime, _playerData.deathInvulTime,
        transform.position));
    }

    public void OnPlayerInvulPowerUp(float invulnerabilityTime) {
        StartCoroutine(GainPowerUpInvulnerability(invulnerabilityTime));
    }

    private IEnumerator GainDeathInvulnerability(float deathTime, float deathInvulnerabilityTime, Vector3 deathPosition) {
        _renderer.material.color = Color.black;
        SetPlayerConstraintsActive(false);
        yield return new WaitForSeconds(deathTime);

        _playerManager.SwitchToInvulnerableState();
        _renderer.material.color = Color.white;
        transform.position = deathPosition;
        transform.rotation = _originalRotation;
        _playerManager.PlayerRecover();

        yield return new WaitForSeconds(deathInvulnerabilityTime);

        Debug.Log("normal" + _playerManager.IsHurt);
        _renderer.material.color = _originalColor;
        _playerManager.SwitchToDefaultState();
        _playerManager.PlayerNotInvulnerable();
        SetPlayerConstraintsActive(true);

    }

    private IEnumerator GainPowerUpInvulnerability(float invulnerabilityTime) {
        _renderer.material.color = Color.white;
        _playerManager.SwitchToInvulnerableState();
        yield return new WaitForSeconds(invulnerabilityTime);
        _renderer.material.color = _originalColor;
        _playerManager.SwitchToDefaultState();

    }

    private void SetPlayerConstraintsActive(bool active) {
        if (active) {
            _rgbd.constraints = _originalConstraints;

        } else {
            _rgbd.constraints = RigidbodyConstraints.FreezePositionX;

        }
        
    }

    

}

