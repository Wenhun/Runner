using UnityEngine;

namespace Runner.UI
{
    public class CollectTextPlacer : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private Transform _player;

        private void Start()
        {
            if (_player == null)
            {
                Debug.LogError($"Field {nameof(_player)} is not set in {nameof(CollectTextPlacer)}. Object name: {nameof(gameObject.name)}");
            }
        }

        public void ShowText()
        {
            transform.position = _player.position;
        }
    }
}