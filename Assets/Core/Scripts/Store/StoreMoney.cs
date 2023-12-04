using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Store
{
    [Serializable]
    public class StoreMoney
    {
        [SerializeField] private int _money;
        [SerializeField] private Text _text;

        public void Start()
        {
            if (ES3.KeyExists(Str.Money))
                _money = ES3.Load<int>(Str.Money);
            _text.text = $"{_money}";
        }

        public void Add(int count)
        {
            _money += count;
            _text.text = $"{_money}";
            ES3.Save(Str.Money, _money);
        }

        public bool CanMinus(int count)
        {
            if (_money >= count)
            {
                _money -= count;
                _text.text = $"{_money}";
                ES3.Save(Str.Money, _money);
                return true;
            }
            return false;
        }

        public IEnumerator DelayFade()
        {
            _text.color = Color.red;
            yield return new WaitForSeconds(.5f);
            _text.color = Color.white;
        }
    }
}