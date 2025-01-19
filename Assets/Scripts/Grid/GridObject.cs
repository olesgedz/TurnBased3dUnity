using UnityEngine;

public class GridObject : MonoBehaviour 
{
    private GridSystem _gridSystem;
    private GridPosition _gridPosition;
    
    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this._gridSystem = gridSystem;
        this._gridPosition = gridPosition;
    }
    
    public GridPosition GetGridPosition()
    {
        return _gridPosition;
    }
    
    public override string ToString()
    {
        return _gridPosition.ToString();
    }
}
