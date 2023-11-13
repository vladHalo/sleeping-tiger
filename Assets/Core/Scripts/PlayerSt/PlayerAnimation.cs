using UnityEngine;

namespace _1Core.Scripts.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        //private bool _hasShot;

        //private void Start()
        //{
        //_hasShot = false;
        //_animator.SetTrigger(Str.Fire);
        //}

        public void SetAnimation(string nameAnimation) => _animator.SetTrigger(nameAnimation);
        //
        // public bool IsTimeShoot()
        // {
        //     if (_animator.GetBool(Str.Fire) && !_hasShot)
        //     {
        //         _hasShot = true;
        //         _animator.SetTrigger(Str.Shot);
        //         return true;
        //     }
        //
        //     if (_animator.GetBool(Str.Shot))
        //     {
        //         _animator.SetTrigger(Str.Fire);
        //         _hasShot = false;
        //     }

        //return false;
        //}
    }
}