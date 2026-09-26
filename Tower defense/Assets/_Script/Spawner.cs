using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabsEnemigos;
    public int oleada;
    public List<int> enemigosPorOleadas;

    private int enemigosDuranteEstaOleada;

    public bool laOleadaHaIniciado;
    public List<GameObject> EnemigosGenerados;
    public delegate void EstadoOleada();
    public event EstadoOleada EnOleadaIniciada;
    public event EstadoOleada EnOleadaTerminada;
    public event EstadoOleada EnOleadaGanada;

    private void Start()
    {
        oleada = 0;
    }
    private void FixedUpdate()
    {
        if (laOleadaHaIniciado && EnemigosGenerados.Count == 0)
        {
            GanarOla();
        }
    }
    public void EmpezarOla()
    {
        laOleadaHaIniciado = true;
        if (EnOleadaIniciada != null)
        {
            EnOleadaIniciada();
        }
        ConfigurarCantidadEnemigos();
        InstanciarEnemigo();
    }
    private void GanarOla()
    {
        if (laOleadaHaIniciado && EnOleadaGanada != null)
        {
            EnOleadaGanada();
            laOleadaHaIniciado = false;
        }
    }

    public void TerminarOla()
    {
        if (EnOleadaTerminada != null)
        {
            EnOleadaTerminada();
        }
    }
    public void ConfigurarCantidadEnemigos()
    {
        enemigosDuranteEstaOleada = enemigosPorOleadas[oleada];
    }
    public void InstanciarEnemigo()
    {
        int indiceAleatorio = Random.Range(0, prefabsEnemigos.Count);
        var EnemigoTemporal = Instantiate<GameObject>(prefabsEnemigos[indiceAleatorio], transform.position, Quaternion.identity);
        EnemigosGenerados.Add(EnemigoTemporal);
        enemigosDuranteEstaOleada--;
        if (enemigosDuranteEstaOleada < 0)
        {
            oleada++;
            ConfigurarCantidadEnemigos();
            TerminarOla();
            return;
        }
        Invoke("InstanciarEnemigo", 2);
    }
}
