using UnityEngine;

[CreateAssetMenu(fileName = "CampfireUpgradeData", menuName = "Scriptable Objects/CampfireUpgradeData")]
public class CampfireUpgradeData : ScriptableObject
{
    public AnimationCurve rangeCurve = new AnimationCurve(
        new Keyframe(0f, 110f),
        new Keyframe(0.33f, 145f),
        new Keyframe(0.66f,180f),
        new Keyframe(1f, 220f)
        );
    public AnimationCurve intensityCurve = new AnimationCurve(
        new Keyframe(0f, 1f),
        new Keyframe(0.33f, 1.3f),
        new Keyframe(0.66f, 1.7f),
        new Keyframe(1f, 2.2f)
        );
    public int maxTier = 3;
}
