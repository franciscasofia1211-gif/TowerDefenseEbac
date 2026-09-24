using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminUI : MonoBehaviour
{
    public GameObject CanvasPrincipal;
    public GameObject menuGameOver;
    public Spawner referenciaSpawner;
    public Objetivo referenciaObjetivo;

    private void OnEnable()
    {
        referenciaObjetivo.EnObjetivoDestruido += MostrarMenuGameOver;
    }
    private void OnDisable()
    {
        referenciaObjetivo.EnObjetivoDestruido -= MostrarMenuGameOver;
    }
    public void MostrarMenuFinOleada()
    {

    }
    public void OcultarMenuFinOleada()
    {

    }
    public void MostrarMenuGameOver()
    {
        menuGameOver.SetActive(true);
    }
    public void OcultarMenuGameOver()
    {
        menuGameOver.SetActive(false);
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
