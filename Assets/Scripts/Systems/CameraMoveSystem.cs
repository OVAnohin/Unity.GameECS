using Leopotam.Ecs;
using UnityEngine;

namespace Unity.GameECS
{
    internal class CameraMoveSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerViewRef> _filter;
        private SceneData _sceneData;
        private CameraData _cameraData;

        public void Run()
        {
            foreach (var item in _filter)
            {
                ref var player = ref _filter.Get1(item);
                var cameraTransform = _sceneData.CameraTransform;
                var offset = _cameraData.Offset;
                cameraTransform.position = new Vector3(player.SceneObject.transform.position.x + offset.x, offset.y, offset.z);
            } 
        }
    }
}