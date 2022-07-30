using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEvents : MonoBehaviour
{
    public static class SoundConfig
    {
        public static event Action<bool> onSound;

        public static void SoundedGame(bool value)
        {
            if (onSound != null)
            {
                onSound(value);
            }
        }
    }

    public static class GamePlay
    {
        public static event Action<bool> onPause;

        public static void PausedGame(bool value)
        {
            if (onPause != null)
            {
                onPause(value);
            }
        }
    }
}
