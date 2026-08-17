using UnityEngine.UI;
using UnityEngine;


public class RottenWheatCollectable : MonoBehaviour,ICollectable
{
    [SerializeField] private WheatDesignSO _wheatDesignSO;
   [SerializeField] private PlayerController _playayerController;  
    [SerializeField] private PlayerStateUI _playerStateUI;
     private RectTransform _playerBoosterTransform;
     private Image _playerBoosterImage;
    void Awake()
    {
        _playerBoosterTransform = _playerStateUI.GetBoosterSlowTransform;
        _playerBoosterImage = _playerBoosterTransform.GetComponent<Image>();
    }
     
   public void Collect()
    {
        _playayerController.SetMovementSpeed(_wheatDesignSO.IncreaseDrecreaseMultiplier,_wheatDesignSO.ResetBoostDuration);
        _playerStateUI.PlayerBoosterUIAnimations(_playerBoosterTransform , _playerBoosterImage,
        _playerStateUI.GetRottenBoosterWheatImage, _wheatDesignSO.ActiveSprite, _wheatDesignSO.PassiveSprite , _wheatDesignSO.ActiveWheatSprite,_wheatDesignSO.PassiveWheatSprite,
        _wheatDesignSO.ResetBoostDuration);


        Destroy(gameObject);
    }
}
