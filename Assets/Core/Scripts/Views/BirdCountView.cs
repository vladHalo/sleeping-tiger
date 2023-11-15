using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class BirdCountView : MonoBehaviour
    {
        [SerializeField] private AbilityView _abilityView;
        [SerializeField] private Text _birdsCountUI, _bestScore;
        private int _count, _bestCount;

        private void Start()
        {
            if (PlayerPrefs.HasKey(Str.BestScore))
            {
                _bestCount = PlayerPrefs.GetInt(Str.BestScore);
                _bestScore.text = $"{_bestCount}";
            }
        }

        public void AddCount()
        {
            _count += _abilityView.x2;
            _birdsCountUI.text = $"{_count}";
            if (_count > _bestCount)
                PlayerPrefs.SetInt(Str.BestScore, _count);
        }
    }
}