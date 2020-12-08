using Enums;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public UIInventory uiInventory;
    public Rigidbody2D rb2d;
    public const float SPEED = 1f;
    public CharacterAnimation characterAnimation;
    public Animator animator;

    private Inventory inventory;
    private Vector3 movement;
    private float? attackTimer;
    // This is the minimum value used to determine when to stop the attack animation
    private const float ATTACK_MIN = 0.5f;
    // This is the maximum value used to determine when the player can attack again
    private const float ATTACK_MAX = 0.8f;

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
        bool isAttacking = attackTimer.HasValue;

        if (!attackTimer.HasValue && Input.GetKey(KeyCode.RightControl))
        {
            // Start the timer
            attackTimer = 0f;
        }
        else if (attackTimer.HasValue && attackTimer.Value < ATTACK_MIN)
        {
            attackTimer += Time.deltaTime;
        }
        else
        {
            isAttacking = false;
            if (attackTimer.HasValue && attackTimer.Value < ATTACK_MAX)
            {
                attackTimer += Time.deltaTime;
            }
            else
            {
                attackTimer = null;
            }
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
        }

        movement = new Vector3(moveX, moveY).normalized;
        characterAnimation.Animate(movement, isAttacking);
    }

    private void FixedUpdate()
    {
        // Taken from https://www.youtube.com/watch?v=Bf_5qIt9Gr8
        rb2d.velocity = movement * SPEED;
    }
}
