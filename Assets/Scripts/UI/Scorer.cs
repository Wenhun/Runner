using UnityEngine;
using TMPro;
 
namespace Runner.UI
{
    public class Scorer : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private TMP_Text _scoreText;

        private int _score = 0;
        private float _startPointCorrection;

        private void Start()
        {
            if (_player == null || _scoreText == null)
            {
                Debug.LogError($"Some serializable fields is not set in {nameof(Scorer)}. Object name: {nameof(gameObject.name)}");
            }

            _startPointCorrection = _player.position.z;
        }

        private void LateUpdate()
        {
            _score = (int)(_player.position.z - _startPointCorrection);
            _scoreText.text = _score.ToString();
        }
    }
}