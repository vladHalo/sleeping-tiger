//using _1Core.Scripts.Bot;
using _1Core.Scripts.Interfaces;
using _1Core.Scripts.Player.Models;
using _1Core.Scripts.Player.States;
using UnityEngine;
using UnityEngine.Serialization;

namespace _1Core.Scripts.Player
{
    public class PlayerStateManager : MonoBehaviour
    {
        private IState _currentState;
        [SerializeField] private RotateModel _rotateModel;
        [SerializeField] private ShotModel _shotModel;
        [SerializeField] private DeadModel _deadModel;

        public PlayerAnimation playerAnimation;
        public RotateState rotateState;
        public ShotState shotState;
        public DeadState deadState;

        public PlayerTrigger playerTrigger;
        public PlayerDamage playerDamage;
        //public AIBotController target;

        private void Start()
        {
            rotateState = new RotateState(this, _rotateModel);
            shotState = new ShotState(this, _shotModel);
            deadState = new DeadState(this, _deadModel);
            _currentState = rotateState;
        }

        private void Update()
        {
            //target ??= playerTrigger.GetEnemy();

            _currentState.UpdateState();
        }

        public void SetState(IState newState)
        {
            _currentState.ExitState();
            _currentState = newState;
            _currentState.EnterState();
        }
    }
}