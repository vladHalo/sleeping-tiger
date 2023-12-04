using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Core.Scripts.Ability
{
    public class AddHP : MonoBehaviour, IAbility
    {
        [SerializeField] private float[] _indexHP;
        [SerializeField] private int _indexUpgrade;
        [SerializeField] private Button _buttonUpg;

        [Inject] private GameManager _gameManager;

        private void Start()
        {
            if (ES3.KeyExists(Str.AddHP))
                _indexUpgrade = ES3.Load<int>(Str.AddHP);
            
            _buttonUpg.onClick.AddListener(UpgradeAbility);
        }

        public void UpgradeAbility()
        {
            _indexUpgrade++;
            ES3.Save(Str.AddHP, _indexUpgrade);
        }

        public void ActiveAbility()
        {
            _gameManager.tigerStateManager.sleepState.AddHP(_indexHP[_indexUpgrade]);
        }

        public void DisableAbility()
        {
        }
    }
}