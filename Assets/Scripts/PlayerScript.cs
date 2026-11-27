using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float horizontalInput;
    private float moveSpeed = 7f;
    private float jumpPower = 8f;
    private bool isFacingRight = true;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private DoubtMeter doubtMeter;
    [SerializeField] private float doubtPerSecond = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        doubtMeter = FindFirstObjectByType<DoubtMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isJumping = true;
        }
        FlipSprite();
        float xSpeed = rb.linearVelocity.x;
        anim.SetFloat("Speed", Mathf.Abs(xSpeed));
        anim.SetBool("IsJumping", isJumping);
        //if player is looking left increse doubt
        if (!isFacingRight && doubtMeter != null)
        {
            doubtMeter.AddDoubt(doubtPerSecond * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    isJumping = false;
}

}
