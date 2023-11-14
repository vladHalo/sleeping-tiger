using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class AbilityView : MonoBehaviour
    {
        public int x2 = 1;
        public bool withoutPower;

        [SerializeField] private Image _abilityX2Img, _abilityWithoutPowerImg;
        [SerializeField] private Button _abilityX2Btn, _abilityWithoutPowerBtn;

        private void Start()
        {
            _abilityX2Btn.onClick.AddListener(X2);
            _abilityWithoutPowerBtn.onClick.AddListener(WithoutPower);
        }

        private void X2()
        {
            x2++;
            _abilityX2Btn.interactable = false;
            StartCoroutine(X2Delay());
        }

        private void WithoutPower()
        {
            withoutPower = true;
            _abilityWithoutPowerBtn.interactable = false;
            StartCoroutine(WithoutPowerDelay());
        }

        private IEnumerator X2Delay()
        {
            while (_abilityX2Img.fillAmount != 0)
            {
                _abilityX2Img.fillAmount -= .005f;
                yield return new WaitForSeconds(.1f);
            }

            x2--;
            while (_abilityX2Img.fillAmount != 1)
            {
                _abilityX2Img.fillAmount += .005f;
                yield return new WaitForSeconds(.1f);
            }

            _abilityX2Btn.interactable = true;
        }
        
        private IEnumerator WithoutPowerDelay()
        {
            while (_abilityWithoutPowerImg.fillAmount != 0)
            {
                _abilityWithoutPowerImg.fillAmount -= .005f;
                yield return new WaitForSeconds(.1f);
            }

            withoutPower = false;
            while (_abilityWithoutPowerImg.fillAmount != 1)
            {
                _abilityWithoutPowerImg.fillAmount += .005f;
                yield return new WaitForSeconds(.1f);
            }

            _abilityWithoutPowerBtn.interactable = true;
        }
    }
}