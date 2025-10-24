using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using System.Data;
using System;

public class MapMaker : MonoBehaviour
{
    [Header("Pared")]
    public Tile tile;

    public Tilemap tilemap;

    //aca definimos el tama�o del mapa 

    public int mapWith;
    public int mapHeight;

    private int[,] mapData;

    public List<Vector2Int> posVacias = new();

    [SerializeField]
    private GameObject personaje;
    [SerializeField]
    private GameObject salida;

    // le pasamos el celularData
    public CelularData cell;
    public CelularData cellData;    

     void Start()
    {
        this.mapData = this.cell.GenerateData(this.mapWith,this.mapHeight);

        //this.GenerateFloor();
        this.GenerateTiles();
        UbicarJugador();
        UbicarSalida();
    }


    void GenerateTiles()
    {

        for (int i = 0; i < this.mapWith; i++)
        {
            for (int j = 0; j < this.mapWith; j++)
            {
                if (this.mapData[i, j] == 1)
                {
                    this.tilemap.SetTile(new Vector3Int(i, j, 0), this.tile);
                }
                else
                {
                    posVacias.Add(new Vector2Int(i, j));
                }
            }
        }
    }
    Vector2Int BuscarPosicionCercanaA(Vector2Int posOrigen)
    {
        Vector2Int celdaMasCercana = posVacias[0];
        int distMasCorta = Distancia(posOrigen, posVacias[0]);
        foreach (var pos in posVacias)
        {
            int distActual = Distancia(posOrigen, pos);
            if (distActual < distMasCorta)
            {
                distMasCorta = distActual;
                celdaMasCercana = pos;
            }
        }
        return celdaMasCercana;
    }

    void UbicarJugador()
    {
        Vector2 posPersonaje = BuscarPosicionCercanaA(new Vector2Int(0, 64));
        personaje.transform.position = posPersonaje;
    }
    void UbicarSalida()
    {
        Vector2 posSalida = BuscarPosicionCercanaA(new Vector2Int(64, 0));
        salida.transform.position = posSalida;
    }
    int Distancia(Vector2Int pos1,Vector2Int pos2)
    {
        int distX = Math.Abs(pos1.x - pos2.x);
        int distY = Math.Abs(pos1.y - pos2.y);
        return distX + distY;
    }

    /*void GenerateFloor()
    {

        for (int i = 0; i < this.mapWith; i++)
        {
            for (int j = 0; j < this.mapWith; j++)
            {
                if (this.mapData[i, j] == 0)
                {
                    this.tilemap.SetTile(new Vector3Int(i, j, 0), this.tile2);
                }
            }
        }
    }*/


}
