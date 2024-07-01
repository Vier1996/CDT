using System;
using System.Collections.Generic;
using InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes.Relaxing.ChillingsBehaviors;
using InternalAssets.Codebase.Library.Random;

namespace InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes.Relaxing
{
    public static class RelaxingTools
    {
        public static Type RandomChillingSubBehavior => _randomChillingBehaviorSubTypes.Random();
        
        private static List<Type> _randomChillingBehaviorSubTypes = new List<Type>()
        {
            typeof(CatInPlaceSittingSubBehavior),
            typeof(CatAimDownSubBehavior),
            typeof(CatEdgeLookingSubBehavior),
            typeof(CatInclineSubBehavior),
            typeof(CatInclineSideSubBehavior),
            typeof(CatLieSubBehavior),
            typeof(CatLookDownSubBehavior),
            typeof(CatLookForwardSubBehavior),
            typeof(CatPetSitSubBehavior),
            typeof(CatPetSubBehavior),
            typeof(CatWashingSubBehavior),
            typeof(CatYawnSubBehavior),
            typeof(CatStretchingSubBehavior),
        };
    }
}
