using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pointbehave : MonoBehaviour
{
    public bool isVisiable = true;
    private Vector3 InitialPosition;
    private float hitCount = 3;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.localPosition;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            isVisiable = !isVisiable;
        }

        if (isVisiable)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }

    private void ChangePosition()
    {
        Vector3 p = InitialPosition;
        Vector3 delta;
        delta.x = Random.Range(-15f, 15f);
        delta.y = Random.Range(-15f, 15f);
        delta.z = 0f;
        transform.localPosition = p + delta;
        hitCount = 3;
        Color tempcolor = sr.color;
        tempcolor.a = 1;
        sr.color = tempcolor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EGGbehave>() != null && isVisiable)
        {
            if (hitCount > 0)
            {
                hitCount--;
                Color tempcolor = sr.color;
                tempcolor.a = Mathf.Max(0f, tempcolor.a - 0.25f);
                sr.color = tempcolor;
            }
            else
            {
                ChangePosition();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EGGbehave>() != null && isVisiable)
        {
            if (hitCount > 0)
            {
                hitCount--;
                Color tempcolor = sr.color;
                tempcolor.a = Mathf.Max(0f, tempcolor.a - 0.25f);
                sr.color = tempcolor;
            }
            else
            {
                ChangePosition();
            }
        }
    }
}
