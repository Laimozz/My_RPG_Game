using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D myRigidbody;

    [SerializeField] private CapsuleCollider2D myBody;

    [SerializeField] private BoxCollider2D myFeet;

    [SerializeField] private PlayerAnimations myPlayerAnimations;

    // [SerializeField] private PlayerHeath playerHeath;
    [SerializeField] private PlayerCtrl playerCtrl;

    [SerializeField] private float speedMove = 5f;

    [SerializeField] private float jumpHeight = 35f;

    private Vector2 moveInput;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myBody = GetComponent<CapsuleCollider2D>();

        myFeet = GetComponent<BoxCollider2D>();

        myPlayerAnimations = GetComponent<PlayerAnimations>();

        //playerHeath = GetComponent<PlayerHeath>();
        playerCtrl = GetComponent<PlayerCtrl>();


    }
 
    void Update()
    {
        if (playerCtrl.PlayerStats.hp <= 0) { return; }

        Run();
        Flip();
    }

    public void OnMove(InputValue value)
    {
        if (playerCtrl.PlayerStats.hp <= 0) { return; }

        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (playerCtrl.PlayerStats.hp <= 0) return;

        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0, jumpHeight);
            myPlayerAnimations.JumpState();
        }
    }

    public void Run()
    {
        if(myRigidbody.velocity.x == 0)
        {
            AudioManager.Instance.StopFootStep();
        }
        else
        {
            AudioManager.Instance.PlayFootStep();
        }

        myRigidbody.velocity = new Vector2(moveInput.x * speedMove, myRigidbody.velocity.y);

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        myPlayerAnimations.RunState(playerHasHorizontalSpeed);
    }
    public void Flip()
    {
        bool playerHasHorizontalSpeed  = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1);
        }

    }

}
