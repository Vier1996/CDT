using System;
using ACS.SignalBus.SignalBus;
using DG.Tweening;
using InternalAssets.Codebase.Library.Extension;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Codebase.Library.Gui
{
    public class CustomToggle : MonoBehaviour
    {
        public event Action<bool> StateChanged;

        public bool State { get; private set; }

        [SerializeField] private Image _toggleBackground;
        [SerializeField] private Sprite _toggleEnabledBackground;
        [SerializeField] private Sprite _toggleDisabledBackground;
        
        [SerializeField] private Image _toggleImage;
        [SerializeField] private Sprite _toggleEnabledSprite;
        [SerializeField] private Sprite _toggleDisabledSprite;
        
        [SerializeField] private TextMeshProUGUI _toggleText;
        [SerializeField] private Color _toggleTextEnabledColor;
        [SerializeField] private Color _toggleTextDisabledColor;
        
        [SerializeField] private Button _toggleButton;

        private ISignalBusService _signalBusService;
        
        private void Start()
        {
            ACS.Core.ServicesContainer.ServiceContainer.Core.Get(out _signalBusService);
            
            _toggleButton.onClick.AddListener(ChangeState);
        }

        public void SetState(bool state)
        {
            State = state;

            UpdateView(true);
        }
        
        private void ChangeState()
        {
            State = !State;
            
            UpdateView();
        }

        private void UpdateView(bool instant = false)
        {
            _toggleText.KillTween();
            _toggleButton.transform.KillTween();
            _toggleText.transform.KillTween();
            
            _toggleBackground.sprite = State ? _toggleEnabledBackground : _toggleDisabledBackground;
            _toggleImage.sprite = State ? _toggleEnabledSprite : _toggleDisabledSprite;
            _toggleText.DOColor(State ? _toggleTextEnabledColor : _toggleTextDisabledColor, 0.25f);
            
            UpdateLocalization();
            
            ((RectTransform)_toggleButton.transform).DOAnchorPosX(State ? 100f : 0f, 0.25f);
            ((RectTransform)_toggleText.transform).DOAnchorPosX(State ? -31f : 31f, 0.25f);
                
            if(instant == false)
                StateChanged?.Invoke(State);
        }

        private void UpdateLocalization()
        {
            _toggleText.text = State ? "On" : "Off";
        }

        private void OnDestroy()
        {
            _toggleButton.onClick.RemoveListener(ChangeState);
        }
    }
}
