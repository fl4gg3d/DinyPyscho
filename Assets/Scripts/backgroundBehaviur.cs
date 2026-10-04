using UnityEngine;
using UnityEngine.UI;

public class backgroundBehaviur : MonoBehaviour
{
    // Referencia al componente RawImage
    private RawImage rawImage;

    // Velocidad a la que se mueve el fondo (ajusta según necesites)
    public float velocidadDesplazamiento = 0.5f;

    // Variable para rastrear el desplazamiento
    private Vector2 desplazamiento = Vector2.zero;

    void Start()
    {
        // Obtener el componente RawImage que está en este GameObject
        rawImage = GetComponent<RawImage>();

        // Inicializar en posición 0
        desplazamiento = Vector2.zero;
    }

    void Update()
    {
        // Aumentar el desplazamiento cada frame
        desplazamiento.x += velocidadDesplazamiento * Time.deltaTime;

        // AQUÍ ES LA MAGIA: % 1f hace que cuando llegue a 1, vuelva a 0
        // Por ejemplo: 1.5 % 1f = 0.5 | 2.3 % 1f = 0.3 | 5.8 % 1f = 0.8
        desplazamiento.x = desplazamiento.x % 1f;

        // Aplicar el desplazamiento a la textura
        // Rect(posición.x, posición.y, ancho, alto)
        rawImage.uvRect = new Rect(desplazamiento.x, 0, 1, 1);
    }
}
