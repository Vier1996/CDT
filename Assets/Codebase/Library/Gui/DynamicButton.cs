using Codebase.Library.Extension;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Library.Gui
{
    public class DynamicButton : MonoBehaviour
    {
        [BoxGroup("Control buttons"), SerializeField] private Button _showButton;
        [BoxGroup("Control buttons"), SerializeField] private Button _hideButton;
        [BoxGroup("Target"), SerializeField] private RectTransform _displayableParent;
        [BoxGroup("Target"), SerializeField] private float _displayedPos = 0f;
        [BoxGroup("Target"), SerializeField] private float _hidedPos = 0f;
        [BoxGroup("Target"), SerializeField] private bool _hideByX = true;
        [BoxGroup("Target"), SerializeField] private float _animationSpeed = 0.2f;

        private bool _isShowed = false;

        private void Awake()
        {
            if(_isShowed)
                Show(true);
            else 
                Hide(true);
        }

        private void Start()
        {
            _showButton.onClick.AddListener(() => Show());
            _hideButton.onClick.AddListener(() => Hide());
        }

        private void Show(bool instant = false)
        {
            KillTween();
            HideShowButton(instant);
            
            if (_hideByX)
            {
                if (instant)
                {
                    _displayableParent
                        .DOAnchorPosX(_displayedPos, 0f)
                        .OnComplete(() => DisplayHideButton(true));
                    
                    return;
                }
                
                _displayableParent
                    .DOAnchorPosX(_displayedPos + 25f, _animationSpeed * 0.75f)
                    .OnComplete(() =>
                    {
                        _displayableParent
                            .DOAnchorPosX(_displayedPos, _animationSpeed * 0.25f)
                            .OnComplete(() => DisplayHideButton());
                    });
            }
            else
            {
                if (instant)
                {
                    _displayableParent
                        .DOAnchorPosY(_displayedPos, 0f)
                        .OnComplete(() => DisplayHideButton(true));
                    
                    return;
                }
                
                _displayableParent
                    .DOAnchorPosY(_displayedPos + 25f, _animationSpeed * 0.75f)
                    .OnComplete(() =>
                    {
                        _displayableParent
                            .DOAnchorPosY(_displayedPos, _animationSpeed * 0.25f)
                            .OnComplete(() => DisplayHideButton());
                    });
            }
        }

        private void Hide(bool instant = false)
        {
            KillTween();
            HideCloseButton(instant);
            
            if (_hideByX)
            {
                _displayableParent
                    .DOAnchorPosX(_hidedPos, instant ? 0f : _animationSpeed)
                    .OnComplete(() => DisplayShowButton(instant));

            }
            else
            {
                _displayableParent
                    .DOAnchorPosY(_hidedPos, instant ? 0f : _animationSpeed)
                    .OnComplete(() => DisplayShowButton(instant));
            }
        }

        private void DisplayShowButton(bool instant = false)
        {
            _showButton
                .image
                .DOFade(1f, instant ? 0f : _animationSpeed * 0.5f)
                .OnStart(() =>
                {
                    _showButton.gameObject.SetActive(true);
                });
        }
        
        private void HideShowButton(bool instant = false)
        {
            _showButton
                .image
                .DOFade(0f, instant ? 0f : _animationSpeed * 0.5f)
                .OnComplete(() =>
                {
                    _showButton.gameObject.SetActive(false);
                });
        }
        
        private void DisplayHideButton(bool instant = false)
        {
            _hideButton
                .image
                .DOFade(1f, instant ? 0f : _animationSpeed * 0.5f)
                .OnStart(() =>
                {
                    _hideButton.gameObject.SetActive(true);
                });
        }
        
        private void HideCloseButton(bool instant = false)
        {
            _hideButton
                .image
                .DOFade(0f, instant ? 0f : _animationSpeed * 0.5f)
                .OnComplete(() =>
                {
                    _hideButton.gameObject.SetActive(false);
                });
        }

        private void KillTween()
        {
            _displayableParent.KillTween();
            _showButton.image.KillTween();
            _hideButton.image.KillTween();
        }
    }
}
