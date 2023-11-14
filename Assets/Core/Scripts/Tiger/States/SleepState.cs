using System.Collections;
using Core.Scripts.Interfaces;
using Core.Scripts.Tiger.Models;
using UnityEngine;

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

        public void StartGetDamage() => _tiger.StartCoroutine(GetDamage());

        private IEnumerator GetDamage()
        {
            while (_sleepModel.hp > 0)
            {
                yield return new WaitForSeconds(1);
                _sleepModel.hp -= .01f;
                _sleepModel.barView.SetValue(_sleepModel.hp);
                if (_sleepModel.hp <= 0)
                {
                    _tiger.SetState(_tiger.cryState);
                }
            }
        }
    }
}