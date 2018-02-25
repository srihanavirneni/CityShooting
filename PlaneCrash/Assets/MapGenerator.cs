using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public bool AutoUpdate;

    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;
    public int seed;
    public Vector2 offset;

    public TerrainType[] regions;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapHeight, mapWidth, seed, noiseScale, octaves, persistance, lacunarity, offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }

    private void OnValidate()
    {
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }

        if (mapHeight < 1)
        {
            mapHeight = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
    }
}

[System.Serializable]
public struct TerrainType{
    public string name;
    public float height;
    public Color color;
}
