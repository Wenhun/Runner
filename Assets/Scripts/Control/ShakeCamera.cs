using System.Collections;
using UnityEngine;

namespace Runner.Control
{
    public class ShakeCamera : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(0.1f, 0.5f)] private float _duration = 0.1f;
        [SerializeField, Range(0.1f, 1f)] private float _magnitude = 0.1f;

        private Vector3 _originalPosition;
        private float _elapsed = 0;

        static public bool IsAlreadyShaken{get; set;}

        private void Start()
        {
            IsAlreadyShaken = false;
            _originalPosition = transform.position;
        }

        public void CameraShake()
        {
            if(!IsAlreadyShaken)
            {
                IsAlreadyShaken = true;
                StartCoroutine(Shake());
                Handheld.Vibrate();
            }
        }

        private IEnumerator Shake()
        {
            if (_elapsed == 0)
                while (_elapsed < _duration)
                {
                    float x = Random.Range(-1f, 1f) * _magnitude;
                    float y = Random.Range(-1f, 1f) * _magnitude;

                    transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
                    _elapsed += Time.deltaTime;
                    yield return null;
                }
            _elapsed = 0;
            transform.position = _originalPosition;
        }
    }
}
