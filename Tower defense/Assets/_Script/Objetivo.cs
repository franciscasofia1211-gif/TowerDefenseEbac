using UnityEngine;

public class Objetivo : MonoBehaviour
{
    public int vida = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void recibirDaño(int daño = 20)
    {
        vida -= daño;
    }
}
