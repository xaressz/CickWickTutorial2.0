using UnityEngine;

public class RottenWheatCollectable : MonoBehaviour,ICollectable
{
    [SerializeField] private WheatDesignSO _wheatDesignSO;
   [SerializeField] private PlayerController _playayerController;  
   public void Collect()
    {
        _playayerController.SetMovementSpeed(_wheatDesignSO.IncreaseDrecreaseMultiplier,_wheatDesignSO.ResetBoostDuration);
        Destroy(gameObject);
    }
}
