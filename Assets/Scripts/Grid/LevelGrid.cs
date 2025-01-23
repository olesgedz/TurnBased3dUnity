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
    
    public void SetUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.SetUnit(unit);
    }
    
    public Unit GetUnitAtGridPosition(GridPosition gridPosition)
    {
        return gridSystem.GetGridObject(gridPosition).GetUnit();
    }
    
    public void ClearUnitAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.SetUnit(null);
    }
    
    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
}
