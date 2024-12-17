using UnityEngine;

public class TriggerLoadAdditive : MonoBehaviour
{
    // TODO 1 - A�adir variable p�blica con el color de la puerta (tipo GameManager.DoorColor)
    [SerializeField]
    private GameManager.DoorColor m_color = GameManager.DoorColor.GREEN;
    /// <summary>
    /// La comprobaci�n del tipo de gameobject que entra en el trigger se hace por tag
    /// El valor del tag que nos interesa se guarda en esta variable
    /// </summary>
    private const string m_PlayerTag = "Player";
    private GameManager m_GameManager = null;

    private void Start()
    {
        m_GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// Detecta cu�ndo un GameObject entra en el trigger al cual est� asignado este componente.
    /// En nuestro caso, realizamos la carga aditiva del nivel indicado en el atributo
    /// p�blico "LevelToLoadName"
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        LoadLevelAdditive(other.gameObject);
        gameObject.SetActive(false);
    }


    // TODO 2 - Hacer funci�n que cargue un nivel de forma aditiva.
    // Ser� necesario pasarle el gameObject que ha colisionado con el trigger
    // Tras cargar el nivel, desactivamos el trigger
    private void LoadLevelAdditive(GameObject go)
    {
        if (m_GameManager != null)
        {
            m_GameManager.TriggerLoadAdditive(m_color);
            Destroy(gameObject);
        }
    }
}