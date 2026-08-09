using UnityEngine;

public class HolyWheatCollectable : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _increaseJumpeForce;
    [SerializeField] private float _resetBoostDuration;
      public void Collect()
    {
        _playerController.SetJumpForce(_increaseJumpeForce,_resetBoostDuration);
        Destroy(gameObject);
    }
}


