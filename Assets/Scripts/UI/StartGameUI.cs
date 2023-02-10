using UnityEngine;
using UnityEngine.Events;

namespace Runner.UI
{
    public class StartGameUI : MonoBehaviour
    {
        [SerializeField] UnityEvent startGame;
        
        bool gameStarted = false;

        void Update()
        {
            if (!gameStarted)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    gameStarted = true;
                    startGame.Invoke();
                }
            }
        }
    }
}
