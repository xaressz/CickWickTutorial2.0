using UnityEngine;

public class HolyWheatCollectable : MonoBehaviour,ICollectable
{
    [SerializeField] private WheatDesignSO _wheatDesignSO;
    [SerializeField] private PlayerController _playerController;
  
      public void Collect()
    {
        _playerController.SetJumpForce(_wheatDesignSO.IncreaseDrecreaseMultiplier,_wheatDesignSO.ResetBoostDuration);
        Destroy(gameObject);
    }
}


