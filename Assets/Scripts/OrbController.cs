using UnityEngine;
using UnityEngine.Tilemaps;

public class OrbController : MonoBehaviour
{
    private GameObject player;
    private ThrowOrb throwOrb;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        throwOrb = player.GetComponent<ThrowOrb>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            /*
            Destroy(gameObject);
            player.transform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
            throwOrb.isAlive = false;
            */

            Tilemap tilemap = collision.GetComponent<Tilemap>();
            
            Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
            TileBase tile = tilemap.GetTile(cellPosition);

            if (tile == null)
            {
                // Check adjacent cells (up, down, left, right)
                tile = tilemap.GetTile(cellPosition + Vector3Int.up) ??
                        tilemap.GetTile(cellPosition + Vector3Int.down) ??
                        tilemap.GetTile(cellPosition + Vector3Int.left) ??
                        tilemap.GetTile(cellPosition + Vector3Int.right);
            }

            if (tile != null)
            {
                string tileName = tile.name;
                float unstuckDist = 0.5f;

                if (tileName == "tileset_3") // Floor tile name
                {
                    Destroy(gameObject);
                    player.transform.position = new Vector2(transform.position.x, transform.position.y + unstuckDist);
                    throwOrb.isAlive = false;
                }
                else if (tileName == "tileset_11") // Ceiling tile name
                {
                    Destroy(gameObject);
                    player.transform.position = new Vector2(transform.position.x, transform.position.y - unstuckDist);
                    throwOrb.isAlive = false;
                }
                else if (tileName == "tileset_9") // Left tile name
                {
                    Destroy(gameObject);
                    player.transform.position = new Vector2(transform.position.x + unstuckDist, transform.position.y);
                    throwOrb.isAlive = false;
                }
                else if (tileName == "tileset_7") // Right tile name
                {
                    Destroy(gameObject);
                    player.transform.position = new Vector2(transform.position.x - unstuckDist, transform.position.y);
                    throwOrb.isAlive = false;
                }
                else
                {
                    Destroy(gameObject);
                    player.transform.position = transform.position;
                    throwOrb.isAlive = false;
                }
            }
            else Debug.LogWarning("No tile found at the cell position: " + cellPosition);
        }
        else if (collision.CompareTag("Spike") || collision.CompareTag("DoorPart") || collision.CompareTag("Portal"))
        {
            Destroy(gameObject);
            player.transform.position = transform.position;
            throwOrb.isAlive = false;
        }
    }
}
