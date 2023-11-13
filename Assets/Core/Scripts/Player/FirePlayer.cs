using Core.Scripts.Views;
using Lean.Pool;
using UnityEngine;

namespace Core.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    public class FirePlayer : Player
    {
        [SerializeField] private Transform _aim;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private BulletCount _bulletCount;

        private Animator _animator;
        //private GameManager _gameManager;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Debug.DrawLine(_aim.position, _aim.position + _aim.forward * 300, Color.green, 0f);

            //if (_gameManager.statusGame == StatusGame.MoveCamera) return;

            if (Input.GetMouseButtonDown(0))
            {
                _animator.Play(Str.FireIdle);
                //_gameManager.statusGame = StatusGame.FireGun;
            }
            else if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                Vector3 targetPosition = ray.GetPoint(300);
                _aim.LookAt(targetPosition);
            }
            else if (Input.GetMouseButtonUp(0) /*&& _gameManager.statusGame == StatusGame.FireGun*/)
            {
                var bulletRb = LeanPool.Spawn(_bullet, _aim.transform.position, Quaternion.identity)
                    .GetComponent<Rigidbody>();
                bulletRb.velocity = _aim.forward * _speed;
                Destroy(bulletRb.gameObject, 20);

                _bulletCount.Refresh();

                _animator.Play(Str.Fire);
            }
        }
    }
}