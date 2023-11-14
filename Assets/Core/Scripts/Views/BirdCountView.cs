using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class BirdCountView : MonoBehaviour
    {
        [SerializeField] private AbilityView _abilityView;
        [SerializeField] private Text _birdsCountUI;
        private int _count;

        public void AddCount()
        {
            _count += _abilityView.x2;
            _birdsCountUI.text = $"Birds: {_count}";
        }
    }
}