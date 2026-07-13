using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;
public class GAbehave : MonoBehaviour
{
    public bool MouseControl = true;
    public float GASpeed = 20f;
    public float GARotateSpeed = 45f;
    public float EggSpawnInterv = 0.2f;
    private float EggSpawnAt = 0;
    public float NumOfTouch = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //control----------------------------------------------------------------

        if (Keyboard.current.mKey.wasPressedThisFrame) { MouseControl = !MouseControl; }

        Vector3 GAp = transform.localPosition;
        if (MouseControl)
        {
            GAp = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            GAp.z = 0;
        }
        else
        {
            GAp += GASpeed * Time.smoothDeltaTime * transform.up;
            if (Keyboard.current.wKey.isPressed) { GASpeed += 0.2f; }
            if (Keyboard.current.sKey.isPressed) { GASpeed -= 0.2f; }
        }
        transform.localPosition = GAp;

        if (Keyboard.current.aKey.isPressed)
        { transform.Rotate(transform.forward, GARotateSpeed * Time.smoothDeltaTime); }

        if (Keyboard.current.dKey.isPressed)
        { transform.Rotate(transform.forward, -GARotateSpeed * Time.smoothDeltaTime); }

        //---------------------------------------------------------------------------

        if (Keyboard.current.spaceKey.isPressed)
        {
            if ((Time.time - EggSpawnAt) > EggSpawnInterv)
            {
                GenerateEgg();
                EggSpawnAt = Time.time;
            }
        }
    }


    private void GenerateEgg()
    {
        GameObject egg = Instantiate(Resources.Load("Prefabs/Egg") as GameObject);
        egg.transform.localPosition = transform.localPosition;
        egg.transform.localRotation = transform.localRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PLbehave pl = collision.gameObject.GetComponent<PLbehave>();
        if (pl != null)
        {
            pl.PLReset();
            NumOfTouch++;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PLbehave pl = collision.gameObject.GetComponent<PLbehave>();
        if (pl != null)
        {
            pl.PLReset();
            NumOfTouch++;
        }

    }

    public string whatControlMode()
    {
        if (MouseControl)
        {
            return "Mouse";
        }
        else
        {
            return "Keyboard";
        }
    }
}
