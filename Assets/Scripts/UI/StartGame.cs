using UnityEngine;
using Runner.GamePlay;

namespace Runner.UI
{
    public class StartGame : MonoBehaviour
    {
        private GameEvents _gameEvents;
        private bool _gameStarted = false;

        private void Start()
        {
            _gameEvents = GameEvents.Instance;

            if (_gameEvents == null)
            {
                Debug.LogError($"Instance {nameof(StartGame)} is not set. Object name: {gameObject.name}");
            }
        }

        private void Update()
        {
            if (!_gameStarted)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    _gameStarted = true;
                    _gameEvents.startGame.Invoke();
                }
            }
        }
    }
}
