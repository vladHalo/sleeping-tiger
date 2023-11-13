using UnityEngine;

namespace Core.Scripts.Bird
{
    public class MoveBird : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _height;
        [SerializeField] private float _timeDamage;
        private float _time;
        private Transform _firstPoint, _lastPoint;

        private float _radius = 1.5f;
        private float _angle;

        private GameManager _gameManager;

        private void Update()
        {
            if (_time >= .9f)
            {
                CircleMove();
                return;
            }

            BezierMove();
        }

        public void SetPointMove(Transform firstPoint, Transform lastPoint, GameManager gameManager)
        {
            _firstPoint = firstPoint;
            _lastPoint = lastPoint;
            transform.position = firstPoint.position;
            _time = 0;
            _gameManager = gameManager;
        }

        private void BezierMove()
        {
            transform.position = Bezier.GetPoint(
                _firstPoint.position,
                new Vector3(_firstPoint.position.x, _firstPoint.position.y,
                    _firstPoint.position.z),
                new Vector3(_lastPoint.position.x + _height.x, _lastPoint.position.y + _height.y,
                    _lastPoint.position.z),
                _lastPoint.position, _time);

            _time = Mathf.Lerp(_time, 1f, _speed * Time.deltaTime);
            if (_time < _timeDamage) return;

            if (_gameManager != null)
            {
                _gameManager.tigerStateManager.sleepState.StartGetDamage();
                _gameManager = null;
            }
        }

        private void CircleMove()
        {
            float x = Mathf.Cos(_angle) * _radius;

            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            _angle += _speed * Time.deltaTime;

            if (_angle >= 2 * Mathf.PI)
            {
                _angle = 0f;
            }
        }
    }
}