using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }
}


public enum CollectableType
{
    NONE, WHEAT_SEED
}