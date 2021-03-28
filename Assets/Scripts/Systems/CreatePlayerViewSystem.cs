using Leopotam.Ecs;
using UnityEngine;

namespace Unity.GameECS
{
    internal class CreatePlayerViewSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent>.Exclude<PlayerViewRef> _filter;
        private PlayerInitData _playerInitData;

        public void Run()
        {
            foreach (var item in _filter)
            {
                var playerView = Object.Instantiate(_playerInitData.PlayerPrefab);
                playerView.transform.position = _playerInitData.StartPosition;

                _filter.GetEntity(item).Get<PlayerViewRef>().Value = playerView;
            }
        }
    }
}