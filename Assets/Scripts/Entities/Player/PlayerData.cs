using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Entity Data/Player Data")]
public class PlayerData : EntityData
{
    private Rigidbody _rgbd;
    private Renderer _renderer;
    private Color _originalColor; // remove this once art assets

    [SerializeField] private float _movementSpeed;
    private float _moveVertical;

    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    private int _originalLayer;

    private int _lives;
    [SerializeField] private float _invulTime;
    

}
