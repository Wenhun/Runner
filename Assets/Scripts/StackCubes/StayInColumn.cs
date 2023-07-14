using UnityEngine;

namespace Runner.StackCubes
{
    public class StayInColumn : MonoBehaviour
    {
        private bool _inColumn = true;

        public bool InColumn
        {
            get => _inColumn;
            set => _inColumn = false;
        }

        private void OnEnable()
        {
            _inColumn = true;
        }

        private void Update()
        {
            if (_inColumn) transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
        }
    }
}
