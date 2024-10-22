using Enemy;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.VFX;

namespace Enemy
{


    public class EnemyScript : MonoBehaviour
    {
        public Rigidbody rb;
        public SpriteRenderer sr;
        Animation anim;

        public GameObject pointA;
        public GameObject pointB;

        public NavMeshAgent navmeshAgent;
           
        public Transform player;

        float distance;

        bool isGrounded;

        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;

        public StateMachine sm;

        public GameObject model;



        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            sm = gameObject.AddComponent<StateMachine>();
            sr = GetComponent<SpriteRenderer>();
            anim = model.GetComponent<Animation>();

            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);
           
            // initialise the statemachine with the default state
            sm.Init(idleState);

            anim.Play();
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            distance = Vector3.Distance(pointA.transform.position, pointB.transform.position);
        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }


        public void CheckForRun()
        {
            if (distance < 10)
            {
                sm.ChangeState(runningState);
            }
        }


        public void CheckForIdle()
        {
            if (distance > 10)
            {
                sm.ChangeState(idleState);
            }
        }
    }
}