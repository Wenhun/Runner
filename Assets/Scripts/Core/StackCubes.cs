using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Runner.Core
{
    public class StackCubes : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] CubeSizer cubePrefab;
        [SerializeField] UpperCubeChecker player;
        [SerializeField] CollisionEvens collisionEvens;

        [Header("Settings")]
        [SerializeField, Range(6, 9)] int maxCubesInStack;
        [SerializeField, Range(0.5f, 1)] float disableTime = 1f;

        private IObjectPool<CubeSizer> cubesPool;

        int countActiveCubes = 0;
        public int CountActiveCube { get => countActiveCubes; }

        void Awake()
        {
            cubesPool = new ObjectPool<CubeSizer>(CreateCube, OnGet, onRelease, defaultCapacity: maxCubesInStack);
            cubesPool.Get();
        }

        #region  Object Pool methods
        private CubeSizer CreateCube()
        {
            CubeSizer newCube = Instantiate(cubePrefab);
            return newCube;
        }

        private void OnGet(CubeSizer cube)
        {
            countActiveCubes++;
            player.transform.position += cube.SizeCube * 2;
            if (player.UpperCube != null) cube.transform.position = player.UpperCube.TopCube + cube.SizeCube;
            cube.transform.parent = gameObject.transform;
            cube.gameObject.SetActive(true);
        }

        private void onRelease(CubeSizer cube)
        {
            countActiveCubes--;
            cube.transform.SetParent(null);
            StartCoroutine(CubeDisabler(cube));
        }
        #endregion

        public void AddNewCube()
        {
            if (countActiveCubes < maxCubesInStack)
            {
                cubesPool.Get();
                collisionEvens.pickUp.Invoke();
            }
        }

        public void RemoveCube(GameObject cube)
        {
            cubesPool.Release(cube.GetComponent<CubeSizer>());
            collisionEvens.wallCollision.Invoke();
        }

        //disable cube after wall collision
        IEnumerator CubeDisabler(CubeSizer cube)
        {
            yield return new WaitForSeconds(disableTime);
            if (countActiveCubes > 0) cube.gameObject.SetActive(false);
        }
    }
}
