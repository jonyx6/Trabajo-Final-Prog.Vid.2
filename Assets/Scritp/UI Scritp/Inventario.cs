using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Inventario : MonoBehaviour
{
    private bool inventarioActivado;


    public GameObject inventario;

    private int totalDeSlot;
    private int totalDeSlotEquip;


    private GameObject[] slot;
    private GameObject[] slotEquip;


    public GameObject slotHolder;
    public GameObject slotHolderEquip;

    private void Start()
     {
         totalDeSlot = slotHolder.transform.childCount;//cantidad en el array

         slot = new GameObject[totalDeSlot]; //  creamos la lista de objetos con la cantidad de obj en el array

         for (int i = 0; i < totalDeSlot; i++)
         {
             slot[i] = slotHolder.transform.GetChild(i).gameObject;//Guarda ese GameObject en el array slot[i].
            if (slot[i].GetComponent<Slot>().item == null)
             {
                 slot[i].GetComponent<Slot>().estaVacio = true;
             }
         }

          totalDeSlotEquip = slotHolderEquip.transform.childCount;
          slotEquip = new GameObject[totalDeSlotEquip]; 

         for (int i = 0;i < totalDeSlotEquip; i++)
         {
             slotEquip[i] = slotHolderEquip.transform.GetChild(i).gameObject;
             if (slotEquip[i].GetComponent<Slot>().item == null)
             {
                 slotEquip[i].GetComponent <Slot>().estaVacio = true;
             }
         }

     }

    



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventarioActivado = !inventarioActivado;
        }

        if (inventarioActivado)
        {
            inventario.SetActive(true);
        }
        else
        {
            inventario.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            GameObject itemAAgarrar = collision.gameObject;
            Item item = itemAAgarrar.GetComponent<Item>();

            AddItem(itemAAgarrar, item.id, item.type, item.descripcion, item.icon);
        }


    }

    public void AddItem(GameObject unObjeto, int itemId, string itemType, string itemDescripcion, Sprite itemIcon)
    {
        for (int i = 0; i < totalDeSlot; i++)
        {
            if (slot[i].GetComponent<Slot>().estaVacio)
            {
                unObjeto.GetComponent<Item>().estaAgarrado = true;
                slot[i].GetComponent<Slot>().item = unObjeto;
                slot[i].GetComponent<Slot>().id = itemId;
                slot[i].GetComponent<Slot>().itemType = itemType;
                slot[i].GetComponent<Slot>().descripcion = itemDescripcion;
                slot[i].GetComponent<Slot>().icon = itemIcon;

                unObjeto.transform.parent = slot[i].transform;
                unObjeto.SetActive(false);


                slot[i].GetComponent<Slot>().ActualizaSlot();
                slot[i].GetComponent<Slot>().estaVacio = false;

                return;// evitamos el el objeto se añada en los slot vacios
            }


        }
    }

    public void EquiparItemDesdeSlot(Slot slotOrigen)
    {
        for (int i = 0; i < totalDeSlotEquip; i++)
        {
            Slot slotDestino = slotEquip[i].GetComponent<Slot>();

            if (slotDestino.estaVacio && slotOrigen.itemType =="Arma" || slotOrigen.itemType == "Escudo")
            {
                slotDestino.item = slotOrigen.item;
                slotDestino.id = slotOrigen.id;
                slotDestino.itemType = slotOrigen.itemType;
                slotDestino.descripcion = slotOrigen.descripcion;
                slotDestino.icon = slotOrigen.icon;
                slotDestino.estaVacio = false;

                slotDestino.item.transform.SetParent(slotEquip[i].transform);
                slotDestino.item.SetActive(false);
                slotDestino.ActualizaSlot();

                slotOrigen.item = null;
                slotOrigen.id = 0;
                slotOrigen.itemType = "";
                slotOrigen.descripcion = "";
                slotOrigen.icon = null;
                slotOrigen.estaVacio = true;
                slotOrigen.ActualizaSlot();

                return;// termina el ciclo

            }
        }

        Debug.Log("No hay espacio en el equipamiento.");
    }


    public void DesequiparObjeto(Slot slotOrigen)
    {
        for(int i = 0;i< totalDeSlot; i++)
        {
            Slot slotDestino = slot[i].GetComponent<Slot>();
            if (slotDestino.estaVacio)
            {
                slotDestino.item = slotOrigen.item;
                slotDestino.id = slotOrigen.id;
                slotDestino.itemType = slotOrigen.itemType;
                slotDestino.descripcion = slotOrigen.descripcion;
                slotDestino.icon = slotOrigen.icon;
                slotDestino.estaVacio = false;

                slotDestino.item.transform.SetParent(slotEquip[i].transform);
                slotDestino.item.SetActive(false);
                slotDestino.ActualizaSlot();


                slotOrigen.item = null;
                slotOrigen.id = 0;
                slotOrigen.itemType = "";
                slotOrigen.descripcion = "";
                slotOrigen.icon = null;
                slotOrigen.estaVacio = true;
                slotOrigen.ActualizaSlot();

                return;// termina el ciclo

            }
        }
        Debug.Log("No hay espacio en el inventario.");
    }




}
  

