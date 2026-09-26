using UnityEngine;

public class Objetivo : MonoBehaviour, IAatacable
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
            this.gameObject.SetActive(false);
        }
    }

    public void RecibirDano(int daño = 20)
    {
        vida -= daño;
    }
}
