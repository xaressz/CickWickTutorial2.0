using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class PlayerHealthUI : MonoBehaviour
{
  [SerializeField] private Image[] _playerHealthImages;
  [Header("Sprites")]
  [SerializeField] private Sprite _playerHealthySprite;
  [SerializeField] private Sprite _playerUnhealthySprite;
  [Header("Settings")]
  [SerializeField] private float _scaleDuration;

  private RectTransform[] _playerHealthTransform;

    private void Awake()
    {
        _playerHealthTransform = new RectTransform[_playerHealthImages.Length];

        for (int i = 0 ; i < _playerHealthImages.Length ; i++)
        {
           _playerHealthTransform[i] = _playerHealthImages[i].gameObject.GetComponent<RectTransform>();
        }
    }
    // FOR TESTİNG
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AnimateDamage();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            AnimateDamageForAll();
        }
    }
    public void AnimateDamage()
    {
        for (int i = 0 ; i<_playerHealthImages.Length; i++)
        {
            if (_playerHealthImages[i].sprite == _playerHealthySprite)
            {
                AnimateDamageSprite(_playerHealthImages[i] , _playerHealthTransform[i]);
                break;
            }
        }
    }
    
    public void AnimateDamageForAll()
    {
        for (int i = 0 ; i<_playerHealthImages.Length; i++)
        {
            AnimateDamageSprite(_playerHealthImages[i] , _playerHealthTransform[i]);
        }
    }


    private void AnimateDamageSprite(Image activeImage , RectTransform activeImageTransform)
    {
        activeImageTransform.DOScale(0f, _scaleDuration).SetEase(Ease.InBack).OnComplete(() =>   // buradaki syntax şunu diyor Oncomplete olduğunda aşağıdaki bloğu çalıştır oncomplete parnateizinin içine ayrı bir fonksiyon da yazabilirdik syntax tamamen
    // canımız gidince o scale i sıfırla sonra şu animasyonu yap =>
        {
            activeImage.sprite = _playerUnhealthySprite;
            activeImageTransform.DOScale(1f,_scaleDuration).SetEase(Ease.OutBack);

        });               
    }

}
