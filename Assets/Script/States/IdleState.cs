
using UnityEngine;
namespace Enemy
{
    public class IdleState : State
    {
        // constructor
        public IdleState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
        {
        }

        public override void Enter()
        {
            enemy.rb.velocity = new Vector2(enemy.rb.velocity.x * 0.2f, enemy.rb.velocity.y);
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            enemy.CheckForRun();
            Debug.Log("checking for run");
            base.LogicUpdate();

            enemy.navmeshAgent.speed = 5f;
            enemy.navmeshAgent.SetDestination(enemy.player.position);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}