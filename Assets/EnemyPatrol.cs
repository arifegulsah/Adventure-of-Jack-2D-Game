using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // düþman sürekli a noktasýndan b noktasýna git gel yaparak seyahat halinde olacak
    // biz onu ortadan kaldýrana kadar


    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer graphics;

    private Transform target;
    private int destPoint = 0;


    void Start()
    {
        target = waypoints[0];

    }

    
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //düþman neredeyse hedefindeyse
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;

        }
    }
}
