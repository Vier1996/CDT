using Codebase.Gameplay.Workers;
using Codebase.Library.SAD;
using UnityEngine;

namespace Codebase.Gameplay.Workplaces
{
    public abstract class Workplace : Entity
    {
        public bool IsAvailable => !_isBusy;
        public Transform Origin => _origin;
        public Transform WorkplaceStandingTransform => _workplaceStandingTransform;
        
        [SerializeField] protected string _workplaceId;
        [SerializeField] protected Transform _origin;
        [SerializeField] protected Transform _workplaceStandingTransform;

        protected Worker _currentWorker;
        
        protected float _workCompletePercent = 0f;
        protected bool _isBusy;
        
        public Workplace SetWorker(Worker worker)
        {
            _currentWorker = worker;
            
            return this;
        }
        
        public Workplace ReleaseWorker()
        {
            return this;
        }

        public Workplace DoWork(float workDuration)
        {

            return this;
        }
        
        protected abstract void Work(float workDuration);
    }
}
