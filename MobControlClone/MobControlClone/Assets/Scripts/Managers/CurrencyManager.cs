using UnityEngine;
using Utilities;

namespace Managers
{
    public class CurrencyManager : SingletonMonobehaviour<CurrencyManager>
    {
        private int _gold;
        public int Gold { get => _gold; set => _gold = value;}

        protected override void Awake()
        {
            base.Awake();
            
            Init();
        }

        private void Init()
        {
            Gold = PlayerPrefs.GetInt("Gold",0);
        }
        public void AddGold(int amount)
        {
            Gold += amount;
            
            SaveGold(Gold);
            
            EventManager.OnCoinCollected();
        }
        
        public void RemoveGold(int amount)
        {
            Gold -= amount;
            SaveGold(Gold);
        }
        
        
        private void SaveGold(int gold)
        {
            PlayerPrefs.SetInt("Gold",gold);
        }
        
    }
}