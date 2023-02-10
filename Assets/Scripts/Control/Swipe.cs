using UnityEngine;

namespace Runner.Control
{
    public class Swipe : MonoBehaviour
    {
        [SerializeField] float swipeSpeed = 2f;
        [SerializeField] float trackSize = 2f;

        PlayerMover player;
        Touch touch;

        void Start()
        {
            player = GetComponent<PlayerMover>();
        }

        void Update()
        {
            if (Input.touchCount > 0 && player.IsAlive)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        Mathf.Clamp((transform.position.x + touch.deltaPosition.x * swipeSpeed), -trackSize, trackSize),
                        transform.position.y,
                        transform.position.z);
                }
            }
        }
    }
}
