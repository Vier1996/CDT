using System;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace InternalAssets.Codebase.Library.Extension
{
    public static class Navigation
    {
        public static IObservable<bool> MoveTo(this NavMeshAgent agent, Vector3 targetPosition, float maxDistanceRadius = 2f, float remainingDistance = 0.1f) =>
            Observable.Create<bool>(observer =>
            {
                if (NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, maxDistanceRadius, 1) == false)
                    targetPosition = agent.transform.position;

                agent.SetDestination(targetPosition);
                agent.isStopped = false;
                
                void CheckRemainDistance()
                {
                    if (agent == null)
                    {
                        observer.OnCompleted();
                        return;
                    }
                    
                    if (agent.remainingDistance > remainingDistance)
                    {
                        observer.OnNext(false);
                    }
                    else
                    {
                        agent.isStopped = true;
                        
                        observer.OnNext(true);
                        observer.OnCompleted();
                    }
                }
                
                return new CompositeDisposable
                {
                    Observable.EveryUpdate().Subscribe(_ => CheckRemainDistance()),
                };
            });
    }
}