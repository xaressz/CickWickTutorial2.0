using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private GoldWheatCollectable _goldWheatCollectable;
    [SerializeField] private HolyWheatCollectable _holyWheatCollectable;
    [SerializeField] private RottenWheatCollectable _rottenWheatCollectable;
     private void OnTriggerEnter(Collider other)    //çarptığımız objenin ismini zaten other diye vermiş oyun bize
    {
        if(other.CompareTag(Consts.WheatTypes.GOLD_WHEAT))          // eğer ki bu if bloğu true dönerse yani triggerlandıysa bu tagli object o zaman bloğun içindekileri yap 
        {
            _goldWheatCollectable.Collect();
        }
        if(other.CompareTag(Consts.WheatTypes.HOLY_WHEAT))
        {
            _holyWheatCollectable.Collect();
        }
        if(other.CompareTag(Consts.WheatTypes.ROTTEN_WHEAT))
        {
            _rottenWheatCollectable.Collect();
        }
    }
}
