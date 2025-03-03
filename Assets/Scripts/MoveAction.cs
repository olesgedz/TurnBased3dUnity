using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int maxMoveDistance = 4;
    
    private Unit unit;
    private Vector3 targetPosition;

    
    private void Awake()
    {
        targetPosition = transform.position;
        unit = GetComponent<Unit>();
    }
    
    public void Move(GridPosition targetPosition)
    {
        this.targetPosition = LevelGrid.Instance.GetWorldPosition(targetPosition);
    }

    public void Update()
    {
        const float moveSpeed = 5f;
        const float minDistance = 0.1f;

        if (Vector3.Distance(transform.position, targetPosition) > minDistance)
        {
            var direction = (targetPosition - transform.position).normalized;
            transform.position += direction * (moveSpeed * Time.deltaTime);
            
            const float rotationSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * rotationSpeed);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    
    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidGridPositionList();
        return validGridPositionList.Contains(gridPosition);
    }

    public List<GridPosition>  GetValidGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridPosition = unit.GetGridPosition();
        
        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = gridPosition + unitGridPosition;
                if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                    continue;
                if (unitGridPosition == testGridPosition)
                    continue;
                if (LevelGrid.Instance.HasAnyUnitAtGridPosition(testGridPosition))
                    continue;
                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }
}
