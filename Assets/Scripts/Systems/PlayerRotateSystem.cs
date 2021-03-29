using Leopotam.Ecs;
using UnityEngine;

namespace Unity.GameECS
{
    internal class PlayerRotateSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerViewRef, PlayerMovableComponent> _filter;
        private float _turnAngle = -10f;

        public void Run()
        {
            foreach (var item in _filter)
            {
                ref var player = ref _filter.Get1(item);
                ref var playerMovableComponent = ref _filter.Get2(item);
                TurnThePlayer(player, playerMovableComponent);
            }
        }

        private void TurnThePlayer(PlayerViewRef player, PlayerMovableComponent playerMovableComponent)
        {
            Rigidbody playerRigidbody = player.Value.GetComponent<Rigidbody>();
            Quaternion turn = playerRigidbody.rotation * Quaternion.Euler(0, 0, _turnAngle);
            Quaternion rotation = Quaternion.Slerp(playerRigidbody.rotation, turn, playerMovableComponent.RotationSpeed);
            playerRigidbody.MoveRotation(rotation);
        }
    }
}