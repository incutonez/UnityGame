using System.Collections;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator animator;
    public new RectTransform transform;
    public new BoxCollider2D collider;

    private Vector3 lastMovement;
    private SpriteRenderer shield;
    private SpriteRenderer shieldLeft;
    private SpriteRenderer shieldRight;
    private WorldObjectSize worldObjectSize;
    private RectTransform swordTransform;
    private SpriteRenderer swordRenderer;
    private GameObject body;
    private const float ATTACK_LENGTH = 0.3f;

    private void Start()
    {
        worldObjectSize = GetComponent<WorldObjectSize>();
        body = transform.GetChild(0).gameObject;
        shield = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        shieldRight = transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>();
        shieldLeft = transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>();
        GameObject sword = transform.GetChild(4).gameObject;
        swordTransform = sword.GetComponent<RectTransform>();
        swordRenderer = sword.GetComponent<SpriteRenderer>();
        Vector3 spriteSize = body.GetComponent<SpriteRenderer>().sprite.bounds.size;
        // Need to make sure our character is sized properly with both the transform and collider
        worldObjectSize.SetObjectSize(spriteSize);
    }

    // Idea taken from https://www.youtube.com/watch?v=Bf_5qIt9Gr8
    public void Animate(Vector3 movement)
    {
        if (movement == Vector3.zero)
        {
            Idle(movement);
        }
        else
        {
            lastMovement = movement;
            Walk(movement);
        }
        // Idea from https://gamedev.stackexchange.com/questions/125464/multiple-sprite-animation-layers-overlayed-in-unity-animator
        // If we were last moving down or we haven't moved at all
        shield.enabled = lastMovement.y == -1f || lastMovement == Vector3.zero;
        shieldLeft.enabled = lastMovement.x < 0f;
        shieldRight.enabled = lastMovement.x > 0f;
    }

    public void Idle(Vector3 movement)
    {
        animator.SetBool("isMoving", false);
    }

    public void Walk(Vector3 movement)
    {
        animator.SetFloat("xMove", movement.x);
        animator.SetFloat("yMove", movement.y);
        animator.SetBool("isMoving", true);
    }

    public IEnumerator Attack()
    {
        animator.SetBool("isMoving", false);
        animator.SetBool("isAttacking", true);
        shield.enabled = false;
        shieldLeft.enabled = false;
        shieldRight.enabled = false;
        swordRenderer.enabled = true;
        if (lastMovement.x > 0)
        {
            swordTransform.localPosition = Constants.SWORD_RIGHT;
            swordTransform.localRotation = Constants.SWORD_X_ROTATION;
            swordRenderer.flipY = false;
        }
        else if (lastMovement.x < 0)
        {
            swordTransform.localPosition = Constants.SWORD_LEFT;
            swordTransform.localRotation = Constants.SWORD_X_ROTATION;
            swordRenderer.flipY = true;
        }
        else if (lastMovement.y > 0)
        {
            swordTransform.localPosition = Constants.SWORD_UP;
            swordTransform.localRotation = Constants.SWORD_Y_ROTATION;
            swordRenderer.flipY = false;
        }
        else if (lastMovement.y < 0 || lastMovement == Vector3.zero)
        {
            swordTransform.localPosition = Constants.SWORD_DOWN;
            swordTransform.localRotation = Constants.SWORD_Y_ROTATION;
            swordRenderer.flipY = true;
        }
        // TODOJEF: Have to determine which Sword FX should play... need to know if at full health
        AudioManager.Instance.PlayFX(Enums.Audio.FX.SwordSlash);
        yield return new WaitForSeconds(ATTACK_LENGTH);
        animator.SetBool("isAttacking", false);
        swordRenderer.enabled = false;
    }
}
