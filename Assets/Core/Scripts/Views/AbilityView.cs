using System.Collections;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class AbilityView : MonoBehaviour
    {
        [SerializeField] private ActionButtonManager _actionButtonManager;

        [SerializeField] private Image _abilityImg;
        [SerializeField] private Button _abilityBtn;
        [SerializeField] private Sprite[] _abilitiesSprites;
        [SerializeField] private Button[] _abilitiesBtn;
        [SerializeField] private GameObject[] _abilities;

        private int _selectAbility;

        private void Start()
        {
            _abilityBtn.onClick.AddListener(StartAbility);
            _abilitiesBtn.ForEach((x, index) => { x.onClick.AddListener(() => SelectAbility(index)); });

            if (ES3.KeyExists(Str.Ability))
            {
                _selectAbility = ES3.Load<int>(Str.Ability);
                _abilityBtn.onClick.AddListener(() =>
                    _abilities[_selectAbility].GetComponent<IAbility>().ActiveAbility());
                _abilityBtn.image.sprite = _abilitiesSprites[_selectAbility];
                _actionButtonManager.ChangeButtons(_selectAbility);
                _abilitiesBtn[_selectAbility].interactable = false;
            }
            else
            {
                _actionButtonManager.ChangeButtons(0);
                _abilityBtn.onClick.AddListener(() => _abilities[0].GetComponent<IAbility>().ActiveAbility());
                _abilitiesBtn[0].interactable = false;
            }
        }

        public void SelectAbility(int index)
        {
            _abilitiesBtn[_selectAbility].interactable = true;
            _actionButtonManager.ChangeButtons(_selectAbility);
            _abilityBtn.onClick.RemoveListener(
                () => _abilities[_selectAbility].GetComponent<IAbility>().ActiveAbility());
            _selectAbility = index;
            ES3.Save(Str.Ability, index);
            _abilityBtn.onClick.AddListener(() => _abilities[index].GetComponent<IAbility>().ActiveAbility());
            _abilityBtn.image.sprite = _abilitiesSprites[index];
            _actionButtonManager.ChangeButtons(index);
            _abilitiesBtn[index].interactable = false;
        }

        private void StartAbility()
        {
            _abilityBtn.interactable = false;
            StartCoroutine(DelayWork());
        }

        private IEnumerator DelayWork()
        {
            while (_abilityImg.fillAmount != 0)
            {
                _abilityImg.fillAmount -= .005f;
                yield return new WaitForSeconds(.1f);
            }

            _abilities[_selectAbility].GetComponent<IAbility>().DisableAbility();
            while (_abilityImg.fillAmount != 1)
            {
                _abilityImg.fillAmount += .005f;
                yield return new WaitForSeconds(.1f);
            }

            _abilityBtn.interactable = true;
        }
    }
}