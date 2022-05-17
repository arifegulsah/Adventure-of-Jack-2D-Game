using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;
    private bool moveCaneraEnable = true;

    void Update()
    {
        if (moveCaneraEnable)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        }
        else
        {

        }
    }

    public void SetMoveCameraEnable(bool localParam)
    {
        moveCaneraEnable = localParam;
;
    }
}
