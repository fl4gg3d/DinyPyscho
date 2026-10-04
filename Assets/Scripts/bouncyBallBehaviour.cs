using UnityEngine;

public class bouncyBallBehaviour : MonoBehaviour
{
    [Header("Velocidad de las bolas")]
    [SerializeField]
    private float _velocidadX = 3f;
    [SerializeField]
    private float _velocidadY = 5f;

    [SerializeField]
    private int _daño = 10;
    [SerializeField]
    private AudioClip _sonidoGolpe;
    private bool _yaGolpeo = false;
    [SerializeField]
    private float _volumen = 1f;

    private Rigidbody2D _rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        float dirX = -1f;
        _rigidbody.AddForce(new Vector2(dirX * _velocidadX, -_velocidadY), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si choca con el personaje, se destruye
        if (collision.CompareTag("Player") && !_yaGolpeo)
        {
            _yaGolpeo = true;

            UIManageer.instancia.PelotaGolpeo();

            // Obtener el script del player
            playerBehaviur player = collision.GetComponent<playerBehaviur>();

            if (player != null)
            {
                // Restar vida
                player.RestarVida(_daño);
            }

            // Reproducir sonido
            if (_sonidoGolpe != null)
            {
                AudioSource.PlayClipAtPoint(_sonidoGolpe, transform.position, _volumen);
            }
            Destroy(gameObject);
        }
    }
}
