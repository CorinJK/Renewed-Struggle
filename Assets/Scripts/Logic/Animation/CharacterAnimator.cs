using System;
using UnityEngine;

namespace Scripts.Logic.Animation
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimator : MonoBehaviour, IAnimationStateReader
    {
        private static readonly int HitHash = Animator.StringToHash("Hit");
        private static readonly int DieHash = Animator.StringToHash("Die");
        private static readonly int IsMovement = Animator.StringToHash("IsMovement");
        private static readonly int Speed = Animator.StringToHash("Speed");
        
        private static readonly int AttackHash = Animator.StringToHash("Attack_1");
        private static readonly int Attack2Hash = Animator.StringToHash("Attack_2");
        private static readonly int Attack3Hash = Animator.StringToHash("Attack_3");
        private static readonly int Attack4Hash = Animator.StringToHash("Attack_4");

        private readonly int _attackStateHash = Animator.StringToHash("Attack");
        private readonly int _walkingStateHash = Animator.StringToHash("Movement");
        private readonly int _deathStateHash = Animator.StringToHash("Die");

        [SerializeField] private Animator _animator;
        
        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;

        public AnimatorState State { get; private set; }

        public bool IsAttacking => State == AnimatorState.Attack;

        public void Move(float speed)
        {
            _animator.SetBool(IsMovement, true);
            _animator.SetFloat(Speed, speed);
        }
        
        public void StopMove() => _animator.SetBool(IsMovement, false);
        
        public void PlayHit() => _animator.SetTrigger(HitHash);
        
        public void PlayDeath() => _animator.SetTrigger(DieHash);

        public void PlayAttack() => _animator.SetTrigger(AttackHash);
        public void PlayAttack2() => _animator.SetTrigger(Attack2Hash);
        public void PlayAttack3() => _animator.SetTrigger(Attack3Hash);
        public void PlayAttack4() => _animator.SetTrigger(Attack4Hash);

        public void EnteredState(int stateHash)
        {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int stateHash) =>
          StateExited?.Invoke(StateFor(stateHash));

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            if (stateHash == _attackStateHash)
                state = AnimatorState.Attack;
            else if (stateHash == _walkingStateHash)
                state = AnimatorState.Move;
            else if (stateHash == _deathStateHash)
                state = AnimatorState.Died;
            else
                state = AnimatorState.Unknown;

            return state;
        }
    }
}