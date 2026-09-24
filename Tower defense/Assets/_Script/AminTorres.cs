using System;
using System.Collections.Generic;
using UnityEngine;

public class AminTorres : MonoBehaviour
{
    public AdminToques  RefAdminToques;
    public enum TorreSeleccionada
    {
        torre1, torre2, torre3, torre4, torre5
    }
    public TorreSeleccionada torreSeleccionada;
    public List<GameObject> PrefabsTorre;

    private void OnEnable()
    {
        RefAdminToques.enPlataformaTocada += CrearTorre;
    }
    private void OnDisable()
    {
        RefAdminToques.enPlataformaTocada -= CrearTorre;
    }
    private void CrearTorre(GameObject plataforma)
    {
        if (plataforma.transform.childCount == 0)
        {
            int indiceTorre = (int)torreSeleccionada;
            Vector3 posParaInstanciar = plataforma.transform.position;
            posParaInstanciar.y += 1f;
            GameObject torreInstanciada = Instantiate<GameObject>(PrefabsTorre[indiceTorre], posParaInstanciar, Quaternion.identity);
            torreInstanciada.transform.SetParent(plataforma.transform);
        }
    }

    public void ConfigurarTorre(int torre)
    {
        if (Enum.IsDefined(typeof(TorreSeleccionada), torre))
        {
            torreSeleccionada = (TorreSeleccionada)torre;
        }
    }
}
