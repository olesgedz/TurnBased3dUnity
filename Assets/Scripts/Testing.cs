using System;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public GridSystem gridSystem;
    private void Start()
    {
        gridSystem = new GridSystem(10, 10, 2);
        new GridSystem(10, 10, 2);
        Debug.Log(new GridPosition(5, 7));
    }

    private void Update()
    {
        Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition()));
    }
}