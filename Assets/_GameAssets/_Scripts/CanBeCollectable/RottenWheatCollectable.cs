using UnityEngine;

public class RottenWheatCollectable : MonoBehaviour
{
   [SerializeField] private PlayerController _playayerController;
   [SerializeField] private float _movemetDecreaseSpeed;
   [SerializeField] private float _resetBoostDuration;
   
   
   public void Collect()
    {
        _playayerController.SetMovementSpeed(_movemetDecreaseSpeed,_resetBoostDuration);
        Destroy(gameObject);
    }
}
