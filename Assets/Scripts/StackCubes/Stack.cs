using UnityEngine;
using System.Collections;
using Runner.GamePlay;

namespace Runner.StackCubes
{
    public class Stack : StackCubesPool
    {
        [Header("Stack Prefabs")]
        [SerializeField] private UpperCubeChecker _upperCubeChecker;

        [Header("Settings")]
        [SerializeField, Range(5, 7)] private int _maxCubesInStack = 5;
        [SerializeField, Range(0.5f, 1)] private float _disableTime = 1f;
        [SerializeField, Range(0.5f, 2)] private float _jumpHeight = 0.5f;

        private int _countActiveCubes = 0;
        private GameEvents _gameEvents;
        private Vector3 _jumpVector;

        public static Stack Instance {get; private set;}

        private void Start()
        {
            if (Instance != null)
            {
                Debug.LogError($"Object {nameof(Stack)} already created. Object name: {gameObject.name}");
                return;
            }

            Instance = this;

            if (_upperCubeChecker == null)
            {
                Debug.LogError($"{nameof(_upperCubeChecker)} is not set in {nameof(Stack)}. Object name: {gameObject.name}");
                return;
            }

            _gameEvents = GameEvents.Instance;

            if (_gameEvents == null)
            {
                Debug.LogError($"Instance for {nameof(GameEvents)} is not set. Object name: {gameObject.name}");
            }

            AddFirstCube();

            _jumpVector = new Vector3(0, _jumpHeight, 0);
        }

        private void AddFirstCube()
        {
            CubeStack cube = pool.Get();
            cube.transform.position = _upperCubeChecker.transform.position - cube.SizeCube;
            _countActiveCubes++;
        }

        public void AddCubeToStack()
        {
            if (_countActiveCubes < _maxCubesInStack)
            {
                CubeStack cube = pool.Get();
                if (_upperCubeChecker.UpperCube != null)
                {
                    PlaceNewCube(cube);
                    _gameEvents.pickUp.Invoke();
                }
                _countActiveCubes++;
            }
        }

        public void RemoveCubeFromStack(CubeStack cube)
        {
            pool.Release(cube);
            _countActiveCubes--;
            _gameEvents.wallCollision.Invoke();
            if (_countActiveCubes <= 0)
            {
                _gameEvents.endGame.Invoke();
                StopAllCoroutines();
                return;
            }
            
            StartCoroutine(DisableCubeObject(cube));
        }
        
        private void PlaceNewCube(CubeStack cube)
        {
            _upperCubeChecker.transform.position += cube.SizeCube + _jumpVector;
            cube.transform.position = _upperCubeChecker.UpperCube.position + cube.SizeCube;
        }

        private IEnumerator DisableCubeObject(CubeStack cube)
        {
            yield return new WaitForSeconds(_disableTime);
            cube.gameObject.SetActive(false);
        }
    }
}
