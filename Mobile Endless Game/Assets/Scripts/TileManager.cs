using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    //Creates an Array of GameObjects
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = -33.3f;
    private float tileLength = 33.3f;
    public int tilesOnScreen = 8;
    //Distanta parcusa de player ca sa nu fie distrusa platforma de sub picioarele sale
    private float safeZone = 33.3f;
    //Tine evidenta la toate tile-urile ca sa distruga ultimul tile
    private List<GameObject> activeTiles;
    private int lastPrefabIndex = 0;

    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < tilesOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }
        }
    }

    void Update()
    {
        if (playerTransform.position.z - safeZone> (spawnZ - tilesOnScreen * tileLength)) 
        { 
            SpawnTile();
            DeleteTile();
        }
        
    }

    public void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {

            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        }

        //Spawn new tiles as a child of a parent
        go.transform.SetParent(transform);
        //Spawn new tile at the end of the last spawn
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }
        
        int randomIndex = lastPrefabIndex;

        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
