using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int id;
    public string itemType;
    public string descripcion;
    public Sprite icon;
    public bool estaVacio;

    [Header("Referencia al ícono del slot")]
    public Image slotIconImage;
    public Transform slotIconGameObject;

    private void Start()
    {
        slotIconGameObject= transform.GetChild(0);
    }






    public void ActualizaSlot()
    {

        slotIconGameObject.GetComponent<Image>().sprite = icon;
       /* if (slotIconImage != null)// si hay un slotIconImagen
        {
            slotIconImage.sprite = icon;
            
        }
        else
        {
            Debug.LogWarning("slotIconImage no está asignado en el Inspector", this);
        }*/
    }


    public void CuandoElBotonEsPulsado()
    {
        Debug.Log("el boton funciona");
    }


    public void AlTocarSlot()
    {
        Debug.Log("CLICK en slot: " + gameObject.name);
        if ( item != null)
        {
            // Buscar el Inventario en la escena
            Inventario inventario = FindObjectOfType<Inventario>();

            if (inventario != null)
            {
                inventario.EquiparItemDesdeSlot(this);
            }
        }

    }

    public void DevolverItemAlInventario()
    {
        Debug.Log("CLICK en slot: " + gameObject.name);
        if(item != null)
        {
            Inventario inventario = FindObjectOfType<Inventario>();

            if(inventario != null)
            {
                inventario.DesequiparObjeto(this);
            }

        }

    }






}
