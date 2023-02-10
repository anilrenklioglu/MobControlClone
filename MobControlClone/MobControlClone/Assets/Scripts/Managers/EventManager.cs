
namespace Managers
{
    public static class EventManager
    {
        public delegate void GameStartDelegate();
        public static event GameStartDelegate GameStarted;
        public static void OnGameStarted() => GameStarted?.Invoke();
        
        public delegate void LevelFailedDelegate();
        public static event LevelFailedDelegate LevelFailed;
        public static void OnLevelFailed() => LevelFailed?.Invoke();
        
        public delegate void LevelFinishedDelegate();
        public static event LevelFinishedDelegate LevelFinished;    
        public static void OnLevelFinished() => LevelFinished?.Invoke();
        
        public delegate void OnCoinCollectedDelegate();
        public static event OnCoinCollectedDelegate CoinCollected;
        public static void OnCoinCollected() => CoinCollected?.Invoke();
        
        public delegate void OnCoinSpentDelegate();
        public static event OnCoinSpentDelegate CoinSpent;
        public static void OnCoinSpent() => CoinSpent?.Invoke();
        
        public delegate void OnUpgradePurchasedDelegate();
        public static event OnUpgradePurchasedDelegate UpgradePurchased;
        public static void OnUpgradePurchased() => UpgradePurchased?.Invoke();
    }
}
