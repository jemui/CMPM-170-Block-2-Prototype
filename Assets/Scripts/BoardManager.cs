using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject grid;
    public GameObject ladder;
    public GameObject border;
    public GameObject animal;

    /*
        0 - moveable
        1 - wall
        2 - ladder
        3 - animals
        5 - moveable + grid (temp)
     */
    int[,] board = new int[5, 9] 
    { 
        {1, 1, 1, 1, 1, 1, 1, 1, 1}, 
        {2, 0 ,3, 0, 2, 0, 5, 3, 2}, 
        {2, 3 ,0, 5, 2, 5, 0, 5, 2}, 
        {2, 0 ,5, 0, 2, 0, 3, 0, 2}, 
        {1, 1, 1, 1, 1, 1, 1, 1, 1},  
    };

    // Set up board using an array
    void Start()
    {
        // board column len
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                //if i,j == 1, put a wall
                if(board[i,j] == 1) 
                {
                    // Instantiate at position and rotation.
                    Instantiate(border, new Vector3(j + 1, i - 1, 0.5f), Quaternion.Euler(-90, 0, 0));
                    Debug.Log(border.transform.rotation.x);
                }
                // put a ladder
                else if(board[i,j] == 2) 
                {
                    Instantiate(ladder, new Vector3(j + 1, i - 1, 0.5f), Quaternion.Euler(-90, 0, 0));
                }

                // put an animal
                else if(board[i,j] == 3) 
                {
                    Instantiate(animal, new Vector3(j + 1, i - 1, 0.5f), Quaternion.Euler(-90, 0, 0));
                }
                
                // put a grid square
                else if(board[i,j] == 5) 
                {
                    Instantiate(grid, new Vector3(j + 1, i - 1, 0.5f), Quaternion.Euler(-90, 0, 0));
                }
            }
        }
        
    }

    void Update()
    {
        // Player can only move down if on a ladder

        // button compenent to update ?

    }
}
