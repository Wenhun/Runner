using UnityEngine;

namespace Runner.Core
{
    public class StayInColumn : MonoBehaviour
    {
        bool inColumn = true;

        public bool InColumn
        {
            get => inColumn;
            set => inColumn = false;
        }

        void OnEnable()
        {
            inColumn = true;
        }

        void Update()
        {
            if (inColumn) transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
        }
    }
}
