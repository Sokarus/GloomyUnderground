using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{
    public int damage = 1;

    private Animator animator;
    private int healPoints = 100;

    // Start is called before the first frame update
    protected override void Start()
    {
        animator = GetComponent<Animator>();

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.playersTurn)
        {
            return;
        }

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            vertical = 0;
        }

        if (vertical != 0 || horizontal != 0)
        {
            AttemptMove<Door>(horizontal, vertical);
        }
    }

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        base.AttemptMove<T>(xDir, yDir);

        GameManager.instance.playersTurn = false;
    }


    protected override void OnCantMove<T>(T component)
    {
        Door hitDoor = component as Door;
        hitDoor.Open();
        //animator.SetTrigger("playerChop");
    }

    public void TakeDamage(int damage)
    {
        //animator.SetTrigger("playerHit");
        healPoints -= damage;
    }
}
