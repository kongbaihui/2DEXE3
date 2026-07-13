using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PLbehave : MonoBehaviour
{
    private bool LogicFollow = true;
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
    }


}
