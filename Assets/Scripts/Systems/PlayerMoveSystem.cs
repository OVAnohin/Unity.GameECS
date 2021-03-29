using Leopotam.Ecs;
using UnityEngine;

namespace Unity.GameECS
{
    internal class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerViewRef, PlayerMovableComponent> _filter;

        public void Run()
        {
            foreach (var item in _filter)
            {
                ref var player = ref _filter.Get1(item);
                ref var playerMovableComponent = ref _filter.Get2(item);
                MoveThePlayer(player, playerMovableComponent);
            }
        }

        private void MoveThePlayer(PlayerViewRef player, PlayerMovableComponent playerMovableComponent)
        {
            Vector3 movement = Vector3.right * playerMovableComponent.MovementSpeed * Time.deltaTime;
            player.Value.GetComponent<Rigidbody>().MovePosition(player.Value.transform.position + movement);
        }
    }
}