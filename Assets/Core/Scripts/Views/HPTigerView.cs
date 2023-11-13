using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class HPTigerView : MonoBehaviour
    {
        [SerializeField] private Image _hpBar;

        public void SetValue(float value)=> _hpBar.fillAmount = value;
    }
}