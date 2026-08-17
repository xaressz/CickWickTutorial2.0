using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PlayerStateUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private RectTransform _playerWalkingTrasnform;
    [SerializeField] private RectTransform _playerSlidingTransform;
    [SerializeField] private RectTransform _boosterSpeedTransform;
    [SerializeField] private RectTransform _boosterJumpTransform;
    [SerializeField] private RectTransform _boosterSlowTransform;
    
     [Header("Imagees")]
     [SerializeField] private Image _goldBoosterWheatImage;
     [SerializeField] private Image _holyBoosterWheatImage;
     [SerializeField] private Image _rottenBoosterWheatImage;


    [Header("Sprites")]
    [SerializeField] private Sprite _playerWalkingActiveSprite;
     [SerializeField] private Sprite _playerWalkingPassiveSprite;
     [SerializeField] private Sprite _playerSlidingActiveSprite;
     [SerializeField] private Sprite _playerSlidingPassiveSprite;

     [Header("Settings")]
      [SerializeField] private float _moveDuration;
      [SerializeField] private Ease _moveEase;


     public RectTransform GetBoosterSpeedTransform => _boosterSpeedTransform;
     public RectTransform GetBoosterJumpTransform => _boosterJumpTransform;              // encapsulation yaptık direkt public yapmadık bunları collectible a bu verileri göndereceğiz 
     public RectTransform GetBoosterSlowTransform => _boosterSlowTransform;                // public olduğu için 
     public Image GetGoldBoosterWheatImage => _goldBoosterWheatImage;
     public Image GetHolyBoosterWheatImage => _holyBoosterWheatImage;          // YARDIMCI DEĞİŞKENLER COLLECTABLELAR İÇİN
     public Image GetRottenBoosterWheatImage => _rottenBoosterWheatImage;
     
     private Image _playerWalkingImage;
     private Image _playerSlidingImage;

    void Awake()
    {
        _playerWalkingImage = _playerWalkingTrasnform.GetComponent<Image>();
         _playerSlidingImage = _playerSlidingTransform.GetComponent<Image>();
    }

    private void Start()
    {
        _playerController.OnplayerStateChange += PlayerController_OnPlayerStateChanged;
        SetStateUserInterfaces(_playerWalkingActiveSprite,_playerSlidingPassiveSprite,_playerWalkingTrasnform,_playerSlidingTransform);
    }
    private void PlayerController_OnPlayerStateChanged(PlayerState playerState)
    {
        switch(playerState)
        {
            case PlayerState.Idle:
            case PlayerState.Move:
            //ÜSTTEKİ KART AÇILACAK
                 SetStateUserInterfaces(_playerWalkingActiveSprite,_playerSlidingPassiveSprite,_playerWalkingTrasnform,_playerSlidingTransform);
            break;

            case PlayerState.SlideIdle:
            case PlayerState.Slide:
            // ALTTAKİ KART AÇILACAK
              SetStateUserInterfaces(_playerWalkingPassiveSprite,_playerSlidingActiveSprite,_playerSlidingTransform,_playerWalkingTrasnform);
              break;
        }
        
    }
    private void SetStateUserInterfaces(Sprite playerWalkingSprite, Sprite playerSlidingSprite,
    RectTransform activeTransform, RectTransform passiveTransform)
    {
        _playerWalkingImage.sprite = playerWalkingSprite;
        _playerSlidingImage.sprite = playerSlidingSprite;
        
        activeTransform.DOAnchorPosX(-25f, _moveDuration).SetEase(_moveEase);
        passiveTransform.DOAnchorPosX(-90f, _moveDuration).SetEase(_moveEase);
    }
    private IEnumerator SetBoosterUserInterface(RectTransform activeTransform , Image boosterImage,
            Image wheatImage , Sprite activeSprite , Sprite passiveSprite , Sprite activeWheatSprite,
            Sprite passiveWheatSprite, float duration)
    {
        boosterImage.sprite = activeSprite;
        wheatImage.sprite = activeWheatSprite;
        
        activeTransform.DOAnchorPosX(-25f,_moveDuration).SetEase(_moveEase);

        yield return new WaitForSeconds(duration);

        boosterImage.sprite = passiveSprite;
        wheatImage.sprite = passiveWheatSprite;
        
        activeTransform.DOAnchorPosX(90f,_moveDuration).SetEase(_moveEase);
    }

    public void PlayerBoosterUIAnimations(RectTransform activeTransform , Image boosterImage,
            Image wheatImage , Sprite activeSprite , Sprite passiveSprite , Sprite activeWheatSprite,
            Sprite passiveWheatSprite, float duration)
    {
        StartCoroutine(SetBoosterUserInterface(activeTransform,boosterImage,wheatImage,activeSprite,passiveSprite,
        activeWheatSprite,passiveWheatSprite,duration));
    }


}
