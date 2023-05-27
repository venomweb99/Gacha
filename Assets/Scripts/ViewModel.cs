using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewModel : MonoBehaviour
{
    public GameObject m_PlayerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // Instanciar el prefab del jugador en el canvas
        GameObject jugador = Instantiate(m_PlayerPrefab, transform);

        // Asegurarse de que el objeto del jugador esté configurado correctamente en el canvas
        jugador.transform.SetParent(transform, false);
        jugador.transform.localPosition = Vector3.zero;
    }
}
