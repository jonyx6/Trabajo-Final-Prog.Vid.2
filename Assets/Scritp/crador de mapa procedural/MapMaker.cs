using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
    [Header("Pared")]
    public Tile tile;

    public Tilemap tilemap;

    //aca definimos el tamaño del mapa 

    public int mapWith;
    public int mapHeight;

    private int[,] mapData;

    // le pasamos el celularData
    public CelularData cell;
    public CelularData cellData;    

     void Start()
    {
        this.mapData = this.cell.GenerateData(this.mapWith,this.mapHeight);

        //this.GenerateFloor();
        this.GenerateTiles();
    }


    void GenerateTiles()
    {
        
        for (int i = 0; i < this.mapWith; i++)
        {
            for (int j = 0; j < this.mapWith; j++)
            {
                if (this.mapData[i,j] == 1)
                {
                    this.tilemap.SetTile(new Vector3Int(i,j,0),this.tile);
                }
            }
        }
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
