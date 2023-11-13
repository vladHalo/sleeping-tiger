using Core.Scripts.Interfaces;
using Core.Scripts.Player.Models;
using Core.Scripts.Player.States;
using UnityEngine;

namespace Core.Scripts.Player
{
    public class PlayerStateManager : MonoBehaviour
    {
        private IState _currentState;
        [SerializeField] private ShotModel _shotModel;
        
        public ShotState shotState;

        private void Start()
        {
            shotState = new ShotState(this, _shotModel);
        }

        private void Update()
        {
            //target ??= playerTrigger.GetEnemy();

            _currentState.UpdateState();
        }

        public void SetState(IState newState)
        {
            _currentState = newState;
            _currentState.EnterState();
        }
    }
}