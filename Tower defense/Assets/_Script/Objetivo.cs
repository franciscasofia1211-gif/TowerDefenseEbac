using UnityEngine;

public class Objetivo : MonoBehaviour
{
    public int vida = 100;
    public delegate void ObjetivoDestruido();
    public event ObjetivoDestruido EnObjetivoDestruido;
    void Update()
    {
        if (vida <= 0)
        {
            if (EnObjetivoDestruido != null) 
            {
                EnObjetivoDestruido();
            }
            Destroy(this.gameObject);
        }
    }

    public void recibirDaño(int daño = 20)
    {
        vida -= daño;
    }
}
