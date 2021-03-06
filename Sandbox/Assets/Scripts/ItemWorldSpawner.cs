﻿using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;
    public bool canDragDrop = false;

    // TODO: I had to change this from Awake to Start because in PlayerControl, I was using Start, which
    // gets called AFTER Awake, and this was trying to access the inventory object that hadn't been set yet...
    // as it's set in the Start of the Player
    private void Start()
    {
        ItemWorld.SpawnItem(transform.position, item, canDragDrop);
        Destroy(gameObject);
    }
}
