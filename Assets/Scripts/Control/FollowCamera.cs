using UnityEngine;

namespace Runner.Control
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform player;
        float cameraDistance;

        void Awake()
        {
            cameraDistance = player.position.z - transform.position.z;
        }

        void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z - cameraDistance);
        }
    }
}
