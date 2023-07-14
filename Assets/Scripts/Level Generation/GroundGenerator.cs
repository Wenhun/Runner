using UnityEngine;

namespace Runner.LevelGeneration
{
    public class GroundGenerator : MonoBehaviour
    {
        [Header("Ground boundaries")]
        [Tooltip("Boundaries are needed to place the ground indefinitely. They must be placed at the beginning and at the end of the ground.")]
        [SerializeField] private Transform _startBoundary;
        [Tooltip("Boundaries are needed to place the ground indefinitely. They must be placed at the beginning and at the end of the ground.")]
        [SerializeField] private Transform _endBoundary;
        [Header("Prefabs for create unique ground")]
        [SerializeField] private Transform[] _pickupCubesContainer;
        [SerializeField] private GameObject[] _walls;

        public Vector3 EndPosition {get => _endBoundary.position;}

        private void Start()
        {
            if (_startBoundary == null || _endBoundary == null || _walls == null || _pickupCubesContainer == null)
            {
                Debug.LogError($"Some serializable objects is not set in {nameof(GroundGenerator)}. Object name: {gameObject.name}");
                return;
            }
        }
        
        public void GenerateGround(Vector3 newPosition)
        {
            transform.position = newPosition - _startBoundary.localPosition;
            PlaceWall();
            PlaceCubes();
        }

        private void PlaceCubes()
        {
            foreach(Transform container in _pickupCubesContainer)
            {
                container.gameObject.SetActive(false);
            }

            int randomIndex = Random.Range(0, _pickupCubesContainer.Length);
            _pickupCubesContainer[randomIndex].gameObject.SetActive(true);

            foreach (Transform child in _pickupCubesContainer[randomIndex])
            {
                child.GetComponent<PickupCubePlacer>().RandomPosition();
            }
        }

        private void PlaceWall()
        {
            foreach (GameObject wall in _walls)
            {
                wall.SetActive(false);
            }
            int index = Random.Range(0, _walls.Length);
            _walls[index].SetActive(true);
        }
    }
}
