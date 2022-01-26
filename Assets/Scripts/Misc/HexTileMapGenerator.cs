using System;
using UnityEngine;

public class HexTileMapGenerator : MonoBehaviour
{
    public GameObject hexTile;
    
    [SerializeField] int mapWidth = 25;
    [SerializeField] int mapHeight = 12;

    float tileXOffset = 1.8f;
    float tileZOffset = 1.565f;


    void Start()
    {
        CreateHexTileMap();
    }

    private void CreateHexTileMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                GameObject tempGO = Instantiate(hexTile);

                if (z%2 == 0)
                {
                    tempGO.transform.position = new Vector3(x * tileXOffset, 0, z * tileZOffset);
                }
                else
                {
                    tempGO.transform.position = new Vector3(x * tileXOffset + tileXOffset/2, 0, z * tileZOffset);
                }
                SetTileInfo(tempGO,x,z);
            }
        }
    }

    void SetTileInfo(GameObject gameObject, int x, int z)
    {
        gameObject.transform.parent = transform;
        gameObject.name = x.ToString() + ", " + z.ToString();
    }
}
