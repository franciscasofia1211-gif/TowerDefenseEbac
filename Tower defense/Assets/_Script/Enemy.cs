using UnityEngine;
using UnityEngine.AI;

public class Enemy : EnemigoBase
{
    private void Awake()
    {
        vida = 50;
        _dano = 10;
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.EnemigosBaseDerrotados++;
    }
}
