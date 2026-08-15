using UnityEngine;

public class SpatulaBooster : MonoBehaviour, IBoostable
{
  [Header("References")]
  [SerializeField] Animator _spatulaAnimator;
  [Header("Settings")]
  [SerializeField] private float _jumpForce;
  private bool _isActived;

    public void Boost(PlayerController playerController)
    {
      if (_isActived) { return; }
      Rigidbody playerRigidbody = playerController.GetPlayerRigidbody();
      playerRigidbody.linearVelocity = new Vector3(playerRigidbody.linearVelocity.x,0f,playerRigidbody.linearVelocity.z);
      playerRigidbody.AddForce(transform.up * _jumpForce ,ForceMode.Impulse);
      _isActived = true;
      Invoke(nameof(ResetActivation),0.2f);
    }
    private void PlayBoostAnimation()
  {
    _spatulaAnimator.SetTrigger(Consts.OtherAnimation.IS_SPATULA_JUMPING);
  } 
    private void ResetActivation()
  {
    _isActived = false;
  }
}
