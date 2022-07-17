using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTN_MuteSound : MonoBehaviour
{
    // Start is called before the first frame update
    public void BTN_Click()
    {
        ManagerEvents.SoundConfig.SoundedGame(!GameManager._instance.SoundActive);
    }
}
