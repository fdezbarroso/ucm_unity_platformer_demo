using UnityEngine;

public class DeathScript : MonoBehaviour
{
    /// <summary>
    /// Game Manager para hacer respawn del jugador
    /// </summary>
    private GameManager m_GameManager = null;

    /// <summary>
    /// En la funci�n Start hacemos una b�squeda del GameManager
    /// </summary>
    void Start()
    {

        // TODO 1 - Buscamos un GameObject cuyo tag sea "GameManager"
        m_GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }


    /// <summary>
    /// Si algo choca contra nosotros, comprobaremos si es el player
    /// </summary>
    /// <param name="other">
    /// Objeto que ha entrado en el trigger <see cref="Collider"/>
    /// </param>
    void OnTriggerEnter(Collider other)
    {
        // TODO 2 - Comprobamos que el transform del objeto que colisiona, es el player
        if (other.CompareTag("Player"))
        {
            // TODO 3 - Enviamos un mensaje al GameManager llamando a la funci�n "RespawnPlayer"
            if (m_GameManager != null)
            {
                m_GameManager.GetComponent<GameManager>().RespawnPlayer();
            }
        }
    }
}