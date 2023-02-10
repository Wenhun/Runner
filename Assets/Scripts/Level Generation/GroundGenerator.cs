using UnityEngine;

namespace Runner.LevelGeneration
{
    public class GroundGenerator : MonoBehaviour
    {
        [SerializeField] Transform start;
        [SerializeField] Transform end;
        [SerializeField] GameObject[] walls;
        [SerializeField] PickUpCubeGenerator[] pickUpCubes;

        public Vector3 EndPosition { get { return end.position; } }

        public void GenerateGround(Vector3 newPosition)
        {
            transform.position = newPosition - start.localPosition;
            PlaceWall();
            PlaceCubes();
        }

        void PlaceCubes()
        {
            foreach (PickUpCubeGenerator pickUpCube in pickUpCubes)
            {
                pickUpCube.RandomPosition();
            }
        }

        void PlaceWall()
        {
            foreach (GameObject wall in walls)
            {
                wall.SetActive(false);
            }
            int index = Random.Range(0, walls.Length);
            walls[index].SetActive(true);
        }
    }
}
