using UnityEngine;

[CreateAssetMenu(fileName = "ConfigData", menuName = "Datas/Config Data")]
public sealed class ConfigData : ScriptableObject
{
    [field: SerializeField] public ParticleSystem FindObjectEffect { get; private set; }

    [field: SerializeField] public float LevelTimer { get; private set; }

}
