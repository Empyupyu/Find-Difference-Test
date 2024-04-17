using Supyrb;
using UnityEngine;

public class SpawnEffectSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem _findObjectEffect;

    private void Start()
    {
        Signals.Get<SpawnEffectSignal>().AddListener(SpawnEffects);
    }

    private void SpawnEffects(DifferenceObject differenceObject)
    {
        var effect = Spawn();
        effect.transform.parent = FindAnyObjectByType<Level>().OriginScreen.transform;
        effect.transform.localPosition = differenceObject.transform.localPosition;

        effect = Spawn();
        effect.transform.position = differenceObject.transform.position;
    }

    private ParticleSystem Spawn()
    {
        return Instantiate(_findObjectEffect);
    }
}
