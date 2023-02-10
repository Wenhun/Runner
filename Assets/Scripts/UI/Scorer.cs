using UnityEngine;
using TMPro;
 
namespace Runner.UI
{
    public class Scorer : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] TMP_Text scoreText;

        int score = 0;
        float startPointCorrection;

        void Start()
        {
            startPointCorrection = player.position.z;
        }

        void LateUpdate()
        {
            score = (int)(player.position.z - startPointCorrection);
            scoreText.text = score.ToString();
        }
    }
}