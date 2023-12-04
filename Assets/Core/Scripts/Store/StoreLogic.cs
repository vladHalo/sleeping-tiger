using System.Collections.Generic;
using Core.Scripts.Views;
using Sirenix.Utilities;
using UnityEngine;

namespace Core.Scripts.Store
{
    public class StoreLogic : MonoBehaviour
    {
        public ActionButtonUpgradeManager ActionButtonUpgradeManager;
        public ActionPanelManager ActionPanelManager;
        [SerializeField] private StoreMoney _storeMoney;
        [SerializeField] private List<int> _pricesBuy;
        [SerializeField] private List<int> _prices;

        public void Start()
        {
            _storeMoney.Start();
            ActionButtonUpgradeManager.AddListener(CheckMoney);
            ActionPanelManager.AddListener(CheckMoneyBuy);

            _prices.ForEach((x, index) => { ActionButtonUpgradeManager.ChangePriceText(index, _prices[index]); });
        }

        public void AddMoney(int count) => _storeMoney.Add(count);

        public void CheckMoney(int index)
        {
            if (_storeMoney.CanMinus(_prices[index]))
            {
                ActionButtonUpgradeManager.NextStep(index);
                ActionButtonUpgradeManager.ChangePriceText(index, _prices[index]);
            }
            else
            {
                StartCoroutine(_storeMoney.DelayFade());
                Debug.Log("Не вистачає грошей!");
            }
        }

        public void CheckMoneyBuy(int index)
        {
            if (_storeMoney.CanMinus(_pricesBuy[index]))
            {
                ActionPanelManager.GetMethod().Invoke(index);
            }
            else
            {
                StartCoroutine(_storeMoney.DelayFade());
                Debug.Log("Не вистачає грошей!");
            }
        }
    }
}