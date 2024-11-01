using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Counters
{
    public class CounterText : MonoBehaviour
    {
        public delegate string CustomFormatter(double value);

        [SerializeField] private TextMeshProUGUI _targetText;
        
        [SerializeField] private double _duration = 1f;
        [SerializeField] private double _minChangeSpeed = 20f;
        
        private bool _completeHandled = true;

        private double _targetValue;
        private double _changeSpeed;
        private double _currentValue;
        private double _displayedValue;
        
        private string _formatString = "";

        private CustomFormatter _customFormatter;

        private Type _type;

        private void Update()
        {
            if (Math.Abs(_displayedValue - _targetValue) > 0.001f)
            {
                _currentValue = _displayedValue < _targetValue
                    ? Math.Min(_currentValue + _changeSpeed * Time.deltaTime, _targetValue)
                    : Math.Max(_currentValue - _changeSpeed * Time.deltaTime, _targetValue);

                _displayedValue = _currentValue;

                UpdateText();
            }
        }

        public void ChangeTargetValue(double targetValueChange, bool animated) => 
            SetTargetValue(targetValueChange, animated);

        private void SetTargetValue(double targetValue, bool animated)
        {
            _completeHandled = false;
            
            if (animated)
            {
                if (Math.Abs(_displayedValue - targetValue) < 0.001f)
                {
                    ApplyTargetValueImmediately(targetValue);
                }
                else
                {
                    _targetValue = targetValue;
                    _changeSpeed = Math.Max(_minChangeSpeed, Math.Abs(targetValue - _displayedValue) / _duration);
                }
            }
            else
            {
                ApplyTargetValueImmediately(targetValue);
            }
        }

        private void ApplyTargetValueImmediately(double targetValue)
        {
            _changeSpeed = 0d;
            _currentValue = targetValue;

            _targetValue = targetValue;
            _displayedValue = targetValue;

            UpdateText();
        }

        private void UpdateText()
        {
            double roundDisplayedValue = Math.Floor(_displayedValue);
            
            switch (_type)
            {
                case Type.BASE:
                    _targetText.text = roundDisplayedValue.ToString(CultureInfo.InvariantCulture);
                    break;
                case Type.FORMATTED_STRING:
                    _targetText.text = string.Format(_formatString, roundDisplayedValue);
                    break;
                case Type.CUSTOM_FORMATTER:
                    _targetText.text = _customFormatter.Invoke(roundDisplayedValue);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (Math.Abs(_targetValue - _displayedValue) < 0.001f && !_completeHandled) 
                _completeHandled = true;
        }

        public void SetDuration(float duration) => _duration = duration;

        public void SetCustomFormatter(CustomFormatter formatter)
        {
            _customFormatter = formatter;
            _type = Type.CUSTOM_FORMATTER;
        }

        private enum Type
        {
            BASE,
            FORMATTED_STRING,
            CUSTOM_FORMATTER,
        }
    }
}
