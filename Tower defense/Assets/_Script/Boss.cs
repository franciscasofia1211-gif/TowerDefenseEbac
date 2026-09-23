using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public GameObject Objetivo;
    public int vida = 100;
    public Animator anim;
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(Objetivo.transform.position);
        anim = GetComponent<Animator>();
        anim.SetBool("IsMoving",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Objetivo")
        {
            anim.SetBool("IsMoving",false);
            anim.SetTrigger("OnObjectReached");
        }
    }

    public void dañar()
    {
        Objetivo?.GetComponent<Objetivo>().recibirDaño(40);
    }

    public void RecibirDaño(int daño = 5)
    {
        vida -= daño;
    }
}
