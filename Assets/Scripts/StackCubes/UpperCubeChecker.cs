using UnityEngine;

namespace Runner.StackCubes
{
    public class UpperCubeChecker : MonoBehaviour
    {
        private Transform _upperCube;
        public Transform UpperCube => _upperCube;

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.tag == "CubeStack")
            {
                _upperCube = other.transform;
            }
        }
    }
}