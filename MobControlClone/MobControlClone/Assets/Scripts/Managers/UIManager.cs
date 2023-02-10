using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using DG.Tweening;

namespace Managers
{
    public class UIManager : SingletonMonobehaviour<UIManager>
    {
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private Image goldsImage;

        private Tweener _goldAnimationTween;
        private void OnEnable()
        {
            EventManager.CoinCollected += UpdateGoldText;
        }

        private void OnDisable()
        {
            EventManager.CoinCollected -= UpdateGoldText;
        }

        protected override void Awake()
        {
            Init();
        }

        private void Init()
        {
            goldText.text = CurrencyManager.Instance.Gold.ToString();
        }

        private void UpdateGoldText()
        {
            goldText.text = CurrencyManager.Instance.Gold.ToString();
            
            AnimateGoldsIcon();
        }

        private void AnimateGoldsIcon()
        {
            Vector3 scale = goldsImage.rectTransform.localScale;

            _goldAnimationTween = goldsImage.rectTransform.DOScale(scale * 2f, .3f).OnComplete((() =>
            {
                goldsImage.rectTransform.DOScale(scale, .3f);
            }));
            
            _goldAnimationTween.Kill();
        }
    }
}
