using UnityEngine;
using UnityEngine.AI;

public class EnemigoBase : MonoBehaviour, IAatacable, IAatacante
{
    public GameObject Objetivo;
    public int vida = 100;
    public int _dano = 5;
    public int recursosGanados = 200;

    public AdminJuego referenciaAdminJuego;
    public Spawner ReferenciaSpawner;
    public Animator anim;

    private void OnEnable()
    {
        ReferenciaSpawner = GameObject.Find("SpawnerEnemigo").GetComponent<Spawner>();
        referenciaAdminJuego = GameObject.Find("AdminJuego").GetComponent<AdminJuego>();
        Objetivo = GameObject.Find("Objetivo");
        Objetivo.GetComponent<Objetivo>().EnObjetivoDestruido += Detener;
    }
    private void OnDisable()
    {   
        Objetivo.GetComponent<Objetivo>().EnObjetivoDestruido -= Detener;
    }

    
    void Start()
    {
        Objetivo = GameObject.FindGameObjectWithTag("Objetivo");
        GetComponent<NavMeshAgent>().SetDestination(Objetivo.transform.position);
        anim = GetComponent<Animator>();
        anim.SetBool("IsMoving", true);
    }
    void Update()
    {
        if (vida <= 0)
        {
            anim.SetTrigger("OnDeath");
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
            Destroy(gameObject, 3);
        }
    }
    public virtual void OnDestroy()
    {
        referenciaAdminJuego.ModificarRecursos(recursosGanados);
        ReferenciaSpawner.EnemigosGenerados.Remove(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Objetivo")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<NavMeshAgent>().isStopped = true;
            anim.SetBool("IsMoving", false);
            anim.SetTrigger("OnObjectReached");
        }
    }
    public void Detener()
    {
        anim.SetTrigger("OnObjectDestroy");
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
    }
    public void Danar( int dano)
    {
        if (dano == 0)
        {
            dano = _dano;
        }
        Objetivo?.GetComponent<Objetivo>().RecibirDano(40);
        
    }

    public void RecibirDano(int daño = 5)
    {
        vida -= daño;
    }
}
