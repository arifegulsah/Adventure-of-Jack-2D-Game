
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;

    //zýpladý mý yere deðdi mi? merdivene týrmanýyor mu suan?
    //isclimbing public olmalý çünkü Ladder.cs fileýmda kullanýyorum
    private bool isJumping;
    private bool isGrounded;
    [HideInInspector] //Ara yüzden gizlemek için yaptýk. Protected yapmamýz neden iþe yaramadý ve hataya sebep oldu??
    public bool isClimbing;

    //yere deðip deðmediðini kontrol edecek oldugum deðiþkenler
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers; 

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;


    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla PlayerMovement örneði var!!!");
            return;
        }
        instance = this;
    }


    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.deltaTime;

        //karakter havadayken ayaðý yere deðene kadar tekrar zýplamasýný engelle
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity); //Speed ismini verdiðim animasyon geçiþi
        animator.SetBool("isClimbing", isClimbing); //isClimbing isimini verdiðim animasyon geçiþi
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        MovePlayer(horizontalMovement, verticalMovement);
    }

    //Bu fonskiyon karakterimizi yatay ve dikey eksende hareket ettirir
    //Yalnýz karakterimiz eðer merdiven týrmanýyor ise karakterin saða sola hareket etmemesi gerekir. Sadece Y ekseninde hareketini saðlamalýyýz.
    //Bu yüzden isclimbing bool  deðiþkenimizi contiiton olarak kullanýyoruz.
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
        //Eðer týrmanýyorsa X ekseninde hareketi kýsýtlansýn!!!
        else
        {
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
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