using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Control
{
    public class ShakeCamera : MonoBehaviour
    {
        [SerializeField] float duration = 0.5f;
        [SerializeField] float magnitude = 2f;

        Vector3 originalPosition;
        float elapsed = 0;

        void Start()
        {
            originalPosition = transform.position;
        }

        public void CameraShake()
        {
            StartCoroutine(Shake());
            Handheld.Vibrate();
        }

        IEnumerator Shake()
        {
            if (elapsed == 0)
                while (elapsed < duration)
                {
                    float x = Random.Range(-1f, 1f) * magnitude;
                    float y = Random.Range(-1f, 1f) * magnitude;

                    transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
                    elapsed += Time.deltaTime;
                    yield return null;
                }
            elapsed = 0;
            transform.position = originalPosition;
        }
    }
}
