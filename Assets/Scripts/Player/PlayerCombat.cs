using UnityEngine;

namespace Player
{
    public class PlayerCombat : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private int maxEnemies;

        [SerializeField] private float attackRadius;
        
        [SerializeField] private Transform attackRoot;

        [SerializeField] private LayerMask enemyLayer;

        #endregion

        #region Private

        private Collider[] _result;

        #endregion

        private void Awake()
        {
            _result = new Collider[maxEnemies];
        }

        public void CheckAttackCollision()
        {
            var num = Physics.OverlapSphereNonAlloc(attackRoot.position, attackRadius, _result, enemyLayer);

            for (var i = 0; i < num; i++)
            {
                Debug.Log(_result[i]);
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