using Core.Scripts.Interfaces;
using Core.Scripts.Tiger.Models;

namespace Core.Scripts.Tiger.States
{
    public class SleepState : IState
    {
        private readonly TigerStateManager _tiger;

        private readonly SleepModel _sleepModel;

        public SleepState(TigerStateManager tiger, SleepModel sleepModel)
        {
            _tiger = tiger;
            _sleepModel = sleepModel;
        }

        public void EnterState()
        {
        }

        public void UpdateState()
        {
        }

        public void AddHP(float index)
        {
            _sleepModel.hp += index;
            if (_sleepModel.hp > 1)
                _sleepModel.hp = 1;
        }

        public float GetHP() => _sleepModel.hp;

        public void SetDamage()
        {
            _sleepModel.hp -= .01f;
            _sleepModel.barView.SetValue(_sleepModel.hp);
            if (_sleepModel.hp <= 0)
            {
                _tiger.SetState(_tiger.cryState);
            }
        }
    }
}