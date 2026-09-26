using UnityEngine;
using UnityEngine.AI;

public class Boss : EnemigoBase
{
    private void Awake()
    {
        vida = 100;
        _dano = 30;
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.EnemigosJefeDerrotados++;
    }
}
