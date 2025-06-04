using Unity.AI.Navigation;
using UnityEngine;

namespace MazeLight.GenerateMze
{
    public sealed class GenerateMaze 
    {
        private NavMeshSurface _surface;

        private GenerateMaze(NavMeshSurface surface)
        {
            _surface = surface;
            _surface.BuildNavMesh();
        }


    }
}

