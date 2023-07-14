using UnityEngine;
using Runner.Control;

namespace Runner.LevelGeneration
{
    public class NewGroundTrigger : MonoBehaviour
    {
        private GroundPlacer _groundPlacer;

        void Start()
        {
            _groundPlacer = GroundPlacer.Instance;

            if (_groundPlacer == null)
            {
                Debug.LogError($"Some instances in {nameof(GroundPlacer)} is not set. Object name: {gameObject.name}");
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                _groundPlacer.PlaceGround();
                ShakeCamera.IsAlreadyShaken = false;
            }
        }
    }
}
