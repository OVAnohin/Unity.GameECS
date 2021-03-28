using System.Collections;
using System.Collections.Generic;
using Unity.GameECS;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInitData", menuName = "PlayerInitData/PlayerInitData", order = 51)]
public class PlayerInitData : ScriptableObject
{
    [SerializeField] private PlayerView _playerPrefab;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector3 _startPosition;

    public PlayerView PlayerPrefab => _playerPrefab;
    public float MovementSpeed => _movementSpeed;
    public float RotationSpeed => _rotationSpeed;
    public float JumpForce => _jumpForce;
    public Vector3 StartPosition => _startPosition;
}
