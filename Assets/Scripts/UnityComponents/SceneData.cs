using UnityEngine;

namespace Unity.GameECS
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;

        public Transform CameraTransform => _cameraTransform;
    }
}