using System;
using System.Collections.Generic;
using Scripts.Services.Factory;
using Zenject;

namespace Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine
    {
        private readonly IStatesFactory _statesFactory;
        private Dictionary<Type, IState> _states;
        private IState _currentState;

        [Inject]
        public GameStateMachine(IStatesFactory statesFactory) => 
            _statesFactory = statesFactory;

        public void CreateStates()
        {
            Dictionary<Type, IState> states = _statesFactory.CreateStates();
            _states = states;
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = SwitchState<TState>();
            state.Enter();
        }

        private TState SwitchState<TState>() where TState : class, IState
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IState => 
            _states[typeof(TState)] as TState;
    }
}