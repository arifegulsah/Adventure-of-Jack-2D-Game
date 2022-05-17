using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;
    private bool moveCaneraEnable = true;

    public static CameraFollow instance;


    private bool isTriggered = false;

    public Camera cam;

    public float cameraColorChangeDelay = 0.1f;
    public float eachColorTime = 0.01f;

    public Color green = Color.green;
    public Color red = Color.red;
    public Color blue = Color.blue;
    public Color yellow = Color.yellow;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (moveCaneraEnable)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Sahnede birden fazla CameraFollow örneði var!!!");
            return;
        }
        instance = this;
    }

    public void SetMoveCameraEnable(bool localParam)
    {
        moveCaneraEnable = localParam;
;
    }


    public void ChangeColor(bool checkTrigger)
    {
        if (checkTrigger)
        {
            StartCoroutine(CameraColorChange());
            StartCoroutine(HandleColorDelay());
        }
    }

    public void ChangeColorOriginal(bool checkTrigger)
    {
        if (!checkTrigger)
        {
            cam.backgroundColor = green;
        }
    }
      
    public IEnumerator CameraColorChange()
    {
        cam.backgroundColor = red;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = blue;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = yellow;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = red;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = blue;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = yellow;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = red;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = blue;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = yellow;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = red;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = blue;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = yellow;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = green;
        yield return new WaitForSeconds(cameraColorChangeDelay);
        cam.backgroundColor = green;
        yield return new WaitForSeconds(cameraColorChangeDelay);
    }

    public IEnumerator HandleColorDelay()
    {
        yield return new WaitForSeconds(eachColorTime);
        isTriggered = false;
        ChangeColorOriginal(isTriggered);
    }
}
