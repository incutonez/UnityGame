using Assets.Weapons;
using Assets.Weapons.Sword;
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

    private Rigidbody2D rb2d;
    private Animator anim;
    private int count = 0;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        winText.enabled = false;
        SetCountText();
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Diagnostics.Debug.WriteLine("OnCollisionStay2D");
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
        if (collision.gameObject.CompareTag("Pickup"))
        {
            var weapon = (WeaponDisplay) collision.gameObject.GetComponent("WeaponDisplay");
            if (weapon.sword == Swords.Wooden)
            {
                sword = ScriptableObject.CreateInstance<Wooden>();
            }
            else if (weapon.sword == Swords.Steel)
            {
                sword = ScriptableObject.CreateInstance<Steel>();
            }
            else if (weapon.sword == Swords.MetallicGlass)
            {
                sword = ScriptableObject.CreateInstance<MetallicGlass>();
            }
            else if (weapon.sword == Swords.Diamond)
            {
                sword = ScriptableObject.CreateInstance<Diamond>();
            }
            Destroy(collision.gameObject);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = $"Count: {count.ToString()}";
        if (count >= 2)
        {
            winText.enabled = true;
        }
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
