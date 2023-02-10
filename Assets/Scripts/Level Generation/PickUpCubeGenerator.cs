using UnityEngine;

namespace Runner.LevelGeneration
{
    public class PickUpCubeGenerator : MonoBehaviour
    {
        [Header("List Random Positions")]
        [SerializeField, Range(-1f, 1f)] float[] positionX;

        public void RandomPosition()
        {
            gameObject.SetActive(true);
            int index = Random.Range(0, positionX.Length);
            transform.localPosition = new Vector3(positionX[index],
                transform.localPosition.y,
                transform.localPosition.z);
        }
    }
}
