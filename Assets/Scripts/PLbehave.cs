using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PLbehave : MonoBehaviour
{
    private float hitCount = 3;
    private SpriteRenderer sr;
    public static float TotalNumDestory = 0;
    public float PLSpeed = 20f;
    public float PLRotateSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        PA = GameObject.Find("TheA");
        PB = GameObject.Find("TheB");
        PC = GameObject.Find("TheC");
        PD = GameObject.Find("TheD");
        PE = GameObject.Find("TheE");
        PF = GameObject.Find("TheF");
        nowP = PA;
        sr = GetComponent<SpriteRenderer>();
        changePosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (nowP == null)
        {
            return;
        }

        PointAtPosition(
            nowP.transform.localPosition,
            0.03f / 60f
        );

        transform.localPosition +=
            PLSpeed * Time.deltaTime * transform.up;

        if (Vector3.Distance(
                transform.localPosition,
                nowP.transform.localPosition
            ) <= 25f)
        {
            UpdateFSM();
        }
    }


    private void changePosition()
    {
        float halfh = Camera.main.orthographicSize;
        float halfw = halfh * Camera.main.aspect;
        Vector3 p;
        p.x = Random.Range(-0.9f * halfw, 0.9f * halfw);
        p.y = Random.Range(-0.9f * halfh, 0.9f * halfh);
        p.z = 0;
        transform.localPosition = p;
    }

    public void PLReset()
    {
        nowP = PA;
        TotalNumDestory++;
        hitCount = 3;
        Color tempcolor = sr.color;
        tempcolor.a = 1;
        sr.color = tempcolor;
        changePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GAbehave>() != null || collision.gameObject.GetComponent<EGGbehave>() != null)
        {
            if (hitCount > 0)
            {
                hitCount--;
                Color tempcolor = sr.color;
                tempcolor.a *= 0.8f;
                sr.color = tempcolor;
            }
            else
            {
                PLReset();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GAbehave>() != null || collision.gameObject.GetComponent<EGGbehave>() != null)
        {
            if (hitCount > 0)
            {
                hitCount--;
                Color tempcolor = sr.color;
                tempcolor.a *= 0.8f;
                sr.color = tempcolor;
            }
            else
            {
                PLReset();
            }
        }
        else if (collision.gameObject.GetComponent<Pointbehave>() != null)
        {
            //UpdateFSM();
        }
    }


    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.localPosition;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }

}
