using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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


    /* private void Start()
     {
         slotIconGameObject = transform.GetChild(0);

     }

     public void ActualizaSlot()
     {
         slotIconGameObject.GetComponent<Image>().sprite = icon;
     }*/

    public void ActualizaSlot()
    {
        if (slotIconImage != null)
        {
            slotIconImage.sprite = icon;
            slotIconImage.enabled = true;
        }
        else
        {
            Debug.LogWarning("slotIconImage no está asignado en el Inspector", this);
        }
    }


}
