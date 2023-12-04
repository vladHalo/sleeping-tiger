using System.Collections;
using UnityEngine;

namespace Core.Scripts.Bird
{
    public class MoveAnimal : MonoBehaviour
    {
        public float time;
        public ParticleSystem _particle;
        
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _height;
        [SerializeField] private float _timeDamage;
        private Transform _firstPoint, _lastPoint;
        private bool _isFinish;

        private float _centerLineX;

        private GameManager _gameManager;

        private void Update()
        {
            if (time >= .9f)
            {
                LineMove();
                return;
            }

            BezierMove();
        }

        private void OnDestroy()
        {
            StopCoroutine(SetDamage());
        }

        public void SetPointMove(Transform firstPoint, Transform lastPoint, GameManager gameManager)
        {
            _firstPoint = firstPoint;
            _lastPoint = lastPoint;
            transform.position = firstPoint.position;
            time = 0;
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
                _lastPoint.position, time);

            time = Mathf.Lerp(time, 1f, _speed * Time.deltaTime);
            if (time < _timeDamage) return;

            if (_isFinish == false)
            {
                StartCoroutine(SetDamage());
                _particle.gameObject.SetActive(true);
                _particle.Play();
                _isFinish = true;
            }

            _centerLineX = transform.position.x;
        }

        private void LineMove()
        {
            Vector3 currentPosition = transform.position;

            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x + _speed * Time.deltaTime, pos.y, pos.z);
            if (transform.position.x > _centerLineX + 1.5f)
            {
                currentPosition.x = -1.5f;
            }

            transform.position = currentPosition;
        }

        private IEnumerator SetDamage()
        {
            while (_gameManager.tigerStateManager.sleepState.GetHP() > 0)
            {
                yield return new WaitForSeconds(1);
                _gameManager.tigerStateManager.sleepState.SetDamage();
            }
        }
    }
}