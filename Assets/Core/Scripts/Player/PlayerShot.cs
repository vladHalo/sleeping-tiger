using Core.Scripts.Player.Bullet;
using Core.Scripts.Views;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Core.Scripts.Player
{
    public class PlayerShot : MonoBehaviour
    {
        [SerializeField] private Transform _aim;
        [SerializeField] private FactoryBullet _factoryBullet;
        [SerializeField] private InputControllerView _input;
        [SerializeField] private ParticleSystem _particle;

        private void Start()
        {
            _input.ShotAction += Shot;
        }

        private void Shot(float power)
        {
            _particle.Play();
            _factoryBullet.Spawn(_aim, power);
            AudioManager.instance.PlaySoundEffect(SoundType.Shot);
        }

        private void OnDisable()
        {
            _input.ShotAction -= Shot;
        }
    }
}