using UnityEngine;
using UnityEngine.Pool;

namespace Runner.StackCubes
{
    public class StackCubesPool : MonoBehaviour
    {
        [Header("Pool Prefabs")]
        [SerializeField] private CubeStack _cubePrefab;

        protected IObjectPool<CubeStack> pool;

        protected void Awake()
        {
            pool = new ObjectPool<CubeStack>(CreateCube, OnGetCube, onReleaseCube);
        }

        private void Start()
        {
            if (_cubePrefab == null)
            {
                Debug.LogError($"{nameof(_cubePrefab)} is not set in {nameof(StackCubesPool)}. Object name: {gameObject.name}");
                return;
            }
        }

        private CubeStack CreateCube()
        {
            return Instantiate(_cubePrefab);
        }

        private void OnGetCube(CubeStack cube)
        {
            cube.gameObject.SetActive(true);
            cube.transform.SetParent(transform);
        }

        private void onReleaseCube(CubeStack cube)
        {
            cube.transform.SetParent(null);
        }

        private void OnDestroy()
        {
            pool.Clear();
        }
    }
}