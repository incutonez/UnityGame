using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public CharacterBase charBase;
    public Animator animator;
    public Rigidbody2D rb2d;

    private Vector3 lastMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float speed = 1f;
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

        if (moveX == 0 && moveY == 0)
        {
            charBase.IdleAnimation(Vector3.zero);
            animator.SetBool("isMoving", false);
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            Vector3 moveVect = new Vector3(moveX, moveY).normalized;
            charBase.WalkAnimation(moveVect);
            //transform.position += moveVect * speed * Time.deltaTime;
            animator.SetFloat("xMove", moveVect.x);
            animator.SetFloat("yMove", moveVect.y);
            animator.SetBool("isMoving", true);
            lastMove = moveVect;
            rb2d.velocity = moveVect * speed;
        }
    }
}
