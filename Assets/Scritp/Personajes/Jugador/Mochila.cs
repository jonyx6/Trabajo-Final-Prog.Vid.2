using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemsDeMochila
{
    Pocion,
    Flecha,
    Manzana
}

public class ItemGuardado
{
    public int cantidad = 0;
    public bool estaRecargado = false;
    public float tiempoDeRecuperacion;
    public ItemGuardado(float tiempoDeRecuperacion)
    {
        this.tiempoDeRecuperacion = tiempoDeRecuperacion;
    }

}

//se encarga de guardar items
public class Mochila : MonoBehaviour
{
    public TextMeshProUGUI textManzanas;
    public TextMeshProUGUI textFlecha;
    public TextMeshProUGUI textPosicion;


    public void Start()
    {
        ActualizarUI(ItemsDeMochila.Manzana);
        ActualizarUI(ItemsDeMochila.Pocion);
        ActualizarUI(ItemsDeMochila.Flecha);
    }






    Dictionary<ItemsDeMochila, ItemGuardado> ItemsRecolectados = new Dictionary<ItemsDeMochila, ItemGuardado>()
    {
        {ItemsDeMochila.Pocion, new ItemGuardado(1)},
        {ItemsDeMochila.Flecha, new ItemGuardado(1)},
        {ItemsDeMochila.Manzana, new ItemGuardado(1)},
    };
    public bool tieneLLave;

    public void AgregarItemDeTipo(ItemsDeMochila tipoDeItem)
    {
        ItemsRecolectados[tipoDeItem].cantidad++;
    }
    public void GastarItemDeTipo(ItemsDeMochila tipoDeItem)
    {
        ItemsRecolectados[tipoDeItem].cantidad = math.max(0, ItemsRecolectados[tipoDeItem] . cantidad-1); ///posible correccion
    }

    public bool SePuedeUsarUnItem(ItemsDeMochila tipoDeItem)
    {
        ItemGuardado item = ItemsRecolectados[tipoDeItem];
        return item.cantidad > 0 && !item.estaRecargado;
    }

    public bool HayAlgunItemDeTipo(ItemsDeMochila tipoDeItem)
    {
        return ItemsRecolectados[tipoDeItem].cantidad > 0;
    }

    public void UsarItem(ItemsDeMochila tipoDeItem)
    {
        Debug.Log("consumiste item de tipo " + tipoDeItem);
        Debug.Log(ItemsRecolectados[tipoDeItem].cantidad);
        GastarItemDeTipo(tipoDeItem);
        StartCoroutine(ConsumirItem(ItemsRecolectados[tipoDeItem]));
    }

    private IEnumerator ConsumirItem(ItemGuardado item)
    {
        item.estaRecargado = true;
        Debug.Log("item recargandose");
        yield return new WaitForSeconds(item.tiempoDeRecuperacion);
        Debug.Log("item recargando");
        item.estaRecargado = false;
    }


    /// las funciones de abajo las hizo "jony"
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Manzana"))
        {
           // AgregarItemDeTipo(ItemsDeMochila.Manzana);
           
            ActualizarUI(ItemsDeMochila.Manzana);
            
        }

        if (collision.gameObject.CompareTag("Flecha"))
        {
            
            ActualizarUI(ItemsDeMochila.Flecha);

        }
        if (collision.gameObject.CompareTag("Pocion"))
        {
            ;
            ActualizarUI(ItemsDeMochila.Pocion);

        }

    }


    public void ActualizarUI(ItemsDeMochila tipoDeItem)
    {
        if (tipoDeItem == ItemsDeMochila.Manzana)
        {
            textManzanas.text = ItemsRecolectados[tipoDeItem].cantidad.ToString();
        }

        if (tipoDeItem == ItemsDeMochila.Flecha)
        {
            textFlecha.text = ItemsRecolectados[tipoDeItem].cantidad.ToString();
        }

        if (tipoDeItem == ItemsDeMochila.Pocion)
        {
            textPosicion.text = ItemsRecolectados[tipoDeItem].cantidad.ToString();
        }
    }

}






