using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, ICloseOpen
{
    public Sprite openedSprite;
    public Sprite closedSprite;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D thisRigidBody;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        thisRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    public void Open()
    {
        spriteRenderer.sprite = openedSprite;
        thisRigidBody.simulated = false;
    }

    public void Close()
    {
        spriteRenderer.sprite = closedSprite;
        thisRigidBody.simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Open();
    }
}
