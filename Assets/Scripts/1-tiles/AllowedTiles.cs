using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component just keeps a list of allowed tiles.
 * Such a list is used both for pathfinding and for movement.
 */
public class AllowedTiles : MonoBehaviour  {
    [SerializeField] TileBase[] allowedTiles = null;
    int i =4;

    public bool Contain(TileBase tile) {
        return allowedTiles.Contains(tile);
    }
     public TileBase[] addtile(TileBase tile) {
        allowedTiles[i]=tile;
        i=i+1;

        return allowedTiles;
    }

    public TileBase[] Get() { return allowedTiles;  }
}
