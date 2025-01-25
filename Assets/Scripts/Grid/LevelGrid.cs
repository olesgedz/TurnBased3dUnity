using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private Transform gridDebugObjectPrefab;
    public GridSystem gridSystem;
    
    public static LevelGrid Instance { get; private set; }
    
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There should never be two LevelGrid." + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        gridSystem = new GridSystem(10, 10, 2);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
        
        new GridSystem(10, 10, 2);
    }
    
    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public void UnitMovedGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosititon)
    {
        RemoveUnitAtGridPosition(fromGridPosition, unit);
        AddUnitAtGridPosition(toGridPosititon, unit);
    }
    
    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition)
    {
        return gridSystem.GetGridObject(gridPosition).GetUnitList();
    }
    
    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }
    
    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
}
