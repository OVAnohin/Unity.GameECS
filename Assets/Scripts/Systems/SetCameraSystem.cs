using Cinemachine;
using Leopotam.Ecs;
using UnityEngine;

namespace Unity.GameECS
{
    internal class SetCameraSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerViewRef> _playerFilter;
        private EcsFilter<UpdateCameraEvent> _cameraFilter;
        private SceneData _sceneData;

        public void Run()
        {
            if (!_cameraFilter.IsEmpty())
            {
                foreach (var item in _playerFilter)
                {
                    ref var player = ref _playerFilter.Get1(item);
                    _sceneData.VirtualCamera.Follow = player.SceneObject.transform;
                    _sceneData.VirtualCamera.LookAt = player.SceneObject.transform;
                }
            }
        }
    }
}