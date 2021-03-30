using Cinemachine;
using UnityEngine;

namespace Unity.GameECS
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        public CinemachineVirtualCamera VirtualCamera => _virtualCamera;
    }
}