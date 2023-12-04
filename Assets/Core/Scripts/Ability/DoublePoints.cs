using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Core.Scripts.Ability
{
    public class DoublePoints : MonoBehaviour, IAbility
    {
        [SerializeField] private int[] _indexDouble;
        [SerializeField] private int _indexUpgrade;

        [Inject] private GameManager _gameManager;
        [SerializeField] private Button _buttonUpg;

        private void Start()
        {
            if (ES3.KeyExists(Str.DoublePoint))
                _indexUpgrade = ES3.Load<int>(Str.DoublePoint);
            
            _buttonUpg.onClick.AddListener(UpgradeAbility);
        }

        public void UpgradeAbility()
        {
            _indexUpgrade++;
            ES3.Save(Str.DoublePoint, _indexUpgrade);
        }

        public void ActiveAbility()
        {
            _gameManager.animalCountView.indexPointAdd = _indexDouble[_indexUpgrade];
        }

        public void DisableAbility()
        {
            _gameManager.animalCountView.indexPointAdd = 1;
        }
    }
}