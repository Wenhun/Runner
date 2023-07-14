using UnityEngine;

namespace Runner.Control
{
    public class PlayerMover : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(4, 10)] private float _speed = 4f;
        
        private bool _isAlive = false;

        public bool isAlive
        {
            get => _isAlive;
            set => _isAlive = value;
        }

        private void Update()
        {
            if (_isAlive)
            {
                gameObject.transform.Translate(0, 0, Time.deltaTime * _speed);
            }
        }
    }
}