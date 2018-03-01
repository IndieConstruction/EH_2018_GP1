using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

    [Header("Prefabs")]
    public GameObject TilePrefab;
    public GameObject CellColliderPrefab;
    public GameObject TileRotationTemplate;

    [Header("Containers")]
    public GameObject GraphicContainer;
    public GameObject CellContainer;

    public float CellSize = -1f;
    public List<CellData> Cells = new List<CellData>();

    public int RoundEdge = 1;

    public int XSize = 2;
    public int YSize = 3;

    private void Awake() {
        Cells = new List<CellData>();
        CreateGrid();
    }

    void CreateGrid() {

        float size = CellSize;
        if (size < 0) { 
            size = TilePrefab.transform.localScale.x + 0.1f;
        }

        for (int x = 0; x < XSize; x++) {
            for (int y = 0; y < YSize; y++) {
                // Dati
                Cells.Add(new CellData(x, y, new Vector3(x * size, transform.position.y, y * size)));
            }
        }

        //for (int x = 1; x <= RoundEdge; x++) {
        //    for (int y = 1; y <= RoundEdge; y++) {
        //        FindCell(XSize - 1 * x, YSize - 1 * y).SetValidity(false);
        //    }
        //}


        //FindCell(XSize - 1, YSize - 1).SetValidity(false);
        //FindCell(XSize - 1, 0).SetValidity(false);
        //FindCell(0, 0).SetValidity(false);
        //FindCell(0, YSize - 1).SetValidity(false);

        //CellData cellaDaModificare = FindCell(2, 2);
        //cellaDaModificare.IsValid = false;

        // Parte visuale
        for (int x = 0; x < XSize; x++) {
            for (int y = 0; y < YSize; y++) {
                CellData cell = FindCell(x, y);
                // Debug
                if (cell.IsValid) {
                    Instantiate(TilePrefab, cell.WorldPosition, TileRotationTemplate.transform.rotation, GraphicContainer.transform);
                    GameObject newCellView = Instantiate(CellColliderPrefab, cell.WorldPosition, TileRotationTemplate.transform.rotation, CellContainer.transform);
                    newCellView.GetComponent<CellView>().SetPosition(x, y);
                }
                
            }
        }
    }

    #region API

    public CellData FindCell(int x, int y) {
        return Cells.Find(c => c.X == x && c.Y == y);
    }

    /// <summary>
    /// Restituisce true se la cella è velida e false se è out of range.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool IsValidPosition(int x, int y) {
        if (x < 0 || y < 0)
            return false;
        if (x > XSize - 1 || y > YSize - 1)
            return false;

        return true;
    }

    /// <summary>
    /// Restituisce la worldposition per la posizione della cella richiesta.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Vector3 GetWorldPosition(int x, int y) {

        foreach (CellData cell in Cells) {
            if (cell.X == x && cell.Y == y) {
                return cell.WorldPosition;
            }
        }

        return Cells[0].WorldPosition;
    }

    #endregion

}
