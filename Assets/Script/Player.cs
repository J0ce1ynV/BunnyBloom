using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    private void Awake()
    {
        inventory = new Inventory(20);
    }

    //public void DropItem(Collectable item)
    //{
    //    Vector3 spawnLocation = transform.position;
    //    Vector2 spwanOffset = Random.insideUnitCircle * 1.25f;

    //    float randX = Random.Range(-1f, 1f);
    //    float randY = Random.Range(-1f, 1f);

    //    Vector3 spawnOffset = new Vector3(randX, randY, 0f).normalized;

    //    Collectable droppedItem = Instantiate(item, spawnLocation+spawnOffset, Quaternion.identity);
    //    droppedItem.rb.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
    //}

    public void DropItem(Collectable item)
    {
        Vector3 spawnLocation = transform.position;

        float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(-1f, 1f);

        Vector3 spawnOffset = new Vector3(randX, randY, 0f).normalized;

        Collectable droppedItem = Instantiate(
            item,
            spawnLocation + spawnOffset * 2f,
            Quaternion.identity
        );
        Debug.Log("ITEM DROP: " + droppedItem.name);
        droppedItem.rb.AddForce(spawnOffset * 0.2f, ForceMode2D.Impulse);
    }
}
