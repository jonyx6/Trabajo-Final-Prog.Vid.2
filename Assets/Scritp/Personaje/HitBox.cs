using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class HitBox : MonoBehaviour
{
    public CapsuleCollider2D ccHitbox;
    public SpriteRenderer spJugador;

    private void Update()
    {
        if (spJugador.flipX)
        {
            ccHitbox.offset = new Vector2(-0.75f,0f);
        }
        else
        {
            ccHitbox.offset = new Vector2(0f, 0f);
        }
    }
}*/
public class HitBox : MonoBehaviour
{
    [Header("Referencias")]
    public CapsuleCollider2D ccHitbox;
    public SpriteRenderer spJugador;

    [Header("Offset")]
    public Vector2 offsetDerecha;
    public Vector2 offsetIzquierda;

    private void LateUpdate()
    {
        ccHitbox.offset = spJugador.flipX ? offsetIzquierda : offsetDerecha;
    }
}




