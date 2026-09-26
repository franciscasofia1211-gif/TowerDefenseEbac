using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminUI : MonoBehaviour
{
    public GameObject CanvasMenuPrincipal;
    public GameObject CanvasPrincipal;
    public GameObject menuGameOver;
    public GameObject MenuOlaGanada;
    public GameObject MensajeFinOla;
    public Spawner referenciaSpawner;
    public Objetivo referenciaObjetivo;
    public AdminJuego referenciaAdminJuego;
    public TMPro.TMP_Text TextoRecursos;
    public TMPro.TMP_Text TextoOleadas;
    public TMPro.TMP_Text TextoEnemigos;
    public TMPro.TMP_Text TextoJefes;

    private void OnEnable()
    {
        referenciaObjetivo.EnObjetivoDestruido += MostrarMenuGameOver;
        referenciaSpawner.EnOleadaIniciada += ActualizarOla;
        referenciaSpawner.EnOleadaTerminada += MostrarMensajeUltimoEnemigo;
        referenciaSpawner.EnOleadaGanada += MostrarMenuOlaGanada;
        referenciaAdminJuego.enRecursosModificados += ActualizarRecursos;
    }
    private void OnDisable()
    {
        referenciaObjetivo.EnObjetivoDestruido -= MostrarMenuGameOver;
        referenciaSpawner.EnOleadaIniciada -= ActualizarOla;
        referenciaSpawner.EnOleadaTerminada -= MostrarMensajeUltimoEnemigo;
        referenciaSpawner.EnOleadaGanada -= MostrarMenuOlaGanada;
        referenciaAdminJuego.enRecursosModificados -= ActualizarRecursos;
    }

    private void ActualizarRecursos()
    {
        TextoRecursos.text = $"Recursos: {referenciaAdminJuego.Recursos}";
    }

    private void MostrarMensajeUltimoEnemigo()
    {
        MensajeFinOla.SetActive(true);
        Invoke("OcultarMensajeUltimoEnemigo", 3f);
    }
    private void OcultarMensajeUltimoEnemigo()
    {
        MensajeFinOla.SetActive(false);
    }
    private void MostrarMenuOlaGanada()
    {
        TextoEnemigos.text = $"ENEMIGOS: \t {referenciaAdminJuego.EnemigosBaseDerrotados}";
        TextoJefes.text = $"Jefes: \t\t {referenciaAdminJuego.EnemigosJefeDerrotados}";
        MenuOlaGanada.SetActive(true);
    }
    public void OcultarMenuOlaGanada()
    {
        MenuOlaGanada.SetActive(false);
    }
    private void ActualizarOla()
    {
        TextoOleadas.text = $"Ola: {referenciaSpawner.oleada}";
        OcultarMenuOlaGanada();
    }
    public void MostrarMenuGameOver()
    {
        menuGameOver.SetActive(true);
    }
    public void OcultarMenuGameOver()
    {
        menuGameOver.SetActive(false);
    }
    public void MostrarMenuPrincipal()
    {
        CanvasMenuPrincipal.SetActive(true);
    }
    public void OcultarMenuPrincipal()
    {
        CanvasMenuPrincipal.SetActive(false);
    }
    public void MostrarCanvasPrincipal()
    {
        CanvasPrincipal.SetActive(true);
    }
    public void OcultarCanvasPrincipal()
    {
        CanvasPrincipal.SetActive(false);
    }
    public void FinalizarJuego()
    {
        Application.Quit();
    }
    public void CargarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
    public void ReintentarNivel()
    {
        int EscenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(EscenaActual);
    }
}
