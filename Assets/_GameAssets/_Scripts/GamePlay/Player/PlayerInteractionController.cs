using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private PlayerController _playerController;
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)    //çarptığımız objenin ismini zaten other diye vermiş oyun bize 
    {
        if(other.gameObject.TryGetComponent<ICollectable>(out var collectable)) //interfacelere teker teker bakıyor en üstte ICollectible var mı diye bakıyor 
        {
            collectable.Collect();   // atıyorum mesela bir istrigger i ture olan bir objeye çarptık ama içinde ICollectible yok o yzaman bu bloğun içerisine girmicek       trygetcomponent'in normal getcomponentten farkı eğer ICollectible ı bulabilirse if döngüsüne girecek bulamazsa direkt buraya girmiyor 
           // bu sebeple null check yapmamıza da gerek kalmıyor
           // bir sürü if döngüsü yazmamıza gerek kalmadı temiz bir kod oldu 40234 tane wheat olsaydı hepsine if döngüsü açmak kirli bir kod olurdu
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent<IBoostable>(out var boostlable))
        {
            boostlable.Boost(_playerController);
        }
    }
}
