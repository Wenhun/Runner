using UnityEngine;

namespace Runner.LevelGeneration
{
    public class NewGroundTrigger : MonoBehaviour
    {
        GroundPlacer groundPlacer;

        void Start()
        {
            groundPlacer = FindObjectOfType<GroundPlacer>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                groundPlacer.NewGround();
            }
        }
    }
}
