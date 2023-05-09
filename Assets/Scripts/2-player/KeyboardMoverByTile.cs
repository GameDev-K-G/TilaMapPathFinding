using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component allows the player to move by clicking the arrow keys,
 * but only if the new position is on an allowed tile.
 */
public class KeyboardMoverByTile: KeyboardMover {
   [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTiles allowedTiles = null;
    [SerializeField] TileBase grass = null;
    [SerializeField] TileBase m = null;
    [SerializeField] TileBase s = null;
    [SerializeField] TileBase s1 = null;
    [SerializeField] TileBase s2 = null;
    
    // [SerializeField] GameObject p1 = null;
     public float downTime, upTime, pressTime = 0;
    public float countDown = 0.3f;
    public bool ready = false;
   [SerializeField] bool hasgoat = false;

    private TileBase TileOnPosition(Vector3 worldPosition) {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

     private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "goat") {
            allowedTiles.addtile(m);
              Destroy(other.gameObject);
        }
         if (other.tag == "boat") {
            allowedTiles.addtile(s);
            allowedTiles.addtile(s1);
            allowedTiles.addtile(s2);
             Destroy(other.gameObject);
             
        }
         if (other.tag == "hammer") {
             hasgoat = true;
       
      
            Destroy(other.gameObject);
         //   Destroy(this.gameObject);
         
        }
          

         
         
        //  particleSystem.Play();
         Destroy(other.gameObject);
          
         
        }
    
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(triggeringTag))
        
        {
            
  
    }

    }

    void Update()  {
        
        Vector3 newPosition = NewPosition();
        Vector3Int p = tilemap.WorldToCell(newPosition);
        TileBase tileOnNewPosition = TileOnPosition(newPosition);
        Vector3Int ans = tilemap.LocalToCell(getDelpos());


        if (Input.GetKeyDown(KeyCode.Space) && hasgoat && ready == false)
        {
            downTime = Time.time;
            pressTime = downTime + countDown;
            ready = true;
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ready = false;
        }
        if (Time.time >= pressTime && ready == true)
        {
            ready = false;
            Debug.Log("yourPos : " + transform.position + " ans: " + ans);
            tilemap.SetTile(ans, grass);
        }

        if (allowedTiles.Contain(tileOnNewPosition)) {
            transform.position = newPosition;
        } else {
            Debug.Log("new position: " + newPosition);
            Debug.Log("player: " + transform.position);
            Debug.Log("p: " + p);
            Debug.Log("You cannot walk on " + tileOnNewPosition + "!");
        }
        
        
        
            
        
        }

    
}