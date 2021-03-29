using UnityEngine;

[CreateAssetMenu(fileName = "CameraData", menuName = "CameraData/CameraData", order = 51)]
public class CameraData : ScriptableObject
{
    [SerializeField] private Vector3 _offset;

    public Vector3 Offset => _offset;
}
