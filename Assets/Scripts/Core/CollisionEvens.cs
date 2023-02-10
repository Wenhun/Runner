using UnityEngine;
using UnityEngine.Events;

namespace Runner.Core
{
    public class CollisionEvens : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] GameObject player;
        [SerializeField] GameObject collectText;
        [SerializeField] StackCubes stackCubes;

        [Header("Collision Events")]
        public UnityEvent wallCollision;
        public UnityEvent pickUp;
        public UnityEvent endGame;

        public void ShowText()
        {
            collectText.transform.position = player.transform.position;
        }

        void Update()
        {
            if (stackCubes.CountActiveCube <= 0)
            {
                endGame.Invoke();
            }
        }
    }
}