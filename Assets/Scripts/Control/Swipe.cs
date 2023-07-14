using UnityEngine;

namespace Runner.Control
{
    [RequireComponent(typeof(PlayerMover))]
    public class Swipe : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(0.01f, 1)] private float _swipeSpeed = 0.01f;
        [SerializeField, Range(2, 3)] private float _trackSize = 2f;

        private PlayerMover _player;
        private Touch _touch;

        private void Start()
        {
            _player = GetComponent<PlayerMover>();
        }

        private void Update()
        {
            if (Input.touchCount > 0 && _player.isAlive)
            {
                _touch = Input.GetTouch(0);

                if (_touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        Mathf.Clamp((transform.position.x + _touch.deltaPosition.x * _swipeSpeed), -_trackSize, _trackSize),
                        transform.position.y,
                        transform.position.z);
                }
            }
        }
    }
}
