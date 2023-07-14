using UnityEngine;

namespace Runner.LevelGeneration
{
    public class PickupCubePlacer : MonoBehaviour
    {
        [Header("List Random Positions")]
        [Tooltip("List of all possible positions in which the cube can be placed.")]
        [SerializeField, Range(-1f, 1f)] private float[] _positionX;

        public void RandomPosition()
        {
            gameObject.SetActive(true);
            int index = Random.Range(0, _positionX.Length);
            transform.localPosition = new Vector3(_positionX[index], transform.localPosition.y, transform.localPosition.z);
        }
    }
}
