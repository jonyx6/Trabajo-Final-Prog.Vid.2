using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelularData : MonoBehaviour
{
    public int[,] GenerateData(int w , int h, int iterations, float fillPercente)
    {
        int[,] mapData = new int[w,h];

       
        for (int i =0; i < w; i++)
        {
            for( int j =0; j< h; j++)
            {
                float chance = Random.Range(0f, 1f);
                mapData[i, j] = chance < fillPercente ? 1 : 0;
            }
        }

        int[,] buffer= new int[w,h];
        //

        for(int x = 0; x < iterations; x++)
        {
            for(int i=0; i<w; i++)
            {
               for (int j=0; j< h; j++)
                {
                    if ( ((i==0) || ( i == w-1))  ||  ( (j == 0) || ( j == h-1)))
                    {
                        buffer[i,j] = 1;
                        continue;
                    }

                    var count = mapData[i,j];

                    //vertical
                    count += mapData[i, j-1];
                    count += mapData[i, j +1];
                    //Horizontal
                    count += mapData[i-1, j];
                    count += mapData[i+1, j];

                    //diagonal
                    count += mapData[i - 1, j-1];
                    count += mapData[i + 1, j+1];
                    count += mapData[i - 1, j+1];
                    count += mapData[i + 1, j-1];

                    if (count < 4 )
                    {
                        buffer[i,j] = 0;
                    }
                    else if (count > 4)
                    {
                        buffer[i, j] = 1;
                    }
                }
            }

            // copiamos el buffer data
            for ( int i = 0; i < w; i++)
            {
                for(int j = 0;j< h; j++)
                {
                    mapData[i,j]=buffer[i,j];
                }
            }
        }
            //
        return mapData;

    }



}
