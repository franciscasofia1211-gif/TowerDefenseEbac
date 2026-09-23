using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject Objetivo;
    public int vida = 100;
    public Animator anim;
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(Objetivo.transform.position);
        anim = GetComponent<Animator>();
        anim.SetBool("IsWalking", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Objetivo")
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAtacking", true);
        }
    }

    public void dañar()
    {
        Objetivo?.GetComponent<Objetivo>().recibirDaño(20);
    }

    public void RecibirDaño(int daño = 10)
    {
        vida -= daño;
    }
}
