using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public TipoDeAtributo atributo;
    public float cantidadQueAumenta;
    [SerializeField]
    private float velMovimiento = 2;
    [SerializeField]
    private float amplitud = 0.3f;
    private float posYInicial;
    /*     public int id;
        public string type;
        public string descripcion;
        public Sprite icon;

        public bool estaAgarrado;


        public bool estaEquipado; */
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
