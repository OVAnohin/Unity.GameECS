using Leopotam.Ecs;

namespace Unity.GameECS
{
    internal class GameInitializeSystem : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private PlayerInitData _playerInitData;

        public void Init()
        {
            var player = _world.NewEntity();
            player.Get<PlayerComponent>().Score = 0;
            player.Get<PlayerMovableComponent>().JumpForce = _playerInitData.JumpForce;
            player.Get<PlayerMovableComponent>().MovementSpeed = _playerInitData.MovementSpeed;
            player.Get<PlayerMovableComponent>().RotationSpeed = _playerInitData.RotationSpeed;
        }
    }
}