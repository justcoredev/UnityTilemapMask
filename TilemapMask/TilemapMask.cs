//-- Asset Name: UnityTilemapMask
//-- Author: Justcore
//-- License: MIT
//-- GitHub: https://github.com/justcoredev/UnityTilemapMask

using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapMask : MonoBehaviour
{
    [HideInInspector]
    public GameObject maskParentObj;

    GameObject cellMaskPrefab;

    public void GenerateMask()
    {
        // Load CellMask prefab if not loaded
        if (cellMaskPrefab == null)
        {
            cellMaskPrefab = Resources.Load<GameObject>("TilemapMask/CellMask");
            
            if (cellMaskPrefab == null)
            {
                Debug.LogError("UnityTilemapMask: Couldn't load \"Resources/TilemapMask/CellMask\"");
            }
        }

        // Destroy old mask if needed
        if (maskParentObj != null)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(maskParentObj);
            }
            else Destroy(maskParentObj);
            maskParentObj = null;
        }

        maskParentObj = new GameObject("TilemapMask");
        maskParentObj.transform.parent = transform;

        Tilemap tilemap = GetComponent<Tilemap>();
        Vector3Int startPos = tilemap.origin;
        Vector3Int size = tilemap.size;

        // Iterate over each cell
        for (int x = startPos.x; x < startPos.x + size.x; x++)
        {
            for (int y = startPos.y; y < startPos.y + size.y; y++)
            {
                // Check if cell isn't empty
                if (tilemap.GetTile(new Vector3Int(x, y, startPos.z)) != null)
                {
                    // Create MaskCell on the cell position
                    Vector3 position = tilemap.CellToWorld(new Vector3Int(x, y, startPos.z)) + new Vector3(0.5f, 0.5f, 0);
                    GameObject cellMask = Instantiate(cellMaskPrefab, position, Quaternion.identity);
                    cellMask.transform.SetParent(maskParentObj.transform);
                    // Set its sprite
                    cellMask.GetComponent<SpriteMask>().sprite = tilemap.GetSprite(new Vector3Int(x, y, startPos.z));
                }
            }
        }
    }
}
