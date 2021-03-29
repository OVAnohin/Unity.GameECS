using Leopotam.Ecs;
using UnityEngine;
using Cinemachine;

namespace Unity.GameECS
{
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private PlayerInitData _playerInitData;
        [SerializeField] private CinemachineVirtualCamera _vcamCM;

        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems
                // register your systems here, for example:
                .Add(new GameInitializeSystem())
                .Add(new CreatePlayerViewSystem())
                .Add(new PlayerMoveSystem())
                .Add(new PlayerRotateSystem())

                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()

                // inject service instances here (order doesn't important), for example:
                .Inject(_playerInitData)
                // .Inject (new NavMeshSupport ())
                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}