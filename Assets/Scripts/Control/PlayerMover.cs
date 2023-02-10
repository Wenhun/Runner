using UnityEngine;

namespace Runner.Control
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] float speed = 3f;
        bool isAlive = false;

        public bool IsAlive
        {
            get => isAlive;
            set => isAlive = value;
        }

        void Update()
        {
            if (isAlive)
            {
                gameObject.transform.Translate(0, 0, Time.deltaTime * speed);
            }
        }
    }
}