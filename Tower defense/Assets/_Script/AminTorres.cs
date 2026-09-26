using System;
using System.Collections.Generic;
using UnityEngine;

public class AminTorres : MonoBehaviour
{
    public AdminToques  RefAdminToques;
    public AdminJuego referenciaAdminJuego;
    public Spawner referenciaSpawner;
    public GameObject objetivo;
    public enum TorreSeleccionada
    {
        torre1, torre2, torre3, torre4, torre5
    }
    public TorreSeleccionada torreSeleccionada;
    public List<GameObject> PrefabsTorre;
    public List<GameObject> torresInstanciadas;

    public delegate void EnemigoObjetivoActualizado();
    public event EnemigoObjetivoActualizado EnEnemigoObjetivoActualizado;
 
    private void OnEnable()
    {
        RefAdminToques.enPlataformaTocada += CrearTorre;
        referenciaSpawner.EnOleadaIniciada += ActualizarObjetivo;
        torresInstanciadas = new List<GameObject>();
    }
    private void OnDisable()
    {
        RefAdminToques.enPlataformaTocada -= CrearTorre;
        referenciaSpawner.EnOleadaIniciada -= ActualizarObjetivo;
    }
    private void CrearTorre(GameObject plataforma)
    {
        int costo = torreSeleccionada switch
        {
            TorreSeleccionada.torre1 => 400,
            TorreSeleccionada.torre2 => 500,
            TorreSeleccionada.torre3 => 700,
            TorreSeleccionada.torre4 => 500,
            TorreSeleccionada.torre5 => 1000,
            _ => 0
        };
        if (plataforma.transform.childCount == 0 && referenciaAdminJuego.Recursos >= costo)
        {
            referenciaAdminJuego.ModificarRecursos(-costo);
            int indiceTorre = (int)torreSeleccionada;
            Vector3 posParaInstanciar = plataforma.transform.position;
            posParaInstanciar.y += 1f;
            GameObject torreInstanciada = Instantiate<GameObject>(PrefabsTorre[indiceTorre], posParaInstanciar, Quaternion.identity);
            torreInstanciada.transform.SetParent(plataforma.transform);
            torresInstanciadas.Add(torreInstanciada);
        }
    }
    public void ActualizarObjetivo()
    {
        if (referenciaSpawner.laOleadaHaIniciado)
        {
            float distanciaMasCorta = float.MaxValue;
            GameObject enemigoMasCercano = null;
            foreach (GameObject enemigo in referenciaSpawner.EnemigosGenerados)
            {
                float dist = Vector3.Distance(enemigo.transform.position, objetivo.transform.position);
                if (dist < distanciaMasCorta)
                {
                    distanciaMasCorta = dist;
                    enemigoMasCercano = enemigo;
                }
            }
            if (enemigoMasCercano != null)
            {
                foreach (GameObject torre in torresInstanciadas)
                {
                    torre.GetComponent<TorreBase>().enemigo = enemigoMasCercano;
                    torre.GetComponent<TorreBase>().Disparar();
                }
                if (EnEnemigoObjetivoActualizado != null)
                {
                    EnEnemigoObjetivoActualizado();
                } 
            }
        }
        Invoke("ActualizarObjetivo", 3);
    }
    public void ConfigurarTorre(int torre)
    {
        if (Enum.IsDefined(typeof(TorreSeleccionada), torre))
        {
            torreSeleccionada = (TorreSeleccionada)torre;
        }
    }
}
