
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    //z�plad� m� yere de�di mi? merdivene t�rman�yor mu suan?
    //isclimbing public olmal� ��nk� Ladder.cs file�mda kullan�yorum
    private bool isJumping;
    private bool isGrounded;
    public bool isClimbing;

    //yere de�ip de�medi�ini kontrol edecek oldugum de�i�kenler
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers; 

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        //karakter havadayken aya�� yere de�ene kadar tekrar z�plamas�n� engelle
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        MovePlayer(horizontalMovement, verticalMovement);
    }

    //Bu fonskiyon karakterimizi yatay ve dikey eksende hareket ettirir
    //Yaln�z karakterimiz e�er merdiven t�rman�yor ise karakterin sa�a sola hareket etmemesi gerekir. Sadece Y ekseninde hareketini sa�lamal�y�z.
    //Bu y�zden isclimbing bool  de�i�kenimizi contiiton olarak kullan�yoruz.
    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if (!isClimbing)
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

            if (isJumping == true)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        //E�er t�rman�yorsa X ekseninde hareketi k�s�tlans�n!!!
        else
        {
            Vector3 targetVelocity = new Vector2(rb.velocity.x, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        }
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false; 
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}