using ACS.Core.ServicesContainer;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes.Transition;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Library.Behavior;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.Systems.Brain.Clusters
{
    public class CatRandomEvent : AbstractCatBrainCluster
    {
        private readonly INavigationService _navigationService;
        
        public CatRandomEvent()
        {
            ServiceContainer.Global.TryGetService(out _navigationService);
        }
        
        public override bool IsAccepted(CatEntity catEntity)
        {
            if (_navigationService.TryGetRandomPoint(out Vector3 point))
            {
                SetBusyStat(catEntity);
                
                IBehaviorMachine behaviorMachine = catEntity.Components.GetAbstractComponent<IBehaviorMachine>();
                TransitionBehaviorComponents transitionComponents = new (point, new ChangePositionReason(() => ReleaseBusyStat(catEntity)));
                BehaviorStateProperty stateProperty = new (typeof(CatTransitionToPointBehavior), transitionComponents);
                
                behaviorMachine.Notify(stateProperty);

                return true;
            }
            
            return false;
        }
    }
}