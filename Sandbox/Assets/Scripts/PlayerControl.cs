using Assets.Weapons;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10f;
    public float jump = 400f;
    public bool isGrounded = true;
    public bool isFacedRight = false;
    public float distanceToGround = 0f;
    public Text countText;
    public Text winText;
    public Weapon sword;
    public Inventory inventory;

    [SerializeField]
    private UIInventory uiInventory;
    private Rigidbody2D rb2d;
    private Animator anim;
    private int count = 0;

    private void Awake()
    {
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
        uiInventory.SetPlayer(this);
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        winText.enabled = false;
        SetCountText();
    }

    void FixedUpdate()
    {
        // Grabs input from player on keyboard
        // Keys are set by default in Input Manager
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(0f, 0f);
        if (isGrounded)
        {
            movement = new Vector2(moveX, moveY);
            // +x is to the right
            if (moveX > 0 && !isFacedRight || moveX < 0 && isFacedRight)
            {
                ChangeDirection();
            }
        }
        if (moveY > 0 && isGrounded)
        {
            isGrounded = false;
            moveY = jump;
            movement = new Vector2(0f, moveY);
            anim.SetBool("Ground", false);
        }
        /* Had to change Edit > Project Settings > Player > Other Settings
         * > Active Input Handling to "Both" to be able to use this
         * per https://forum.unity.com/threads/unity-render-pipeline-debug-clashes-with-new-input-system.735179/ */
        rb2d.AddForce(new Vector2(moveX, moveY));
        anim.SetFloat("Speed", Mathf.Abs(moveX));
        anim.SetFloat("vSpeed", Mathf.Abs(moveY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        Debug.unityLogger.Log("YO");
        if (itemWorld != null)
        {
            Debug.unityLogger.Log("IN");
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = $"Count: {count.ToString()}";
        if (sword != null && sword.subSubType == Swords.Diamond)
        {
            winText.enabled = true;
        }
    }

    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case ItemTypes.Weapon:
                // TODOJEF: Flash character red
                inventory.RemoveItem(new Item { itemType = item.itemType, subType = item.subType, subSubType = item.subSubType, amount = 1 });
                break;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void ChangeDirection()
    {
        isFacedRight = !isFacedRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
