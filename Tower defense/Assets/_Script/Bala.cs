using UnityEngine;

public class Bala : MonoBehaviour, IAatacante
{
    public Vector3 destino;
    public float velocidad = 20;
    public GameObject enemigo;
    public int _dano = 10;
    private void Start()
    {
        destino.y += 1;
    }
    private void Update()
    {
        var paso = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destino, paso);
        if (Vector3.Distance(transform.position, destino) < 0.01f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        { 
            enemigo = collision.gameObject;
            Danar(_dano);
            Destroy(gameObject);
        } 
    }
    public void Danar(int dano = 0)
    {
        enemigo.GetComponent<EnemigoBase>().RecibirDano(dano);
    }

}
