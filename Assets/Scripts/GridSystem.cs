using UnityEngine;

public class GridSystem
{
    private int _width;
    private int _height;
    private float _cellSize;
    private GridObject[,] _gridObjectArray;

    public GridSystem(int width, int height, float cellSize)
    {
        this._width = width;
        this._height = height;
        this._cellSize = cellSize;

        _gridObjectArray = new GridObject[_width, _height];
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                _gridObjectArray[x, z] = new GridObject(this, gridPosition);
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * _cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(Mathf.RoundToInt(worldPosition.x / _cellSize),
            Mathf.RoundToInt(worldPosition.z / _cellSize));
    }

    public void CreateDebugObjects(Transform debugPrefab)
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                GameObject.Instantiate(debugPrefab, GetWorldPosition(x, y), Quaternion.identity);
            }
        }
    }
}