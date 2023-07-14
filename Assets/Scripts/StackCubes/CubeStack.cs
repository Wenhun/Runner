using UnityEngine;

namespace Runner.StackCubes
{
    public class CubeStack : MonoBehaviour
    {
        [Header("Cube Boundaries")] 
        [Tooltip("Boundaries are needed to calculate the size of the cube. They must be set on the top and bottom faces of the cube.")]
        [SerializeField] private Transform _topBoundary;
        [Tooltip("Boundaries are needed to calculate the size of the cube. They must be set on the top and bottom faces of the cube.")]
        [SerializeField] private Transform _bottomBoundary;

        public Vector3 SizeCube { get => _topBoundary.position - _bottomBoundary.position; }
        public Vector3 TopCube { get => _topBoundary.position; }

        private void Start()
        {
            if (_topBoundary == null || _bottomBoundary == null)
            {
                Debug.LogError($"Some serializable fields is not set in {nameof(CubeStack)}. Object name: {gameObject.name}");
            }
        }
    }
}