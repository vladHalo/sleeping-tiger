using System.Collections.Generic;
using Core.Scripts.Views;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Store
{
    public class StoreLogic : MonoBehaviour
    {
        public ActionButtonUpgradeManager ActionButtonUpgradeManager;
        public ActionPanelManager ActionPanelManager;
        [SerializeField] private StoreMoney _storeMoney;
        [SerializeField] private int _pricesBuy;
        [SerializeField] private List<int> _prices;
        [SerializeField] private List<Text> _pricesText;

        public void Start()
        {
            _storeMoney.Start();
            ActionButtonUpgradeManager.AddListener(CheckMoney);
            ActionPanelManager.AddListener(CheckMoneyBuy);

            _pricesText.ForEach((x, index) => { x.text = $"{_prices[index]}"; });
        }

        public void AddMoney(int count) => _storeMoney.Add(count);

        public void CheckMoney(int index)
        {
            if (_storeMoney.CanMinus(_prices[index]))
            {
                ActionButtonUpgradeManager.NextStep(index);
            }
            else
            {
                Debug.Log("Не вистачає грошей!");
            }
        }

        public void CheckMoneyBuy(int index)
        {
            if (_storeMoney.CanMinus(_pricesBuy))
            {
                ActionPanelManager.GetMethod().Invoke(index);
            }
            else
            {
                Debug.Log("Не вистачає грошей!");
            }
        }
    }
}