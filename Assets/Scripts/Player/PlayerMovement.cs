using Scripts.Services.Input;
using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 0.5f;
        [SerializeField] private CharacterController _characterController;
        
        private IInputService _inputService;
        private Camera _camera;

        public void Init(IInputService inputService)
        {
            _inputService = inputService;
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_inputService == null)
            {
                return;
            }
            
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }
    }
}