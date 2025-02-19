using System;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Unit unit;
   
    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            unit.GetMoveAction().GetValidGridPositionList();
        }
    }
}