using UnityEngine.UI;
using UnityEngine;

public class GoldWheatCollectable : MonoBehaviour,ICollectable
{
    [SerializeField] private WheatDesignSO _wheatDesignSO;      //bunu yaparak increasedecrase değerlerine projectten erişeceğiz
   [SerializeField] private PlayerController _playayerController;
   [SerializeField] private PlayerStateUI _playerStateUI;

   private RectTransform _playerBoosterTransform;
   private Image _playerBoosterImage;
    void Awake()
    {
        _playerBoosterTransform = _playerStateUI.GetBoosterSpeedTransform;
        _playerBoosterImage = _playerBoosterTransform.GetComponent<Image>();
    }


    public void Collect()
    {
        _playayerController.SetMovementSpeed(_wheatDesignSO.IncreaseDrecreaseMultiplier,_wheatDesignSO.ResetBoostDuration);

        _playerStateUI.PlayerBoosterUIAnimations(_playerBoosterTransform , _playerBoosterImage,
        _playerStateUI.GetGoldBoosterWheatImage, _wheatDesignSO.ActiveSprite, _wheatDesignSO.PassiveSprite , _wheatDesignSO.ActiveWheatSprite,_wheatDesignSO.PassiveWheatSprite,
        _wheatDesignSO.ResetBoostDuration);
 

        Destroy(gameObject);
    }
}
