using UnityEngine;

namespace Core.Scripts.Player
{
    public class MovementPlayer : Player
    {
        [SerializeField] private float _speedRotateToObject;

        //private GameManager _gameManager;
        private Vector3 _rotationEuler;

        private void Start()
        {
        //    _gameManager = GameManager.instance;
        }

        private void Update()
        {
            // if (_gameManager.statusGame == StatusGame.MoveCamera)
            // {
            //     RotateToObject();
            //     return;
            // }
        }

        private void RotateToObject()
        {
            Vector3 targetDirection = new Vector3();// _gameManager.figureBox.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _speedRotateToObject);
        }

        private void JoystickRotate()
        {
            float vertical = 0;
            float horizontal = 0;

            _rotationEuler.x = transform.eulerAngles.x;
            _rotationEuler.y = transform.eulerAngles.y;

            _rotationEuler.x += vertical;
            _rotationEuler.y += horizontal;

            transform.rotation = Quaternion.Euler(_rotationEuler);
        }

        private void MouseRotate()
        {
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                Vector3 currentRotation = transform.rotation.eulerAngles;
                currentRotation.z = 0f;

                Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * _speed;
                transform.rotation = Quaternion.Euler(currentRotation) * Quaternion.Euler(rotation);
            }
        }
    }
}