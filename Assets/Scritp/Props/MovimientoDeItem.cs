using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDeItem : MonoBehaviour
{
    [SerializeField]
    private float velMovimiento = 2;
    [SerializeField]
    private float amplitud = 0.3f;
    private float posYInicial;
    private void Start()
    {
        posYInicial = transform.position.y;
    }
    private void Update()
    {
        AnimarItem();
    }
    private void AnimarItem()
    {
        float posY = posYInicial + Mathf.Sin(Time.time * velMovimiento) * amplitud;
        transform.position = new Vector2(transform.position.x, posY);
    }
}
