using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class Controller : MonoBehaviour
    {
        public State currentState;  //Apuntadosr al estado actual
        public State remainState;


        public bool ActiveAI { get; set; }

        void Start()
        {
            ActiveAI = true;  //Para activar AI
        }
        private Animator _animatorController;
        private HealthSystem _healthSystem;


        private void Awake()
        {
            _animatorController = GetComponent<Animator>();
            _healthSystem = GetComponent<HealthSystem>();
        }

        void Update()
        {
            if (!ActiveAI)
            {
                return;
            }

            currentState.UpdateState(this);
        }

        public void Transition(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
            }
        }

        public void SetAnimation(string animation, bool value)
        {
            _animatorController.SetBool(animation, value);
        }

        public int GetCurrentHealth()
        {
            return _healthSystem.ReturnHealth();
        }
    }
}