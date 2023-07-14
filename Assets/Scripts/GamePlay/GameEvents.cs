using UnityEngine;
using UnityEngine.Events;

namespace Runner.GamePlay
{
    public class GameEvents : MonoBehaviour
    {
        [Header("Collision Events")]
        public UnityEvent wallCollision;
        public UnityEvent pickUp;
        public UnityEvent endGame;
        public UnityEvent startGame;

        public static GameEvents Instance {get; private set;}

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"Object {nameof(GameEvents)} already created. Object name: {gameObject.name}");
                return;
            }

            Instance = this;
        }
        
        void Start()
        {
            CheckEventStatus(wallCollision);
            CheckEventStatus(pickUp);
            CheckEventStatus(endGame);
            CheckEventStatus(startGame);
        }

        private void CheckEventStatus(UnityEvent unityEvent)
        {
            if(unityEvent == null)
            {
                Debug.LogError($"Some events is empty in {nameof(GameEvents)}. Object name: {gameObject.name}");
            }
            else
            {
                int eventCount = unityEvent.GetPersistentEventCount();
                for (int i = 0; i < eventCount; i++)
                {
                    Object targetObject = unityEvent.GetPersistentTarget(i);
                    if (targetObject == null)
                    {
                        Debug.LogError($"Reference to the called method in UnityEvent is lost in {nameof(GameEvents)}. Object name: {nameof(gameObject.name)}");
                    }
                }
            }
        }
    }
}