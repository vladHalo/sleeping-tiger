using UnityEngine;
using Zenject;

namespace Core.Scripts.Ability
{
    public class KillAll : MonoBehaviour, IAbility
    {
        [Inject] private GameManager _gameManager;

        public void ActiveAbility()
        {
            _gameManager.factoryAnimal.RemoveAllAnimal();
        }

        public void DisableAbility()
        {
            
        }
    }
}