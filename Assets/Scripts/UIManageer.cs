using TMPro;
using UnityEngine;

public class UIManageer : MonoBehaviour
{

    public static UIManageer instancia;
    [SerializeField]
    private TextMeshProUGUI _textoPelotas;
    [SerializeField]
    private TextMeshProUGUI _textoTiempo;

    private int _pelotasGolpe = 0;
    private float _tiempoTranscurrido = 0f;


    private void Awake()
    {
        instancia = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _tiempoTranscurrido += Time.deltaTime;
        if (_textoPelotas != null)
        {
            _textoPelotas.text = "Hits recibidos: " + _pelotasGolpe;
        }
        if (_textoTiempo != null)
        {
            int segundos = (int)_tiempoTranscurrido;
            _textoTiempo.text = "Tiempo: " + segundos + "s";
        }
    }

    public void PelotaGolpeo()
    {
        _pelotasGolpe++;
    }
}
