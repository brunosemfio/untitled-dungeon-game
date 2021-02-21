using UnityEngine;
using UnityEngine.Events;

namespace Damage
{
    public class Damageable : MonoBehaviour
    {
        #region Public

        public int CurrentHitPoints { get; private set; }

        #endregion

        #region Inspector

        [SerializeField] private int maxHitPoints;

        [SerializeField] private float invulnerabilityTime;

        [Space] [SerializeField] private UnityEvent onReceiveDamage, onDeath;

        #endregion

        #region Private

        private bool _isInvulnerable;

        private float _timeSinceLastHit;

        #endregion

        private void Awake()
        {
            CurrentHitPoints = maxHitPoints;
        }

        private void Update()
        {
            UpdateInvulnerability();
        }

        private void UpdateInvulnerability()
        {
            if (!_isInvulnerable) return;

            _timeSinceLastHit += Time.deltaTime;

            if (_timeSinceLastHit >= invulnerabilityTime)
            {
                _timeSinceLastHit = 0f;

                _isInvulnerable = false;
            }
        }

        public void ApplyDamage(int value)
        {
            if (CurrentHitPoints <= 0 || _isInvulnerable) return;

            CurrentHitPoints -= value;

            if (CurrentHitPoints > 0)
            {
                _isInvulnerable = true;

                onReceiveDamage.Invoke();

                return;
            }

            onDeath.Invoke();
        }
    }
}