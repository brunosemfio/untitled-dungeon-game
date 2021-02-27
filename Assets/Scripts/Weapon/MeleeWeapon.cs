using Audio;
using Character.Player;
using Damage;
using UnityEngine;

namespace Weapon
{
    public class MeleeWeapon : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private int maxEnemies;

        [SerializeField] private float attackRadius;

        [SerializeField] private Transform attackRoot;

        [SerializeField] private LayerMask targetLayer;

        [SerializeField] private RandomAudioPlayer attackAudio;

        [SerializeField] private RandomAudioPlayer hitAudio;

        #endregion

        #region Private

        private Collider[] _result;

        #endregion

        private void Awake()
        {
            _result = new Collider[maxEnemies];

            Register();
        }

        private void Register()
        {
            GetComponentInParent<PlayerController>().SetWeapon(this);
        }

        public void StartAttack()
        {
            attackAudio.PlayRandomClip();
        }

        public void CheckCollision()
        {
            var num = Physics.OverlapSphereNonAlloc(attackRoot.position, attackRadius, _result, targetLayer);

            for (var i = 0; i < num; i++)
            {
                if (_result[i].TryGetComponent(out Damageable damageable))
                {
                    hitAudio.PlayRandomClip();
                    
                    damageable.ApplyDamage(1);
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawSphere(attackRoot.position, attackRadius);
        }
#endif
    }
}