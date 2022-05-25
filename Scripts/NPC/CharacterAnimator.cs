using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{

    [SerializeField] List<Sprite> walkDownSprites;
    [SerializeField] List<Sprite> walkUpSprites;
    [SerializeField] List<Sprite> walkLeftSprites;
    [SerializeField] List<Sprite> walkRightSprites;

    [SerializeField] FacingDirection defaultDirection = FacingDirection.Down;
    FacingDirection currentDirection;

    [SerializeField] List<Sprite> idleDownSprites;
    [SerializeField] List<Sprite> idleUpSprites;
    [SerializeField] List<Sprite> idleLeftSprites;
    [SerializeField] List<Sprite> idleRightSprites;

    public float MoveX { get; set; }
    public float MoveY { get; set; }
    public bool IsMoving { get; set; }

    SpriteAnimator walkDownAnim;
    SpriteAnimator walkUpAnim;
    SpriteAnimator walkLeftAnim;
    SpriteAnimator walkRightAnim;

    SpriteAnimator idleDownAnim;
    SpriteAnimator idleUpAnim;
    SpriteAnimator idleLeftAnim;
    SpriteAnimator idleRightAnim;

    SpriteAnimator currentAnim;
    bool wasPreviouslyMoving;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        walkDownAnim = new SpriteAnimator(walkDownSprites, spriteRenderer);
        walkUpAnim = new SpriteAnimator(walkUpSprites, spriteRenderer);
        walkLeftAnim = new SpriteAnimator(walkLeftSprites, spriteRenderer);
        walkRightAnim = new SpriteAnimator(walkRightSprites, spriteRenderer);

        idleDownAnim = new SpriteAnimator(idleDownSprites, spriteRenderer);
        idleUpAnim = new SpriteAnimator(idleUpSprites, spriteRenderer);
        idleLeftAnim = new SpriteAnimator(idleLeftSprites, spriteRenderer);
        idleRightAnim = new SpriteAnimator(idleRightSprites, spriteRenderer);

        SetFacingDirection(defaultDirection);

        currentAnim = idleDownAnim;
    }

    private void Update()
    {
        var prevAnim = currentAnim;

        if (MoveY == 1)
        {
            currentAnim = walkUpAnim;
            currentDirection = FacingDirection.Up;
        }

        else if (MoveY == -1)
        {
            currentAnim = walkDownAnim;
            currentDirection = FacingDirection.Down;
        }
        else if (MoveX == -1)
        {
            currentAnim = walkLeftAnim;
            currentDirection = FacingDirection.Left;
        }
        else if (MoveX == 1)
        {
            currentAnim = walkRightAnim;
            currentDirection = FacingDirection.Right;
        }

        if (!IsMoving)
        {
            if (currentDirection == FacingDirection.Up)
            {
                currentAnim = idleUpAnim;
            }
            else if (currentDirection == FacingDirection.Down)
            {
                currentAnim = idleDownAnim;
            }

            else if (currentDirection == FacingDirection.Left)
            {
                currentAnim = idleLeftAnim;
            }
            else if (currentDirection == FacingDirection.Right)
            {
                currentAnim = idleRightAnim;
            }
        }

        if (currentAnim != prevAnim || IsMoving != wasPreviouslyMoving) {
        currentAnim.Start();
          }

        currentAnim.HandleUpdate();
        wasPreviouslyMoving = IsMoving;

    }


    public void SetFacingDirection(FacingDirection dir)
    {
        if (dir == FacingDirection.Right)
            MoveX = 1;
        else if (dir ==FacingDirection.Left)
            MoveX = -1;
        else if (dir == FacingDirection.Down)
            MoveY = -1;
        else if (dir == FacingDirection.Up)
            MoveY = 1;
    }
 
}

public enum FacingDirection {  Up, Down, Left, Right }
