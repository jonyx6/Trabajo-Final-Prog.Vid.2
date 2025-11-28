using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

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
    public TextMeshProUGUI textPocion;


    public Image botonManzanas;
    public Image botonFlecha;
    public Image botonPocion;


    public void Start()
    {
        GameObject slotFlecha = GameObject.Find("SlotFlechas");
        botonFlecha = slotFlecha.GetComponent<Image>();
        textFlecha = slotFlecha.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        GameObject slotManzana = GameObject.Find("SlotManzana");
        botonManzanas = slotManzana.GetComponent<Image>();
        textManzanas = slotManzana.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        GameObject slotPocion = GameObject.Find("SlotPocion");
        botonPocion = slotPocion.GetComponent<Image>();
        textPocion = slotPocion.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        ActualizarUI(ItemsDeMochila.Manzana);
        ActualizarUI(ItemsDeMochila.Pocion);
        ActualizarUI(ItemsDeMochila.Flecha);
    }






    public Dictionary<ItemsDeMochila, ItemGuardado> ItemsRecolectados = new Dictionary<ItemsDeMochila, ItemGuardado>()
    {
        {ItemsDeMochila.Pocion, new ItemGuardado(1)},
        {ItemsDeMochila.Flecha, new ItemGuardado(1)},
        {ItemsDeMochila.Manzana, new ItemGuardado(1)},
    };
    public bool tieneLLave;

    public void AgregarItemDeTipo(ItemsDeMochila tipoDeItem)
    {
        ItemsRecolectados[tipoDeItem].cantidad++;
        ActualizarUI(tipoDeItem);
    }
    public void GastarItemDeTipo(ItemsDeMochila tipoDeItem)
    {
        ItemsRecolectados[tipoDeItem].cantidad = math.max(0, ItemsRecolectados[tipoDeItem] . cantidad-1); ///posible correccion
        ActualizarUI(tipoDeItem);
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
        UsarBotonUI(tipoDeItem);
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

    public void UsarBotonUI(ItemsDeMochila tipoDeItem)
    {   
        float tiempoDeRecup = ItemsRecolectados[tipoDeItem].tiempoDeRecuperacion;
        if (tipoDeItem == ItemsDeMochila.Manzana)
        {
            StartCoroutine(RecargarBoton(botonManzanas,tiempoDeRecup));
            textManzanas.text = ItemsRecolectados[tipoDeItem].cantidad.ToString();
        }
        else if (tipoDeItem == ItemsDeMochila.Flecha)
        {
            StartCoroutine(RecargarBoton(botonFlecha,tiempoDeRecup));
            textFlecha.text = ItemsRecolectados[tipoDeItem].cantidad.ToString();
        }
        else if (tipoDeItem == ItemsDeMochila.Pocion)
        {
            StartCoroutine(RecargarBoton(botonPocion,tiempoDeRecup));
            textPocion.text = ItemsRecolectados[tipoDeItem].cantidad.ToString();
        }
    }
    //esto tambien lo hizo jony pero en UI
    IEnumerator RecargarBoton(Image unBoton, float duracion)
    {
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            unBoton.fillAmount = tiempo / duracion;
            
            yield return null;
        }
        unBoton.fillAmount = 1f;
    }

    /// las funciones de abajo las hizo "jony"
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tuve que comentar esto sino agarraba items dobless
/*         if (collision.gameObject.CompareTag("Manzana"))
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

        } */

    }



    public void ActualizarUI(ItemsDeMochila tipoDeItem)
    {
        if (tipoDeItem == ItemsDeMochila.Manzana && ItemsRecolectados[tipoDeItem].cantidad.ToString() != null)
        {
            textManzanas.text = ItemsRecolectados[tipoDeItem].cantidad.ToString();
        }

        if (tipoDeItem == ItemsDeMochila.Flecha && ItemsRecolectados[tipoDeItem].cantidad.ToString() != null)
        {
            textFlecha.text = ItemsRecolectados[tipoDeItem].cantidad.ToString();
        }

        if (tipoDeItem == ItemsDeMochila.Pocion && ItemsRecolectados[tipoDeItem].cantidad.ToString() != null)
        {
            textPocion.text = ItemsRecolectados[tipoDeItem].cantidad.ToString();
        }
    }
}






