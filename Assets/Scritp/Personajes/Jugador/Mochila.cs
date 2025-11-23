using System;
using System.Collections;
using System.Collections.Generic;
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
        ItemsRecolectados[tipoDeItem].cantidad--;
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
}
