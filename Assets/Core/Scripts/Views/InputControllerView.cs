using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class InputControllerView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public Action<float> ShotAction;

        [SerializeField] private Button _buttonShot;
        [SerializeField] private EventTrigger _eventTrigger;
        [SerializeField] private BarView _barView;

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
            if (_buttonShot.interactable == false) return;

            _isButtonHeld = true;
            _buttonHeldTime = 0;
            _barView.SetValue(0);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_buttonShot.interactable == false) return;

            _isButtonHeld = false;
            _buttonHeldTime = 0;

            ShotAction?.Invoke(_barView.GetValue());
            _barView.SetValue(0);
            _buttonShot.interactable = false;
            Invoke(nameof(OnButtonShot), .75f);
        }

        private void OnButtonShot() => _buttonShot.interactable = true;
    }
}