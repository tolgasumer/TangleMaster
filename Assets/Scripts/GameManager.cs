using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject blockPrefab;

    [SerializeField]
    int blockCount = 3;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    Vector3 spawnPosOffset = new Vector3(2f, 0f, 0f);

    GameObject[] blocks;
    Color[] ropeColors;

    void Start()
    {
        // Spawn blocks with desired offset between eachother
        blocks = new GameObject[blockCount];
        ropeColors = new Color[blockCount];
        Vector3 spawnPos = spawnPoint.position;
        
        for (int i = 0; i < blockCount; i++)
        {
            blocks[i] = Instantiate(blockPrefab, spawnPos, Quaternion.identity);
            spawnPos += spawnPosOffset;

            // Pick random colors for each rope according to the size of blockCount
            ropeColors[i] = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            blocks[i].transform.Find("RopeParent").GetComponent<Renderer>().material.SetColor("_Color", ropeColors[i]); // Set color of RopeParent
            blocks[i].transform.GetChild(0).GetChild(0).GetComponent<LineRenderer>().startColor = ropeColors[i]; // Set color of Rope
        }

    }


    void Update()
    {
        
    }
}
