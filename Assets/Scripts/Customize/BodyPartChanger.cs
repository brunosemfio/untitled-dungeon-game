using DG.Tweening;
using UnityEngine;

namespace Customize
{
    public class BodyPartChanger : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private BodyPart bodyPart;

        #endregion

        private void OnEnable()
        {
            bodyPart.ChangeEvent += ChangeEvent;
        }

        private void OnDisable()
        {
            bodyPart.ChangeEvent -= ChangeEvent;
        }

        private void ChangeEvent(GameObject obj)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            if (!obj) return;

            Instantiate(obj, transform);

            DOTween.To(() => transform.localScale / 1.1f, 
                value => transform.localScale = value,
                Vector3.one, .25f).SetEase(Ease.OutBack);
        }
    }
}