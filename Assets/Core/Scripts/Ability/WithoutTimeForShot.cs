using UnityEngine;
using Zenject;

namespace Core.Scripts.Ability
{
    public class WithoutTimeForShot : MonoBehaviour, IAbility
    {
        [Inject] private GameManager _gameManager;

        public void ActiveAbility()
        {
            _gameManager.factoryAnimal.withoutPower = true;
        }
        
        public void DisableAbility()
        {
            _gameManager.factoryAnimal.withoutPower = false;
        }
    }
}