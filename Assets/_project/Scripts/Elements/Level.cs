using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Tile tilePrefab;

    public int xLength;
    public int yLength;

    public List<Tile> tiles;

    public float maxHeight;
    public float heightChance;
    public void StartLevel()
    {
        /*for (int j = 0; j < yLength; j++)
        {
            for (int i = 0; i < xLength; i++)
            {
                float yPos = 0;
                if (j != 0 && Random.value < heightChance)
                {
                    yPos = Random.Range(0f, maxHeight);
                    var previousTile = tiles[^1];
                    previousTile.transform.localPosition 
                        = new Vector3(previousTile.transform.position.x, yPos, previousTile.transform.position.z);

                    var previousRow = tiles[^(xLength)];
                    previousRow.transform.localPosition
                        = new Vector3(previousRow.transform.position.x, yPos, previousRow.transform.position.z);

                    var previousRowPreviousTile = tiles[^(xLength+1)];
                    previousRowPreviousTile.transform.localPosition
                        = new Vector3(previousRowPreviousTile.transform.position.x, yPos, previousRowPreviousTile.transform.position.z);
                }
                var newTile = Instantiate(tilePrefab, transform);
                newTile.transform.position = new Vector3(i - (xLength - 1) / 2f, yPos, j);
                newTile.StartTile((i+j) % 2 == 0);
                tiles.Add(newTile);
            }
        }
        transform.position += Vector3.back * yLength / 2f;*/
        
    }
}
