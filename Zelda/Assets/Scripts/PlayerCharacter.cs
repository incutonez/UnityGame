using Enums;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public UIInventory uiInventory;
    public Rigidbody2D rb2d;
    public const float SPEED = 1f;
    public CharacterAnimation animator;

    private Inventory inventory;
    private Vector3 movement;

    private void Awake()
    {
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
        uiInventory.SetPlayer(this);
    }

    private void Start()
    {
        SpriteRenderer shield = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        shield.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Items.PotionBlue:
                // TODOJEF: Flash character red
                inventory.RemoveItem(new Item { itemType = item.itemType, amount = 1 });
                break;
        }
    }

    // Taken from https://www.youtube.com/watch?v=Bf_5qIt9Gr8
    public void Move()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveY = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }

        movement = new Vector3(moveX, moveY).normalized;
        animator.Animate(movement);
    }

    private void FixedUpdate()
    {
        // Taken from https://www.youtube.com/watch?v=Bf_5qIt9Gr8
        rb2d.velocity = movement * SPEED;
    }
}
