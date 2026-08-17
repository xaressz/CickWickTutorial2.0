using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    
    private void Damage (int damageAmount)
    {
        if(_currentHealth > 0)
        {
             _currentHealth =- damageAmount;
             // TODO: UI ANIMATE DAMAGE
             if(_currentHealth <= 0 )
            {
                // TODO : PLAYER DEAD
            }
        }
         
    }
    public void Heal(int healAmount)
    {
        if(_currentHealth < _maxHealth)
        {
            _currentHealth = Mathf.Min(_currentHealth + healAmount , _maxHealth);   // bu satırda hangisi en küçük değerse onu alıyor yani bir kez daha 3 ü geçmeme kontrolü yaptık
        }
        
    }

}
