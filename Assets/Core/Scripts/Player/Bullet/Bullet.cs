using Core.Scripts.Bird;
using Lean.Pool;
using Sirenix.Utilities;
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
            if (other.TryGetComponent(out MoveAnimal moveBird))
            {
                AudioManager.instance.PlaySoundEffect(SoundType.DeadAnimal);
                _gameManager.animalCountView.AddCount();
                _gameManager.storeLogic.AddMoney(1);

                moveBird._particle.gameObject.SetActive(false);
                _gameManager.particle.transform.position = moveBird.transform.position;
                _gameManager.particle.Play();
                _gameManager.AddMoneyForPanel();
                LeanPool.Despawn(moveBird.gameObject);
                LeanPool.Despawn(gameObject);
            }
        }
    }
}