using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class GMbehave : MonoBehaviour
{
    public TMP_Text UIecho = null;
    public GAbehave GA = null;
    public float NumOfEgg = 0;
    public static GMbehave TheScrip = null;
    // Start is called before the first frame update
    void Start()
    {
        TheScrip = this;
        for (int i = 10; i > 0; i--)
        {
            GeneratePlane();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //J键实现切换控制模式，调用PLbehave类中的ToggleWaypointMode方法
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            PLbehave.ToggleWaypointMode();
        }

        UIecho.text =
                "Control Mode:(" + GA.whatControlMode() + ")\n" +
                " Num of Touch:(" + GA.NumOfTouch + ")\n" +
                " Egg:" + "(" + NumOfEgg + ")\n" +
                " Total Enemy:(10)\n" +
                " Total Destory:" + "(" + PLbehave.TotalNumDestory + ")\n" +
                " Waypoint Mode:(" + PLbehave.GetWaypointModeName() + ")";


        if (Keyboard.current.qKey.isPressed)
        {
            Application.Quit();
        }

    }

    public void EggChange(bool isAdd)
    {
        if (isAdd)
        {
            NumOfEgg++;
        }
        else
        {
            NumOfEgg--;
        }
    }

    private void GeneratePlane()
    {
        GameObject plane = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
    }

    public bool isInBound(Vector3 Eggp)
    {
        float h = Camera.main.orthographicSize * 2;
        float w = h * Camera.main.aspect;
        Vector3 p = Camera.main.transform.localPosition;
        p.z = Eggp.z;
        Bounds camBounds = new Bounds(p, new Vector3(w, h, 2));
        return camBounds.Contains(Eggp);
    }
}
