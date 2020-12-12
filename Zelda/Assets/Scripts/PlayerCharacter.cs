using System.Collections;
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
    private bool isAttacking = false;
    private float? lastAttack = 0f;

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

    public IEnumerator Attack()
    {
        if (inventory.hasSword)
        {
            isAttacking = true;
            yield return StartCoroutine(characterAnimation.Attack());
            lastAttack = Constants.ATTACK_DELAY;
            isAttacking = false;
        }
    }

    // Taken from https://www.youtube.com/watch?v=Bf_5qIt9Gr8
    public void Move()
    {
        if (!isAttacking)
        {
            if (!lastAttack.HasValue && Input.GetKey(KeyCode.RightControl))
            {
                StartCoroutine(Attack());
            }
            else
            {
                float moveX = 0f;
                float moveY = 0f;
                if (lastAttack.HasValue)
                {
                    // Keep decrementing until we've hit the threshold
                    lastAttack -= Time.deltaTime;
                    if (lastAttack <= Constants.ATTACK_DELAY_THRESHOLD)
                    {
                        lastAttack = null;
                    }
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
                movement = new Vector3(moveX, moveY).normalized;
                characterAnimation.Animate(movement);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isAttacking)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            // Taken from https://www.youtube.com/watch?v=Bf_5qIt9Gr8
            rb2d.velocity = movement * SPEED;
        }
    }
}
