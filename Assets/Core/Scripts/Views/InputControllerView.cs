using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Scripts.Views
{
    public class InputControllerView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public Action<float> ShotAction;

        [SerializeField] private GameObject _buttonShot;
        [SerializeField] private EventTrigger _eventTrigger;
        [SerializeField] private BarView _barView;
        [SerializeField] private OnBoarding _onBoarding;

        private bool _isButtonHeld;
        private float _buttonHeldTime;

        private void Start()
        {
            EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
            pointerDownEntry.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
            _eventTrigger.triggers.Add(pointerDownEntry);

            EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
            pointerUpEntry.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
            _eventTrigger.triggers.Add(pointerUpEntry);
        }

        private void Update()
        {
            if (_isButtonHeld)
            {
                _buttonHeldTime += Time.deltaTime;
                _barView.SetValue(_buttonHeldTime);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_buttonShot.activeSelf == false) return;

            _isButtonHeld = true;
            _buttonHeldTime = 0;
            _barView.SetValue(0);

            if (!PlayerPrefs.HasKey(Str.Board))
                _onBoarding.NextStep();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_buttonShot.activeSelf == false) return;

            _isButtonHeld = false;
            _buttonHeldTime = 0;

            ShotAction?.Invoke(_barView.GetValue());
            _barView.SetValue(0);
            _buttonShot.SetActive(false);
            Invoke(nameof(OnButtonShot), 1.1f);
        }

        private void OnButtonShot() => _buttonShot.SetActive(true);
    }
}