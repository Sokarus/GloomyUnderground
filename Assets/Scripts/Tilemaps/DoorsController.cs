using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorsController : MonoBehaviour
{
    public GameObject player;
    
    public TileBase openDoorTile;
    public TileBase closedDoorTile;

    private Tilemap _tilemap;
    private Camera _mainCamera;

    private void Start()
    {
        _tilemap = GetComponent<Tilemap>();
        _mainCamera = Camera.main;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.Equals(player)) return;
        Vector3 contactWorldPosition = collision.GetContact(0).point;
        Vector3Int clickedCellPosition = _tilemap.WorldToCell(contactWorldPosition);
        TileBase clickedTile = _tilemap.GetTile(clickedCellPosition);
        
        Debug.Log(contactWorldPosition);
        Debug.Log(clickedCellPosition);
        Debug.Log(clickedTile);
        
        if (clickedTile && clickedTile.Equals(closedDoorTile))
        {
            _tilemap.SetTile(clickedCellPosition, openDoorTile);
        }
    }
}
