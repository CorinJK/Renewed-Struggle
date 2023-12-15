using System;
using System.Collections.Generic;
using Scripts.Infrastructure.StateMachine;
using Scripts.Tools;
using Zenject;

namespace Scripts.Services.Factory
{
    public class StatesFactory : IStatesFactory
    {
        private readonly DiContainer _container;

        [Inject]
        public StatesFactory(DiContainer diContainer)
        {
            _container = diContainer;
        }

        public Dictionary<Type, IState> CreateStates()
        {
            return new Dictionary<Type, IState>()
            {
                { typeof(BootstrapState), BindState(new BootstrapState()) },
                { typeof(LoadLevelState), BindState(new LoadLevelState()) },
            };
        }

        private IState BindState<T>(T state) where T : class, IState
        {
            return state.With(_ => _container.BindInstance(state).AsSingle())
                .With(_ => _container.Inject(state));
        }
    }
}