using Lean.Pool;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Player.Bullet
{
    public class FactoryBullet : MonoBehaviour
    {
        [SerializeField] private Factory _bulletFactory;

        [Inject] private GameManager _gameManager;

        public void Spawn(Transform aim, float power)
        {
            var target = _gameManager.factoryAnimal.GetBird(power);
            if (target == null)
                return;

            Bullet bullet = _bulletFactory.Create<Bullet>(aim.position);
            bullet.Init(_gameManager, target.transform);
            _gameManager.factoryAnimal.RemoveAnimal(target);
            LeanPool.Despawn(bullet, 7);
        }
    }
}