using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Levels
{
    public class Level1
    {
        public List<WaveMob> getWave(int waveNum)
        {
            List<WaveMob> wave = new List<WaveMob>();
            if (waveNum == 1)
            {
                WaveMob mob1 = new WaveMob("Snail", 1f, 1);
                wave.Add(mob1);
            }
            else if (waveNum == 2)
            {
                WaveMob mob1 = new WaveMob("Snail", 1.25f, 8);
                WaveMob mob2 = new WaveMob("Blue_Snail", 1f, 7);
                wave.Add(mob1);
                wave.Add(mob2);
            }
            else if (waveNum == 3)
            {
                WaveMob mob1 = new WaveMob("Snail", 0.5f, 6);
                WaveMob mob2 = new WaveMob("Blue_Snail", 0.9f, 11);
                wave.Add(mob1);
                wave.Add(mob2);
            }
            else if (waveNum == 3)
            {
                WaveMob mob1 = new WaveMob("Snail", 0.5f, 6);
                WaveMob mob2 = new WaveMob("Blue_Snail", 0.9f, 11);
                wave.Add(mob1);
                wave.Add(mob2);
            }
            else if (waveNum == 4)
            {
                WaveMob mob1 = new WaveMob("Snail", 0.35f, 5);
                WaveMob mob2 = new WaveMob("Blue_Snail", 1f, 11);
                WaveMob mob3 = new WaveMob("Shroom", 0.6f, 4);
                wave.Add(mob1);
                wave.Add(mob2);
                wave.Add(mob3);
            }
            else if (waveNum == 5)
            {
                WaveMob mob1 = new WaveMob("Snail", 0.35f, 5);
                WaveMob mob2 = new WaveMob("Blue_Snail", 0.5f, 9);
                WaveMob mob3 = new WaveMob("Shroom", 0.2f, 6);
                wave.Add(mob1);
                wave.Add(mob2);
                wave.Add(mob3);
            }
            else if (waveNum == 6)
            {
                WaveMob mob1 = new WaveMob("Mano", 0f, 1);
                wave.Add(mob1);
            }
            return wave;
        }
    }
}