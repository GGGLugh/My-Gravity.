using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.LightAnchor;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;

    [SerializeField] private float jumpForce = 8.0f;

    [SerializeField] private  Transform groundChecker;

    [SerializeField] private float checkerRadius = 0.1f;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Vector2 FirstPosition = new Vector2(8f, -2f);

    private bool isGround = false;

    private Rigidbody2D rb;

    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private int Gvec=2;//0:重力なし　1:重力上　2:重力下　3:重力左　4;重力右
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Walk();
        Gravity();
        Jump();
    }

    private void Walk()
    {

        switch (Gvec)
        {

            case 1:

                if (Input.GetKey(KeyCode.A)&&isGround == true)
                {
                    float direction = Input.GetAxisRaw("Horizontal");
                    rb.linearVelocityX = direction * moveSpeed;
                    sr.flipX = false;
                    if ((Input.GetKey(KeyCode.UpArrow) && isGround == true) || (Input.GetKey(KeyCode.DownArrow) && isGround == true)){ rb.linearVelocityX = 0; }
                    if ((Input.GetKey(KeyCode.RightArrow) && isGround == true) || (Input.GetKey(KeyCode.LeftArrow) && isGround == true)) { rb.linearVelocityX = 0; }
                }


                else if (Input.GetKey(KeyCode.D) && isGround == true)
                {
                    float direction = Input.GetAxisRaw("Horizontal");
                    rb.linearVelocityX = direction * moveSpeed;
                    sr.flipX = true;
                    if ((Input.GetKey(KeyCode.UpArrow) && isGround == true) || (Input.GetKey(KeyCode.DownArrow) && isGround == true)) { rb.linearVelocityX = 0; }
                    if ((Input.GetKey(KeyCode.RightArrow) && isGround == true) || (Input.GetKey(KeyCode.LeftArrow) && isGround == true)) { rb.linearVelocityX = 0; }
                }

                
                else if (isGround == true) { rb.linearVelocityX = 0; }
                break;

            case 2:

                if (Input.GetKey(KeyCode.D) && isGround == true)
                {
                    float direction = Input.GetAxisRaw("Horizontal");
                    rb.linearVelocityX = direction * moveSpeed;
                    sr.flipX = false;
                    if ((Input.GetKey(KeyCode.UpArrow) && isGround == true) || (Input.GetKey(KeyCode.DownArrow) && isGround == true) || (Input.GetKey(KeyCode.RightArrow) && isGround == true) || (Input.GetKey(KeyCode.LeftArrow) && isGround == true)) { rb.linearVelocityX = 0; }
                }


                else if (Input.GetKey(KeyCode.A) && isGround == true)
                {
                    float direction = Input.GetAxisRaw("Horizontal");
                    rb.linearVelocityX = direction * moveSpeed;
                    sr.flipX = true;
                    if ((Input.GetKey(KeyCode.UpArrow) && isGround == true) || (Input.GetKey(KeyCode.DownArrow) && isGround == true) || (Input.GetKey(KeyCode.RightArrow) && isGround == true) || (Input.GetKey(KeyCode.LeftArrow) && isGround == true)) { rb.linearVelocityX = 0; }
                }
                else if (isGround == true) { rb.linearVelocityX = 0; }
                break;

            case 3:

                if (Input.GetKey(KeyCode.S)&& isGround == true)
                {
                    float direction = Input.GetAxisRaw("Vertical");
                    rb.linearVelocityY = direction * moveSpeed;
                    sr.flipX = false;
                    if ((Input.GetKey(KeyCode.UpArrow) && isGround == true) || (Input.GetKey(KeyCode.DownArrow) && isGround == true) || (Input.GetKey(KeyCode.RightArrow) && isGround == true) || (Input.GetKey(KeyCode.LeftArrow) && isGround == true)) { rb.linearVelocityY = 0; }
                }


                else if (Input.GetKey(KeyCode.W) && isGround == true)
                {
                    float direction = Input.GetAxisRaw("Vertical");
                    rb.linearVelocityY = direction * moveSpeed;
                    sr.flipX = true;
                    if ((Input.GetKey(KeyCode.UpArrow) && isGround == true) || (Input.GetKey(KeyCode.DownArrow) && isGround == true) || (Input.GetKey(KeyCode.RightArrow) && isGround == true) || (Input.GetKey(KeyCode.LeftArrow) && isGround == true)) { rb.linearVelocityY = 0; }
                }
                else if (isGround == true) { rb.linearVelocityY = 0; }
                break;

            case 4:

                if (Input.GetKey(KeyCode.W) && isGround == true)
                {
                    float direction = Input.GetAxisRaw("Vertical");
                    rb.linearVelocityY = direction * moveSpeed;
                    sr.flipX = false;
                    if ((Input.GetKey(KeyCode.UpArrow) && isGround == true) || (Input.GetKey(KeyCode.DownArrow) && isGround == true) || (Input.GetKey(KeyCode.RightArrow) && isGround == true) || (Input.GetKey(KeyCode.LeftArrow) && isGround == true)) { rb.linearVelocityY = 0; }
                }


                else if (Input.GetKey(KeyCode.S)  && isGround == true)
                {
                    float direction = Input.GetAxisRaw("Vertical");
                    rb.linearVelocityY = direction * moveSpeed;
                    sr.flipX = true;
                    if ((Input.GetKey(KeyCode.UpArrow) && isGround == true) || (Input.GetKey(KeyCode.DownArrow) && isGround == true) || (Input.GetKey(KeyCode.RightArrow) && isGround == true) || (Input.GetKey(KeyCode.LeftArrow) && isGround == true)) { rb.linearVelocityY = 0; }
                }
                
                    
                else if (isGround == true) { rb.linearVelocityY = 0; }
                break;

            
        }
        if (Input.GetKey(KeyCode.R))
        {
            rb.linearVelocityX = 0;
            rb.linearVelocityY = 0;
            Gvec = 2;
            transform.position = FirstPosition;
        }

    }

    private void Jump()
     {
        if(Physics2D.OverlapCircle(groundChecker.position,checkerRadius,groundLayer))
        {
            isGround = true;
        }
        else 
        {
            isGround = false;
        }

        switch (Gvec)
        {
            case 1:

                
                if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
                {
                    rb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
                }
                break;

            case 2:

                if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
                {

                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                }
                break;

            case 3:

                if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
                {

                    rb.AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);

                }
                break;

            case 4:

                if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
                {

                    rb.AddForce(Vector2.left * jumpForce, ForceMode2D.Impulse);

                }
                break;

        }
       

     }

    private void Gravity()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround == true)
        {
            Gvec = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGround == true)
        {
            Gvec = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isGround == true)
        {
            Gvec = 3;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && isGround == true)
        {
            Gvec = 4;
        }


        switch (Gvec) 
        {
            case 1:

                Physics2D.gravity = new Vector2(0f, 9.8f);
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;

            case 2:

                Physics2D.gravity = new Vector2(0f, -9.8f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;

            case 3:

                Physics2D.gravity = new Vector2(-9.8f, 0f);
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;

            case 4:

                Physics2D.gravity = new Vector2(9.8f, 0f);
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;

        }

    }

}