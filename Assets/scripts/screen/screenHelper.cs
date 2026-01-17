using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Screens{
public class screenHelper : MonoBehaviour
{
    public ScreenType screenType;
    
    public void onClick()
        {
            screenManager.Instance.ShowByType(screenType);
        }
}

}