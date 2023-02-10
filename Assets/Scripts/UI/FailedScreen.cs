using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.UI
{
    public class FailedScreen : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
