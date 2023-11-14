using System.Collections;
using Core.Scripts.Interfaces;
using Core.Scripts.Tiger.Models;
using UnityEngine;

namespace Core.Scripts.Tiger.States
{
    public class CryState : IState
    {
        private readonly TigerStateManager _tiger;

        private readonly CryModel _cryModel;

        private GameManager _gameManager;

        public CryState(TigerStateManager tiger, CryModel cryModel, GameManager gameManager)
        {
            _tiger = tiger;
            _cryModel = cryModel;
            _gameManager = gameManager;
        }

        public void EnterState()
        {
            _tiger.StopAllCoroutines();
            _gameManager.ChangeStatus();
            _cryModel.animator.SetTrigger(Str.Cry);
            _tiger.StartCoroutine(Lose());
        }

        public void UpdateState()
        {
        }

        private IEnumerator Lose()
        {
            yield return new WaitForSeconds(1.5f);
            _cryModel.viewController.OpenLosePanel();
        }
    }
}