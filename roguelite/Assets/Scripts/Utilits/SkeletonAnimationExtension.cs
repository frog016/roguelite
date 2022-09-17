using Spine.Unity;

public static class SkeletonAnimationExtension
{
    public static void ReloadAsset(this SkeletonAnimation skeletonAnimation)
    {
        var skeletonDataAsset = skeletonAnimation.SkeletonDataAsset;
        if (skeletonDataAsset != null)
        {
            foreach (var atlasAssetBase in skeletonDataAsset.atlasAssets)
            {
                if (atlasAssetBase != null)
                    atlasAssetBase.Clear();
            }
            skeletonDataAsset.Clear();
        }

        skeletonDataAsset?.GetSkeletonData(true);
        ReinitializeComponent(skeletonAnimation);
    }

    public static void ReinitializeComponent(this SkeletonRenderer component)
    {
        if (component == null) return;
        if (!SkeletonDataAssetIsValid(component.SkeletonDataAsset)) return;

        var stateComponent = component as IAnimationStateComponent;
        Spine.AnimationState oldAnimationState = null;

        if (stateComponent != null)
            oldAnimationState = stateComponent.AnimationState;

        component.Initialize(true);
        if (oldAnimationState != null)
            stateComponent.AnimationState.AssignEventSubscribersFrom(oldAnimationState);

        component.LateUpdate();
    }

    private static bool SkeletonDataAssetIsValid(SkeletonDataAsset asset)
    {
        return asset != null && asset.GetSkeletonData(quiet: true) != null;
    }
}
