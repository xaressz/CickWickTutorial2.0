using UnityEngine;

[CreateAssetMenu(fileName ="WheatDesignSO", menuName ="ScriptableObjects/WheatDesignSO")]
public class WheatDesignSO : ScriptableObject
{
    [SerializeField] private float _increaseDecreaseMultiplier;
    [SerializeField] private float __resetBoostDuration;

    public float IncreaseDrecreaseMultiplier => _increaseDecreaseMultiplier;
    public float ResetBoostDuration => __resetBoostDuration;       // public bırakmak istemeyiz direkt multiplier ve duration u o yüzden yeni bir obje oluşturup değerlerini atadık
}
