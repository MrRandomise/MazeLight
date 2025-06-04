using Zenject;
using MazeLight.Characters;
using UnityEngine;
using Unity.AI.Navigation;
using MazeLight.GenerateMze;

namespace MazeLight.Core
{
    public sealed class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GenerateMaze>().AsSingle().NonLazy();

            Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
            Container.Bind<NavMeshSurface>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesAndSelfTo<MovePlayer>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CameraBoundaries>().AsSingle().NonLazy();
        }
    }
}
