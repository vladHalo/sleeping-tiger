using Core.Scripts.Player.Bullet;
using Core.Scripts.Views;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Player
{
    public class PlayerShot : MonoBehaviour
    {
        [SerializeField] private Transform _aim;
        [SerializeField] private SpawnBullet _spawnBullet;
        [SerializeField] private InputControllerView _input;

        [SerializeField] private AudioClip _audioClip;
        [Inject] private AudioManager _audioManager;
        
        private void Start()
        {
            _input.ShotAction += Shot;
        }

        private void Shot(float power)
        {
            _spawnBullet.Spawn(_aim, power);
            _audioManager.PlaySoundEffect(_audioClip);
        }

        private void OnDisable()
        {
            _input.ShotAction -= Shot;
        }
    }
}