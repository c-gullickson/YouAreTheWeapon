using System.Collections.Generic;
using Constants;
using Enemy.Controller;
using Models.Interfaces;
using UnityEngine;
using Random = System.Random;

namespace Enemy.State.AttackStates
{
    public class EnemyBombAttackState: EnemyAttackState
    {
        private Random _random = new Random();
        private float _countdownExplositionTimer = 0f;
        public EnemyBombAttackState(EnemyController enemyController) : base(enemyController)
        {
            
        }

        public override void Enter()
        {
            // Start the countdown for when the unit may explode
            Debug.Log("Enter Enemy Bomb Attack State");
            _countdownExplositionTimer = _random.Next(1, 4);
        }

        public override void Update()
        {
            _countdownExplositionTimer -= Time.deltaTime;

            if (_countdownExplositionTimer <= 0)
            {
                Collider[] explositionColliders = Physics.OverlapSphere(_enemyController.transform.position, 60f, LayerMask.GetMask("Player"));
                foreach (var collision in explositionColliders)
                {
                    var collisionObject = collision.gameObject.GetComponentInParent<IDamagable>();
                    var damage = _enemyController.EnemyConfiguration.AttackDamage * -1;
                    collisionObject?.Damage(_enemyController.EnemyConfiguration.AttackDamageType, damage);
                }
                
                _enemyController.DestroyEnemy();
            }
            
        }

        public override void Exit()
        {
            Debug.Log("Exit Enemy Attack State");
        }
    }
}