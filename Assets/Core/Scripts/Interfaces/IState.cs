using UnityEngine;

namespace _1Core.Scripts.Interfaces
{
    public interface IState
    {
        void EnterState();
        void UpdateState();
        void ExitState();
    }
}