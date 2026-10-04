using Unity.VisualScripting;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    [Header("Bola con bote")]
    [SerializeField]
    private GameObject _bolaBota;
    
    [Header("Bola Normal")]
    [SerializeField]
    private GameObject _bolaNormal;

    [Header("Tiempo de Spawn Bouncy")]
    [SerializeField]
    private float _minBetweenSpawnBouncy = 1f;
    [SerializeField]
    private float _maxBetweenSpawnBouncy = 3f;
    private float _betweenSpawnBouncy;
    private float _timeToSpawnBouncy;

    [Header("Tiempo de Spawn Normal")]
    [SerializeField]
    private float _minBetweenSpawnNormal = 1f;
    [SerializeField]
    private float _maxBetweenSpawnNormal = 2f;
    private float _betweenSpawnNormal;
    private float _timeToSpawnNormal;

    [Header("Altura de Spawn")]
    [SerializeField]
    private float _alturaMaxima = 5f;
    [SerializeField]
    private float _alturaMinima = 2f;
    private float _alturaBase;

    void Start()
    {
        _betweenSpawnBouncy = Random.Range(_minBetweenSpawnBouncy, _maxBetweenSpawnBouncy);
        _betweenSpawnNormal = Random.Range(_minBetweenSpawnNormal, _maxBetweenSpawnNormal);
    }

    void Update()
    {
        // Timer para Bouncy
        _timeToSpawnBouncy += Time.deltaTime;
        if (_timeToSpawnBouncy >= _betweenSpawnBouncy)
        {
            _timeToSpawnBouncy -= _betweenSpawnBouncy;
            SpawnBolaBouncy();
            _betweenSpawnBouncy = Random.Range(_minBetweenSpawnBouncy, _maxBetweenSpawnBouncy);
        }

        // Timer para Normal
        _timeToSpawnNormal += Time.deltaTime;
        if (_timeToSpawnNormal >= _betweenSpawnNormal)
        {
            _timeToSpawnNormal -= _betweenSpawnNormal;
            SpawnBola();
            _betweenSpawnNormal = Random.Range(_minBetweenSpawnNormal, _maxBetweenSpawnNormal);
        }
    }

    void SpawnBolaBouncy()
    {
        _alturaBase = Random.Range(_alturaMinima, _alturaMaxima);
        GameObject bolaInstanciada = Instantiate(_bolaBota);
        bolaInstanciada.transform.position = new Vector2(
            16f,
            _alturaBase
        );
    }

      void SpawnBola()
    {
        GameObject bolaInstanciada = Instantiate(_bolaNormal);
        bolaInstanciada.transform.position = new Vector2(
            16f,
            _alturaBase = -2f
        );
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
