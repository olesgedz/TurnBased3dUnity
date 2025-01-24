using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro TextMeshPro;
    
    private GridObject _gridObject;
    
    public void SetGridObject(GridObject gridObject)
    {
        this._gridObject = gridObject;
    }
    
    private void Update()
    {
        TextMeshPro.text = _gridObject.ToString() + " \n " + _gridObject.GetUnit();
    }
}
