using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabsEnemigos;
    public int oleada;
    public List<int> enemigosPorOleadas;

    private int enemigosDuranteEstaOleada;
    public delegate void OleadaTerminada();
    public event OleadaTerminada EnOleadaTerminada;

    private void Start()
    {
        oleada = 0;
        ConfigurarCantidadEnemigos();
        InstanciarEnemigo();
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
        Instantiate<GameObject>(prefabsEnemigos[indiceAleatorio], transform.position, Quaternion.identity);
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
