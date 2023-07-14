using UnityEngine;

namespace Runner.Control
{
    public class FollowCamera : MonoBehaviour
    {
        [Header("Object to Follow")]
        [SerializeField] private Transform _playerTransform;
        
        private float _cameraDistance;

        private void Start()
        {
            if (_playerTransform == null)
            {
                Debug.LogError($"Field {nameof(_playerTransform)} is not set in {nameof(FollowCamera)}. Object name: {gameObject.name}");
            }

            _cameraDistance = _playerTransform.position.z - transform.position.z;
        }

        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _playerTransform.position.z - _cameraDistance);
        }
    }
}
