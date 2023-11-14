using Core.Scripts.Bird;
using Lean.Pool;
using UnityEngine;

namespace Core.Scripts.Player.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidbody;

        private GameManager _gameManager;
        private Transform _target;

        public void Init(GameManager gameManager, Transform target)
        {
            _gameManager = gameManager;
            _target = target;
        }

        private void Update()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            _rigidbody.velocity = direction * _speed;

            if (!_target.gameObject.activeSelf) LeanPool.Despawn(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out MoveBird moveBird))
            {
                _gameManager.birdCountView.AddCount();
                _gameManager.spawnBird.RemoveBird(moveBird);
                LeanPool.Despawn(moveBird.gameObject);
                LeanPool.Despawn(gameObject);
            }
        }
    }
}