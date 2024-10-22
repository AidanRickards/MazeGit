
using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Enemy
{
    public class RunningState : State
    {
        private float _horizontalInput;

        public Rigidbody2D rigidbody;
        Vector2 move;
        public float speed = 5;

        // constructor
        public RunningState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
        {
        }

        public override void Enter()
        {
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
            base.LogicUpdate();
            enemy.CheckForIdle();
            Debug.Log("checking for idle");

            enemy.navmeshAgent.speed = 3.5f;
            enemy.navmeshAgent.SetDestination(enemy.player.position);
        }

        public override void PhysicsUpdate()
        {

        }
    }
}