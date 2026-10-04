using UnityEngine;
using UnityEngine.InputSystem;


public class playerBehaviur : MonoBehaviour
{
    [Header("Input Basic")]
    [SerializeField]
    private InputActionReference _jumpInputRef;
    [SerializeField]
    private InputActionReference _downInputRef;
    private bool _inFloor;
    private Rigidbody2D _rigidBody2D;

    [Header("Stats MC")]
    [SerializeField]
    private int _HP = 100;
    [SerializeField]
    private float _baseDown = 10f;
    private float _baseJump = 10f;
    
    
    [Header("Curacion")]
    [SerializeField]
    private int _curacionCada10s = 20;
    private float _tiempoParaCuracion = 10f;


    [Header("Sonidos")]
    [SerializeField]
    private AudioClip _sonidoSalto;
    private AudioSource _audioSourceSalto;

    private Animator _animator;

    private void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _audioSourceSalto = GetComponent<AudioSource>();
        }

    private void OnEnable()
    {
        _jumpInputRef.action.performed += Jump;
        _downInputRef.action.performed += MoveDown;
    }
    void OnDisable()
    {
        _jumpInputRef.action.performed -= Jump;
        _downInputRef.action.performed -= MoveDown;
    }

    // Update is called once per frame
    


    private void Jump(InputAction.CallbackContext context)
    {
        if (_inFloor)
        {
            _rigidBody2D.AddForce(Vector2.up.normalized * _baseJump, ForceMode2D.Impulse);
            if (_animator != null)
            {
                _animator.SetBool("Saltando", true);
            }
            if (_audioSourceSalto != null && _sonidoSalto != null)
            {
                _audioSourceSalto.PlayOneShot(_sonidoSalto);
            }
        }
    }

    private void MoveDown(InputAction.CallbackContext context)
    {
        _rigidBody2D.AddForce(Vector2.down.normalized * _baseDown, ForceMode2D.Impulse);
    }

    public void RestarVida(int daño)
    {
        _HP -= daño;
        Debug.Log("¡Golpeado! Vida restante: " + _HP);

        // Si la vida llega a 0
        if (_HP <= 0)
        {
           

            // ← CERRAR EL JUEGO
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
        {
            _inFloor = true;
            if (_animator != null)
            {
                _animator.SetBool("Saltando", false);
                _animator.Rebind();
            }
            if (_audioSourceSalto != null && _audioSourceSalto.isPlaying)
            {
                _audioSourceSalto.Stop();
            }
    }
        private void OnCollisionExit2D(Collision2D collision)
        {
            _inFloor = false;
        }

    private void Curarse(int cantidad)
    {
        _HP += cantidad;

        if (_HP > 100)
            _HP = 100;

        Debug.Log("¡Curación! Vida: " + _HP);
    }

    void Update()
    {
        //RECUPERAR VIDA CADA 10 SEGUNDOS
        _tiempoParaCuracion -= Time.deltaTime;

        if (_tiempoParaCuracion <= 0)
        {
            Curarse(_curacionCada10s);
            _tiempoParaCuracion = 10f; //REINICIA
        }
    }
}

