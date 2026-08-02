using System;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public event Action OnPlayerJumped;    //bu eventi oyunda bir yerde triggerlıyorum bu oyunda jump oluyor bu farklı bir yerlerden bunu çağırıp (bu yüzden public yaptık) bu event triggerlandığında şunu yap dicez
                                           // eventler genelde On ile başlar 
    [Header("References")]
    [SerializeField] private Transform _orientationTransform;
    [Header("Movement Settings")]
    [SerializeField] KeyCode _movementKey;
   [SerializeField] private float _movementSpeed;
   [Header("Jump Settings")]
   [SerializeField] private KeyCode _jumpKey;
   [SerializeField] private float _jumpForce;
   [SerializeField] private float _jumpCooldown;
   [SerializeField] private bool _canJump =false;
   [SerializeField] private float _airMultiplier;
   [SerializeField] private float _airDrag;
   [Header("Ground Check Settings")]
   [SerializeField] private float _playerHeight;
   [SerializeField] private LayerMask _groundLayer;
   [SerializeField] private float _groundDrag;
   [Header("Slide Settings")]
   [SerializeField] private KeyCode _slideKey;
   [SerializeField] private float _slideMultiplier; 
   [SerializeField] private bool _isSliding;      // false şu anda bir atama yapmadığımız için
   [SerializeField] private float _slideDrag;


  private StateController _stateController;
  private Rigidbody _playerRigidbody;
  private float _horizontalInput, _verticalInput;
  private Vector3 _movementDirection;

    private void Awake()
    {
        _stateController = GetComponent<StateController>();
        _playerRigidbody = GetComponent<Rigidbody>();
        _playerRigidbody.freezeRotation = true;
    }
    private void Update()
    {
        SetInputs();
        SetStates();
        SetPlayerDrag();
        LimitPlayerSpeed();
    }
    private void FixedUpdate()
    {
        SetPlayerMovement();
    }

    private void SetInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(_slideKey))
        {
            _isSliding = true;
        }
        else if (Input.GetKeyDown(_movementKey))
        {
            _isSliding = false;
        }
        else if (Input.GetKeyDown(_jumpKey) && _canJump && IsGrounded())
        {
          _canJump = false;
          Invoke(nameof(ResetJumping) , _jumpCooldown);   // belli bir süre sonra yap fonksiyonu süre geçmediyse yapma
          SetPlayerJumping();
        }

    }
    private void SetStates()
    {
       var movementDirection =GetMovemetDirection();  // movement directionun normalized değerini alıyoruz
        // in line yani bu line da yeni tanıdığımız bir değişkeni kendin tanı demek var oraya vector 3 yazmakla hiç bir farkı yok bilgisayar veriable ı kendisi tanıyor
       var isGrounded = IsGrounded();
       var isSliding = IsSliding();  // kod temizliği için yaptık 
       
       var currentState = _stateController.GetCurrentState();
       var newState = currentState switch
       {
          _  when movementDirection == Vector3.zero && isGrounded && !isSliding => PlayerState.Idle,
          _  when movementDirection != Vector3.zero && isGrounded && !isSliding => PlayerState.Move,
          _  when movementDirection != Vector3.zero && isGrounded && isSliding => PlayerState.Slide,
          _  when movementDirection == Vector3.zero && isGrounded && isSliding => PlayerState.SlideIdle,
          _  when !_canJump && !isGrounded => PlayerState.Jump,
          _  => currentState
       }; 
       if (newState != currentState)
        {
            _stateController.ChangeState(newState);
        }
        Debug.Log(newState);
    }


    
    private void SetPlayerMovement()
    {
        _movementDirection = _orientationTransform.forward * _verticalInput
        +_orientationTransform.right * _horizontalInput;

        float forceMultiplier = _stateController.GetCurrentState() switch
        {
           PlayerState.Move => 1f,
           PlayerState.Slide => _slideMultiplier,
           PlayerState.Jump  =>  _airMultiplier,
          _ => 1f  
        };
        _playerRigidbody.AddForce(_movementDirection.normalized * _movementSpeed * forceMultiplier , ForceMode.Force);
    }
    private void SetPlayerDrag()
    {
       _playerRigidbody.linearDamping = _stateController.GetCurrentState() switch
       {
          PlayerState.Move => _groundDrag,
          PlayerState.Slide => _slideDrag,
          PlayerState.Jump => _airDrag,
          _ => _playerRigidbody.linearDamping  
       }; 
    }
    private void LimitPlayerSpeed() 
    {
       Vector3 flatVelocity = new Vector3(_playerRigidbody.linearVelocity.x , 0f , _playerRigidbody.linearVelocity.z);

       if (flatVelocity.magnitude > _movementSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * _movementSpeed;
            _playerRigidbody.linearVelocity = new Vector3(limitedVelocity.x , _playerRigidbody.linearVelocity.y , limitedVelocity.z);
        }
    }
    private void SetPlayerJumping()
    {
        if(OnPlayerJumped != null)
        {
            OnPlayerJumped.Invoke();        // eventi tetikledik burada
        }
        _playerRigidbody.linearVelocity = new Vector3 (_playerRigidbody.linearVelocity.x , 0f, _playerRigidbody.linearVelocity.z);
        _playerRigidbody.AddForce(transform.up*_jumpForce,ForceMode.Impulse);
    }
    private void ResetJumping()
    {
        _canJump=true;
    }
    private bool IsGrounded()  // bu fonksiyon zemine bir ışın (_playerHeight * 0.5f + 0.2f bu büyüklükte) (deneyerek bulunmul büyüklük)  fırlatıyor ve yerde olup olmadığını kontrol ediyor bu ışın
    // yere değdiği zaman karakter zıplayabilir konumda oluyor eğer ki bu ışın yere değmiyorsa karakter havadadır zıplayamaz
    {
       return Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f , _groundLayer);
    }
    private Vector3 GetMovemetDirection()
    {
        return _movementDirection.normalized;
    }
    private bool IsSliding()
    {
        return _isSliding;
    }
}
