using UnityEngine;

public class GoldWheatCollectable : MonoBehaviour
{
   [SerializeField] private PlayerController _playayerController;
   [SerializeField] private float _movemetIncreaseSpeed;
   [SerializeField] private float _resetBoostDuration;
   
   
   public void Collect()
    {
        _playayerController.SetMovementSpeed(_movemetIncreaseSpeed,_resetBoostDuration);
        Destroy(gameObject);
    }
}
