﻿using UnityEngine;

namespace StateMachines
{
    public class EHState : ScriptableObject
    {
        
        private AnimationClip ClipToPlay;
        public int AnimationHash { get; private set; }
        
        
        // Called when we enter a new state
        public virtual void OnStateEnter()
        {
            
        }
        
        // Called when we exit this state
        public virtual void OnStateExit()
        {
            
        }

        // This will be called every frame to update our state
        public virtual void OnStateTick()
        {
            
        }
    }
    
    
    
    public class EHStateMachine : EHActorComponent
    {
        private EHState CurrentState;
        private Animator ActorAnimator;

        protected override void Awake()
        {
            base.Awake();
            IsTicking = true;
            ActorAnimator = GetComponent<Animator>();
        }

        public override void Tick()
        {
            base.Tick();
            CurrentState.OnStateTick();
        }

        public void StartState(EHState State)
        {
            if (State == null || State == CurrentState)
            {
                return;
            }
            if (CurrentState != null)
            {
                CurrentState.OnStateExit();
            }
            CurrentState = State;
            CurrentState.OnStateEnter();
            if (CurrentState.ClipToPlay != null)
            {
                ActorAnimator.Play();
            }
        }
    }
}