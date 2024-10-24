using UnityEngine;

public class StickyFloor : MonoBehaviour
{
    public Transform m_transformToAttach;
    [SerializeField]
    private float m_inertiaThrust;
    private Transform m_originalParent = null;

    void Start()
    {
        if (m_transformToAttach == null)
            m_transformToAttach = transform;

    }

    void OnTriggerEnter(Collider other)
    {
        //TODO 1: Cuando el objeto que caiga sea attachable, atachamos el objeto.
        Attachable attachable = other.GetComponent<Attachable>();
        if (attachable != null && attachable.IsAttachable && !attachable.IsAttached)
        {
            m_originalParent = other.transform.parent;
            other.transform.SetParent(m_transformToAttach);
            attachable.IsAttached = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //TODO 2: Cuando el objeto que caiga sea attachable, como estamos saliendo, desatachamos el objeto. Ojo, la scala puede cambiar!!!
        Attachable attachable = other.GetComponent<Attachable>();
        if (attachable != null && attachable.IsAttached)
        {
            other.transform.SetParent(m_originalParent);
            attachable.IsAttached = false;
            MovingPlatform movingPlatform = gameObject.GetComponent<MovingPlatform>();
            other.attachedRigidbody.velocity += (movingPlatform.m_CurrentWaypoint.position - gameObject.transform.position).normalized * movingPlatform.m_MovementSpeed;
        }
    }
}
