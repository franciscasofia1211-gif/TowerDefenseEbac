using UnityEngine;

public class AdminJuego : MonoBehaviour
{
    public int EnemigosBaseDerrotados;
    public int EnemigosJefeDerrotados;
    public int Recursos = 1500;

    public delegate void RecursosModificados();
    public event RecursosModificados enRecursosModificados;

    public void ModificarRecursos(int Modificacion)
    {
        Recursos += Modificacion;
        if (enRecursosModificados != null)
        {
            enRecursosModificados();
        }
    }
    public void ResetValores()
    {
        EnemigosJefeDerrotados = 0;
        EnemigosBaseDerrotados = 0;
    }
}
