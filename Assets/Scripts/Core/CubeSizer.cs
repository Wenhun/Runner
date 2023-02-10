using UnityEngine;

namespace Runner.Core
{
    public class CubeSizer : MonoBehaviour
    {
        [SerializeField] Transform top;
        [SerializeField] Transform bottom;

        public Vector3 SizeCube { get => top.position - bottom.position; }
        public Vector3 TopCube { get => top.position; }
    }
}