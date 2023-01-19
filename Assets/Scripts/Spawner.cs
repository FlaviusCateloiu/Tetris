using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Pieces
    public GameObject[] piecesPrefab;
    public GameObject[] pieces;
    public GameObject block;
    
    // Start is called before the first frame update
    void Start()
    {
        Board.FillCells(block);
        CreateAllPieces();
        SpawnNext();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNext()
    {
        // Random Index
        int i = Random.Range(0, this.piecesPrefab.Length);
        
        // Spawn Group at current Position
        this.pieces[i].transform.position = this.transform.position;
        this.pieces[i].SetActive(true);
    }

    public void CreateAllPieces()
    {
        pieces = new GameObject[7];
        for (int i = 0; i < 7; i++)
        {
            this.pieces[i] = Instantiate(this.piecesPrefab[i], new Vector3(i*4, 30, 0), Quaternion.identity);
            this.pieces[i].SetActive(false);
        }
    }
}
