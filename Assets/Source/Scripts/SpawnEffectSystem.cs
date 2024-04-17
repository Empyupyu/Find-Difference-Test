using Supyrb;
using UnityEngine;

public class SpawnEffectSystem : GameSystem
{
    public override void OnStart()
    {
        Signals.Get<SpawnEffectSignal>().AddListener(SpawnEffects);
    }

    private void SpawnEffects(DifferenceObject differenceObject)
    {
        var effect = Spawn();
        effect.transform.parent = _gameData.Level.OriginScreen.transform;
        effect.transform.localPosition = differenceObject.transform.localPosition;

        effect = Spawn();
        effect.transform.position = differenceObject.transform.position;
    }

    //Можно применить паттенр object pool, для лучший оптимизации и кэширования эффектов в памяти
    //Решил не применять в рамках этого задания, так как количество обращений к этому классу очень редкое
    private ParticleSystem Spawn()
    {
        return Instantiate(_configData.FindObjectEffect);
    }
}
