using Runner.StackCubes;
using UnityEngine;

namespace Runner.GamePlay
{
    public class WallCollision : MonoBehaviour
    {
        private bool _onCollision = false;
        private GameEvents _gameEvents;
        private Stack _stack;

        private void OnEnable()
        {
            _onCollision = false;
        }

        private void Start()
        {
            _gameEvents = GameEvents.Instance;
            _stack = Stack.Instance;

            if(_gameEvents == null || _stack == null)
            {
                Debug.LogError($"Some instances {nameof(GameEvents)} is not set. Object name: {gameObject.name}");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_onCollision) return;

            if (other.tag == "Player")
            {
                _onCollision = true;
                _gameEvents.endGame.Invoke();
                return;
            }

            if (other.tag == "CubeStack")
            {
                _onCollision = true;
                StayInColumn cubeCollision = other.GetComponent<StayInColumn>();
                if (cubeCollision != null)
                {
                    if (cubeCollision.InColumn)
                    {
                        cubeCollision.InColumn = false;
                        CubeStack cubeStack = other.GetComponent<CubeStack>();
                        if (cubeStack != null)
                        {
                            _stack.RemoveCubeFromStack(cubeStack);
                        }
                        else
                        {
                            Debug.LogError($"Trigger don't work! Component {nameof(CubeStack)} not found. Object name: {gameObject.name}");
                        }
                    }
                }
                else
                {
                    Debug.LogError($"Trigger don't work! Component {nameof(StayInColumn)} not found. Object name: {gameObject.name}");
                }
            }
        }
    }
}
