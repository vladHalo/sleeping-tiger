using Core.Scripts.Player.Bullet;
using Core.Scripts.Views;
using UnityEngine;

namespace Core.Scripts.Player
{
    public class PlayerShot : MonoBehaviour
    {
        [SerializeField] private Transform _aim;
        [SerializeField] private SpawnBullet _spawnBullet;
        [SerializeField] private InputControllerView _input;

        private void Start()
        {
            _input.ShotAction += Shot;
        }

        private void Shot(float power)
        {
            _spawnBullet.Spawn(_aim, power);
        }

        private void OnDisable()
        {
            _input.ShotAction -= Shot;
        }
    }
}