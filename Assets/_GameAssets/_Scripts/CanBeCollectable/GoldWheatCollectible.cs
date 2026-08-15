using UnityEngine;

public class GoldWheatCollectable : MonoBehaviour,ICollectable
{
    [SerializeField] private WheatDesignSO _wheatDesignSO;      //bunu yaparak increasedecrase değerlerine projectten erişeceğiz
   [SerializeField] private PlayerController _playayerController;
   
   public void Collect()
    {
        _playayerController.SetMovementSpeed(_wheatDesignSO.IncreaseDrecreaseMultiplier,_wheatDesignSO.ResetBoostDuration);
        Destroy(gameObject);
    }
}
