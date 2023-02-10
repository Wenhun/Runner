using UnityEngine;

namespace Runner.Core
{
    public class WallCollision : MonoBehaviour
    {
        StackCubes stackCubes;

        bool onCollision = false;

        void Start()
        {
            stackCubes = FindObjectOfType<StackCubes>();
        }

        void OnEnable()
        {
            onCollision = false;
        }

        void OnTriggerEnter(Collider other)
        {
            if (onCollision) return;

            if (other.tag == "Player")
            {
                onCollision = true;
                FindObjectOfType<CollisionEvens>().endGame.Invoke();
                return;
            }

            if (other.tag == "CubeStack")
            {
                onCollision = true;
                StayInColumn cubeCollision = other.GetComponent<StayInColumn>();
                if (cubeCollision.InColumn)
                {
                    cubeCollision.InColumn = false;
                    stackCubes.RemoveCube(other.gameObject);
                }
            }
        }
    }
}
