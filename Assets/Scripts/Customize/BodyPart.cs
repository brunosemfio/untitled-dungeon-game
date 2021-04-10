using UnityEngine;
using UnityEngine.Events;

namespace Customize
{
    [CreateAssetMenu(menuName = "Customization/Body Part")]
    public class BodyPart : ScriptableObject
    {
        #region Public

        public string title;

        public int index;

        public GameObject[] options;

        #endregion

        #region Event

        public event UnityAction<GameObject> Change = delegate { };

        #endregion

        private void OnEnable()
        {
            index = 0;
        }

        public void Next()
        {
            if (++index >= options.Length) index = 0;

            Notify();
        }

        public void Prev()
        {
            if (--index < 0) index = options.Length - 1;

            Notify();
        }

        private void Notify()
        {
            if (options.Length > 0) Change(options[index % options.Length]);
        }
    }
}