using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Generates rectangular shaped grid of squares.
/// </summary>
[ExecuteInEditMode()]
public class RectangularSquareGridGenerator : ICellGridGenerator
{
    public GameObject SquarePrefab;

    public int Width;
    public int Height;

    public override List<Cell> GenerateGrid()
    {
        var ret = new List<Cell>();

        if (SquarePrefab.GetComponent<Square>() == null)
        {
            Debug.LogError("Invalid square cell prefab provided");
            return ret;
        }

        for (int i = -Width/2; i <= Width/2; i++)
        {
            for (int j = -Height/2; j <= Height/2; j++)
            {
                var square = Instantiate(SquarePrefab);
                var squareSize = square.GetComponent<Cell>().GetCellDimensions();

                square.transform.position = new Vector3(i*squareSize.x,j*squareSize.y,0);
                square.GetComponent<Cell>().OffsetCoord = new Vector2(i,j);
                square.GetComponent<Cell>().MovementCost = 1;
                ret.Add(square.GetComponent<Cell>());

                square.transform.parent = CellsParent;
            }
        }
        return ret;
    }
}
