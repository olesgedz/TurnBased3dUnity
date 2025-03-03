using UnityEngine;
using System.Collections.Generic;

public class GridObject
{
    private GridSystem _gridSystem;
    private GridPosition _gridPosition;
    private List<Unit> _unitList;
    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this._gridSystem = gridSystem;
        this._gridPosition = gridPosition;
        _unitList = new List<Unit>();
    }
    
    public GridPosition GetGridPosition()
    {
        return _gridPosition;
    }
    
    public override string ToString()
    {
        string unitString = "";
        foreach (Unit _unit in _unitList)
        {
            unitString += _unit + "\n";
        }
        return _gridPosition.ToString() + "\n" + unitString;
    }
    
    public void AddUnit(Unit unit)
    {
        _unitList.Add(unit);
    }
    
    public void RemoveUnit(Unit unit)
    {
        _unitList.Remove(unit);
    }
    
    public List<Unit> GetUnitList()
    {
        return _unitList;
    }
    
    public bool HasAnyUnit()
    {
        return _unitList.Count > 0;
    }
}
