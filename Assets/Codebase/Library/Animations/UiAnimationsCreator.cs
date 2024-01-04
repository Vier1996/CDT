using System;
using System.Collections.Generic;
using System.Linq;
using Codebase.Gameplay.Counters;
using Codebase.Gameplay.Enums;
using Codebase.Gameplay.GameResources;
using Codebase.Library.Extension;
using DG.Tweening;
using Lean.Pool;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Codebase.Library.Animations
{
    public class UiAnimationsCreator
    {
        private AnimationsCreatorElement _element;
        private readonly Transform _parent;
        private Dictionary<ResourceType, CounterView> _parentDictionary = new();

        private readonly Color _fadedColor = new Color(1, 1, 1, 0);
        private readonly Ease _movementEase = Ease.InCubic;
        private readonly Ease _scalingEase = Ease.InOutSine;

        private CompositeDisposable _compositeDisposable = new();

        public UiAnimationsCreator(Transform objectsParent)
        {
            _parent = objectsParent;
            
            GameObject item = new GameObject("AnimationsCreatorItem");
            item.AddComponent<Image>();
            
            _element = item.AddComponent<AnimationsCreatorElement>();
            _element = LeanPool.Spawn(_element, parent: _parent);

            LeanPool.Despawn(_element);
        }

        public Transform GetSpawnParent() => _parent;

        public void Animate(ResourceType resourceType, int itemsCount, Vector3 startPosition, float customScale = 1f, 
            float customDuration = 1.5f, float customCircleSize = 100f, float delay = 0f, Action onComplete = null)
        {
            CounterView targetCounter = GetCounter(resourceType);
            
            ResourcesSpritesContainer container = ResourcesSpritesContainer.GetInstance();
            float expandingTime = customDuration * 0.3f;
            float movementTime = customDuration * 0.7f;
            itemsCount = itemsCount > 5 ? 5 : itemsCount;
            
            for (int i = 0; i < itemsCount; i++)
                RX.Delay(delay + UnityEngine.Random.Range(0f, 0.25f), AfterDelayAnimation).AddTo(_compositeDisposable);

            void AfterDelayAnimation()
            {
                AnimationsCreatorElement item = LeanPool.Spawn(_element, parent: _parent, position: startPosition, rotation: Quaternion.identity);

                item.Image.KillTween();
                item.Image.color = _fadedColor;
                item.Image.sprite = container.GetResourceSpriteData(resourceType).ResourceSprite;
                item.Image.SetNativeSize();

                item.Image.DOFade(1f, expandingTime);
                item
                    .Transform
                    .DOScale(1.5f, expandingTime)
                    .SetEase(_scalingEase)
                    .OnComplete(() =>
                    {
                        item
                            .Transform
                            .DOScale(0.5f, movementTime)
                            .SetEase(_scalingEase);
                    });
            
                item
                    .Transform
                    .DOMove((Vector2)startPosition + UnityEngine.Random.insideUnitCircle * Vector2.one * customCircleSize, expandingTime)
                    .SetEase(_scalingEase)
                    .OnComplete(() =>
                    {
                        if (targetCounter == null)
                        {
                            item.Image
                                .DOFade(0f, movementTime)
                                .SetEase(_movementEase)
                                .OnComplete(() =>
                                {
                                    item.Image.color = _fadedColor;
                                    
                                    onComplete?.Invoke();
                                    onComplete = null;
                                
                                    LeanPool.Despawn(item);
                                });

                            return;
                        }
                        
                        item.Transform
                            .DOMove(targetCounter.IconTransform.position, movementTime)
                            .SetEase(_movementEase)
                            .OnComplete(() =>
                            {
                                item.Image.color = _fadedColor;
                                
                                ShakeTarget(targetCounter);
                                
                                onComplete?.Invoke();
                                onComplete = null;
                                
                                LeanPool.Despawn(item);
                            });
                    });
            }

            container.Release();
        }

        private void ShakeTarget(CounterView counter)
        {
            counter.IconTransform.KillTween();

            counter.IconTransform
                .DOScale(1.2f, 0.1f)
                .OnComplete(() => counter.IconTransform.DOScale(Vector3.one, 0.1f));
        }

        private CounterView GetCounter(ResourceType resourceType)
        {
            if (_parentDictionary.TryGetValue(resourceType, out CounterView parent))
                return parent;
            
            switch (resourceType)
            {
                case ResourceType.MONEY:
                case ResourceType.GEMS:
                    
                    CounterView[] counters = Object.FindObjectsOfType<CounterView>();
                    
                    if(counters is null or null)
                        throw new ArgumentException($"Can not find Transform for [{resourceType}] resourceType, counters is null");

                    CounterView counter = counters.FirstOrDefault(ctr => ctr.ResourceType == resourceType);
                    
                    if(counter == default)
                        throw new ArgumentException($"Can not find Transform for [{resourceType}] resourceType, counters is default");
                    
                    _parentDictionary.Add(resourceType, counter);

                    return counter;
            }

            throw new ArgumentException($"Can not find Transform for [{resourceType}] resourceType");
        }
    }
}