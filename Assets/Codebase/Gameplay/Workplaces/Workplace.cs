using Codebase.Gameplay.Workers;
using UnityEngine;

namespace Codebase.Gameplay.Workplaces
{
    public abstract class Workplace : MonoBehaviour
    {
        public bool IsAvailable => !_isBusy;
        
        [SerializeField] protected string _workplaceId;

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
