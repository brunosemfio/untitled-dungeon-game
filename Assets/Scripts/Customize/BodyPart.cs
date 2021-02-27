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

        public event UnityAction<GameObject> ChangeEvent = delegate { };

        #endregion

        private void OnEnable()
        {
            index = 0;
        }

        public void Next()
        {
            if (++index >= options.Length) index = 0;

            Change();
        }

        public void Prev()
        {
            if (--index < 0) index = options.Length - 1;

            Change();
        }

        private void Change()
        {
            if (options.Length > 0) ChangeEvent(options[index]);
        }
    }
}