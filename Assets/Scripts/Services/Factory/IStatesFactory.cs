using System;
using System.Collections.Generic;
using Scripts.Infrastructure.StateMachine;

namespace Scripts.Services.Factory
{
    public interface IStatesFactory
    {
        Dictionary<Type, IState> CreateStates();
    }
}