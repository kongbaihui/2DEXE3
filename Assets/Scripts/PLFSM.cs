using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PLbehave : MonoBehaviour
{
    private static bool LogicFollow = true;


    private enum FollowState
    {
        TheA, TheB, TheC, TheD, TheE, TheF
    }
    private FollowState nowState = FollowState.TheA;

    public GameObject PA = null;
    public GameObject PB = null;
    public GameObject PC = null;
    public GameObject PD = null;
    public GameObject PE = null;
    public GameObject PF = null;
    public GameObject nowP = null;
    private void UpdateFSM()
    {
        if (LogicFollow)
        {
            switch (nowState)
            {
                case FollowState.TheA:
                    nowState = FollowState.TheB;
                    nowP = PB;
                    break;

                case FollowState.TheB:
                    nowState = FollowState.TheC;
                    nowP = PC;
                    break;

                case FollowState.TheC:
                    nowState = FollowState.TheD;
                    nowP = PD;
                    break;

                case FollowState.TheD:
                    nowState = FollowState.TheE;
                    nowP = PE;
                    break;

                case FollowState.TheE:
                    nowState = FollowState.TheF;
                    nowP = PF;
                    break;

                case FollowState.TheF:
                    nowState = FollowState.TheA;
                    nowP = PA;
                    break;
            }
        }
        else
        {
            int currentIndex = (int)nowState;
            int randomIndex;

            do
            {
                randomIndex = Random.Range(0, 6);
            }
            while (randomIndex == currentIndex);

            switch (randomIndex)
            {
                case 0:
                    nowState = FollowState.TheA;
                    nowP = PA;
                    break;

                case 1:
                    nowState = FollowState.TheB;
                    nowP = PB;
                    break;

                case 2:
                    nowState = FollowState.TheC;
                    nowP = PC;
                    break;

                case 3:
                    nowState = FollowState.TheD;
                    nowP = PD;
                    break;

                case 4:
                    nowState = FollowState.TheE;
                    nowP = PE;
                    break;

                case 5:
                    nowState = FollowState.TheF;
                    nowP = PF;
                    break;
            }
        }
    }
    public static void ToggleWaypointMode()
    {
        LogicFollow = !LogicFollow;
    }
    public static string GetWaypointModeName()
    {
        return LogicFollow ? "Sequence" : "Random";
    }
}
