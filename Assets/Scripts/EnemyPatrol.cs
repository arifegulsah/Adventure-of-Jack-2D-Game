using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // d��man s�rekli a noktas�ndan b noktas�na git gel yaparak seyahat halinde olacak
    // biz onu ortadan kald�rana kadar


    public float speed;
    public Transform[] waypoints;

    //hasar� dinamik vermek i�in buradaki de�i�kende tutuyorum
    public int damageOnCollision = 20; 

    public SpriteRenderer graphics;

    private Transform target;
    private int destPoint = 0;

    public AudioClip snakeBitSound;

    void Start()
    {
        target = waypoints[0];

    }

    
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //d��man neredeyse hedefindeyse
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(snakeBitSound, transform.position);
            
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
            GameObject.Find("WeakSpot").SendMessage("SetScripActive", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("WeakSpot").SendMessage("SetScripActive", true);
    }
}
