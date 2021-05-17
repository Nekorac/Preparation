using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBack : MonoBehaviour
{
    bool init = false;
    float startXpos;
    Vector3 startPos;
    LineRenderer lr;
    bool grabbed = false;
    Rigidbody2D rb;
    [SerializeField] float force = 100f;
    bool launched = false;
    bool tooSlow;
    public Reset reseter;
    float speedTimer = 0;
    [SerializeField] float maxWindup = 2f;
    public GameObject wheelL;
    public GameObject wheelR;
    public Animator animL;
    public Animator animR;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startXpos = transform.position.x;
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {
            animL.enabled = false;
            animR.enabled = false;
            wheelL.transform.rotation = Quaternion.AngleAxis(100 * (startXpos - transform.position.x), Vector3.forward);
            wheelR.transform.rotation = Quaternion.AngleAxis(100 * (startXpos - transform.position.x), Vector3.forward);
        }
        if (grabbed)
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < startXpos)
            {
                if (startXpos - Camera.main.ScreenToWorldPoint(Input.mousePosition).x < maxWindup)
                {
                    SetTrailRendererPos();
                    transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    Launch();
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                grabbed = false;
            }
        }
        if (launched)
        {
            ResetIfTooSlow();
            animL.enabled = true;
            animR.enabled = true;
            animL.SetBool("Launched", true);
            animR.SetBool("Launched", true);
        }
    }

    private void ResetIfTooSlow()
    {
        tooSlow = rb.velocity.x < 0.1f && rb.velocity.y < 0.1f;
        if (tooSlow)
        {
            speedTimer += Time.deltaTime;
            if (speedTimer > 3.0f)
            {
                reseter.ResetScene();
            }
        }
        if (!tooSlow)
        {
            speedTimer = 0;
        }
    }

    private void Launch()
    {
        lr.enabled = false;
        rb.AddForce(new Vector2(force * Mathf.Abs(startXpos - transform.position.x), 0));
        grabbed = false;
        launched = true;
    }

    private void SetTrailRendererPos()
    {
        if (!init)
        {
            lr.enabled = true;
            lr.SetPosition(0, startPos);
            init = true;
        }
        lr.SetPosition(1, transform.position);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && !launched)
        {
            grabbed = true;
        }
    }

    public bool GetLaunchedBool()
    {
        return launched;
    }
}
