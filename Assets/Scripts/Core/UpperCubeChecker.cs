using UnityEngine;

namespace Runner.Core
{
    public class UpperCubeChecker : MonoBehaviour
    {
        GameObject upperCube;

        void OnCollisionStay(Collision other)
        {
            if (other.gameObject.tag == "CubeStack")
            {
                upperCube = other.gameObject;
            }
        }

        public CubeSizer UpperCube
        {
            get
            {
                if (upperCube != null)
                    return upperCube.GetComponent<CubeSizer>();
                else
                    return null;
            }
        }
    }
}