using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform m_Target;

    void Update()
    {
        transform.LookAt(m_Target);
    }
}
