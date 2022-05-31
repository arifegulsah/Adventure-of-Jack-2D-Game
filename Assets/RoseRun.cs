using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseRun : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    //hasarý dinamik vermek için buradaki deðiþkende tutuyorum
    public int damageOnCollision = 20;



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

        //düþman neredeyse hedefindeyse
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(snakeBitSound, transform.position);
        }
    }
}
