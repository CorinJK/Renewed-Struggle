using Scripts.Services.Camera;
using Scripts.Services.Input;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 0.5f;
        [SerializeField] private CharacterController _characterController;
        
        [Inject] private IInputService _inputService;
        
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            CameraFollow();
        }
        
        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = Camera.main.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }
        
        private void CameraFollow () => 
            _camera.GetComponent<CameraFollow>().Follow(gameObject);
    }
}