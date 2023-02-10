using UnityEngine;

namespace Runner.Core
{
    public class PickUpNewCube : MonoBehaviour
    {
        StackCubes cubes;

        void Start()
        {
            cubes = FindObjectOfType<StackCubes>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "CubeStack")
            {
                cubes.AddNewCube();
                gameObject.SetActive(false);
            }
        }
    }
}
