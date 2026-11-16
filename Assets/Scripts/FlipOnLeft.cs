using UnityEngine;

[RequireComponent(typeof(ParticleSystemRenderer))]
public class FlipOnLeft : MonoBehaviour
{
    public void SetFlipped(bool flipped)
    {
        var psr = GetComponent<ParticleSystemRenderer>();
        psr.flip = new Vector3(flipped ? 1f : 0f, psr.flip.y, psr.flip.z);
    }
}