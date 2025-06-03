using Zenject;
using MazeLight.Characters;
using UnityEngine;

namespace MazeLight.Core
{
    public sealed class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Player>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesAndSelfTo<MovePlayer>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CameraBoundaries>().AsSingle().NonLazy();
        }
    }
}
