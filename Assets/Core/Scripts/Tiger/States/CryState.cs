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
        private AudioManager _audioManager;

        public CryState(TigerStateManager tiger, CryModel cryModel, GameManager gameManager, AudioManager audioManager)
        {
            _tiger = tiger;
            _cryModel = cryModel;
            _gameManager = gameManager;
            _audioManager = audioManager;
        }

        public void EnterState()
        {
            _tiger.StopAllCoroutines();
            _gameManager.statusGame=StatusGame.Stop;
            _cryModel.animator.SetTrigger(Str.Cry);
            _tiger.StartCoroutine(Lose());
            _audioManager.PlaySoundEffect(SoundType.Cry);
        }

        public void UpdateState()
        {
        }
        
        private IEnumerator Lose()
        {
            yield return new WaitForSeconds(1.5f);
            _cryModel.actionPanelManager.OpenPanels(0);
        }
    }
}