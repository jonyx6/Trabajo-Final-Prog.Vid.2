using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using System.Data;
using System;
using System.Linq;

public class MapMaker : MonoBehaviour
{
    [Header("Pared")]
    public TileBase tile;

    public Tilemap tilemap;

    [SerializeField]
    private CelularData cell;

    [Header("Forma del mapa")]
    [SerializeField]
    private int mapWith;
    [SerializeField]
    private int mapHeight;
    [SerializeField]
    private float fillPercente;
    [SerializeField]
    private int iterations;

    //Datos del mapa
    private int[,] mapData;

    //Posicion de los tiles vacios , sirve para hacer aparecer cosas y verificar que halla espacio
    public List<Vector2Int> EmptyTiles { get; private set; } = new();

    [Header("Objetos A Ubicar")]
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject exit;

    //el objeto que genera los datos del mapa

    public void GenerateMap()
    {
        GenerateTiles();
        PlaceCharacter();
        PlaceExit();
    }
    void GenerateTiles()
    {
        mapData = cell.GenerateData(mapWith, mapHeight,iterations,fillPercente);
        EmptyTiles.Clear();
        tilemap.ClearAllTiles();

        for (int i = 0; i < mapWith; i++)
        {
            for (int j = 0; j < mapHeight ; j++)
            {
                if (mapData[i, j] == 1)
                {
                    tilemap.SetTile(new Vector3Int(i, j, 0), tile);
                }
                else
                {
                    EmptyTiles.Add(new Vector2Int(i, j));
                }
            }
        }
    }
    Vector2Int FindClosestTileTo(Vector2Int pos)
    {
        Vector2Int closestTile = EmptyTiles[0];
        float shortestDist = Vector2Int.Distance(pos, closestTile);
        foreach (var tile in EmptyTiles)
        {
            float distActual = Vector2Int.Distance(pos, tile);
            if (distActual < shortestDist)
            {
                shortestDist = distActual;
                closestTile = tile;
            }
        }
        return closestTile;
    }

    void PlaceCharacter()
    {
        Vector2 characterPos = FindClosestTileTo(new Vector2Int(0, mapHeight));
        character.transform.position = characterPos;
    }
    void PlaceExit()
    {
        Vector2 exitPos = FindClosestTileTo(new Vector2Int(mapWith, 0));
        exit.transform.position = exitPos;
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
