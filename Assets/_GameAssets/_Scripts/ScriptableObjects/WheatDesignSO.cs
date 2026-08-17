using UnityEngine;

[CreateAssetMenu(fileName ="WheatDesignSO", menuName ="ScriptableObjects/WheatDesignSO")]
public class WheatDesignSO : ScriptableObject
{
    [SerializeField] private float _increaseDecreaseMultiplier;
    [SerializeField] private float __resetBoostDuration;
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Sprite _passiveSprite;
    [SerializeField] private Sprite _activeWheatSprite;
    [SerializeField] private Sprite _passiveWheatSprite;

    public float IncreaseDrecreaseMultiplier => _increaseDecreaseMultiplier;
    public float ResetBoostDuration => __resetBoostDuration;       // public bırakmak istemeyiz direkt multiplier ve duration u o yüzden yeni bir obje oluşturup değerlerini atadık

    public Sprite ActiveSprite => _activeSprite;
    public Sprite PassiveSprite => _passiveSprite;
    public Sprite ActiveWheatSprite => _activeWheatSprite;
    public Sprite PassiveWheatSprite => _passiveWheatSprite;
}
