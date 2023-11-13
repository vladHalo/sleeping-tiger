using System.Collections;
using Core.Scripts.Interfaces;
using UnityEngine;

namespace Core.Scripts.Tiger.States
{
    public class CryState : IState
    {
        private readonly TigerStateManager _tiger;

        private readonly Animator _animator;

        public CryState(TigerStateManager tiger, Animator animator)
        {
            _tiger = tiger;
            _animator = animator;
        }

        public void EnterState()
        {
            _tiger.StopAllCoroutines();
            _animator.SetTrigger(Str.Cry);
            _tiger.StartCoroutine(Lose());
        }

        public void UpdateState()
        {
        }

        private IEnumerator Lose()
        {
            yield return new WaitForSeconds(1.5f);
            Debug.Log("Lose");
        }
    }
}