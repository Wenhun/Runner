using Runner.StackCubes;
using UnityEngine;

namespace Runner.GamePlay
{
    public class PickupTrigger : MonoBehaviour
    {
        private Stack _stack;

        void Start()
        {
            _stack = Stack.Instance;

            if (_stack == null)
            {
                Debug.LogError($"Instance for {nameof(Stack)} is not set. Object name: {gameObject.name}");
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "CubeStack")
            {
                _stack.AddCubeToStack();
                gameObject.SetActive(false);
            }
        }
    }
}
