using Scripts.Logic.Animation;
using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(CharacterAnimator))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private CharacterController _characterController;
        
        private void Update()
        {
            if (CanMove())
                _animator.Move(_characterController.velocity.magnitude);
            else
                _animator.StopMove();
        }

        private bool CanMove() => 
            _characterController.velocity.magnitude > Constants.Epsilon;
    }
}