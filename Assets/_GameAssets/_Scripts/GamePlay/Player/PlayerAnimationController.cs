using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
   [SerializeField] private Animator _playerAnimator;

   private PlayerController _playerController;
   private StateController  _stateController;
    void Start()
    {
        _playerController.OnPlayerJumped += PlayerController_OnPlayerJumped;
    }

    
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _stateController = GetComponent <StateController>();
    }
    void Update()
    {
        SetPlayerAnimations();
    }
    private void PlayerController_OnPlayerJumped()
    {
       _playerAnimator.SetBool(Consts.PlayerAnimations.IS_JUMPING,true);
        Invoke(nameof(ResetJumping),0.5f);
    }
    private void ResetJumping()
    {
        _playerAnimator.SetBool(Consts.PlayerAnimations.IS_JUMPING,false);        
    }


    private void SetPlayerAnimations()
    {
        var currentState = _stateController.GetCurrentState();

        switch(currentState)
        {
           case PlayerState.Idle:
                 _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING,false); // buradaki amaç _playerAnimator gidiyor oradaki değerleri değitşriyor eğer mesela move ve slide
                 _playerAnimator.SetBool(Consts.PlayerAnimations.IS_MOVING,false);  // aktif değilse ıdle animasyonudur diyor ıdle animasyonu çalışyıro 
           break;                                                                   // buradaki animasyonlar bool türünde olışturulduğu için de setbool kullanıyoruz
           
           case PlayerState.Move:
                 _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING,false);
                 _playerAnimator.SetBool(Consts.PlayerAnimations.IS_MOVING,true);           
              break;
            case PlayerState.SlideIdle:
                 _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING,true);
                 _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING_ACTIVE,false);           
              break;
            case PlayerState.Slide:
                 _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING,true);
                 _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING_ACTIVE,true);           
              break;
        }
    }
}
