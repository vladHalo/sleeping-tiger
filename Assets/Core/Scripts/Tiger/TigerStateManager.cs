using Core.Scripts.Interfaces;
using Core.Scripts.Tiger.Models;
using Core.Scripts.Tiger.States;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Tiger
{
    public class TigerStateManager : MonoBehaviour
    {
        public Transform pointBirdsFinish;
        public SleepState sleepState;
        public CryState cryState;

        [SerializeField] private SleepModel _sleepModel;
        [SerializeField] private CryModel _cryModel;

        [Inject] private GameManager _gameManager;
        [Inject] private AudioManager _audioManager;
        
        private IState _currentState;

        private void Start()
        {
            sleepState = new SleepState(this, _sleepModel);
            cryState = new CryState(this, _cryModel, _gameManager, _audioManager);
            _currentState = sleepState;
        }

        private void Update()
        {
            _currentState.UpdateState();
        }

        public void SetState(IState newState)
        {
            _currentState = newState;
            _currentState.EnterState();
        }
    }
}