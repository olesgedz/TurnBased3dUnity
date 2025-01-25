using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] private Animator animator;
    private GridPosition gridPosition;
    
    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Update()
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
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if (newGridPosition != gridPosition)
        {
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }
    }
}