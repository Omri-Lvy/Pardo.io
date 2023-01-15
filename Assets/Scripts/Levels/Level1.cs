using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Levels
{
    public class Level1
    {
        private List<WaveMob> wave1;
        private List<WaveMob> wave2;
        private List<WaveMob> wave3;
        private List<WaveMob> wave4;
        private List<WaveMob> wave5;
        private List<WaveMob> boss;
        private bool isBoss;

        public Level1()
        {
            wave1 = buildWave1();
            wave2 = buildWave2();
            wave3 = buildWave3();
            wave4 = buildWave4();
            wave5 = buildWave5();
            boss = buildBoss();
            isBoss = false;
        }

        public List<WaveMob> getWave(int waveNum)
        {
            return waveNum switch
            {
                1 => getWave1(),
                2 => getWave2(),
                3 => getWave3(),
                4 => getWave4(),
                5 => getWave5(),
                _ => getBoss(),
            };
        }

        public bool getIsBoss()
        {
            return isBoss;
        }
        

        private List<WaveMob> buildWave1()
        {
            WaveMob mob1 = new WaveMob("Snail", 1.5f, 40);
            return new List<WaveMob>() { mob1 };
        }
        private List<WaveMob> buildWave2()
        {
            WaveMob mob1 = new WaveMob("Snail", 1.5f, 25);
            WaveMob mob2 = new WaveMob("Blue_Snail", 1.3f, 23);
            return new List<WaveMob>() { mob1, mob2 };
        }
        private List<WaveMob> buildWave3()
        {
            WaveMob mob1 = new WaveMob("Snail", 1.5f, 23);
            WaveMob mob2 = new WaveMob("Blue_Snail", 1.3f, 37);
            return new List<WaveMob>() { mob1, mob2 };
        }
        private List<WaveMob> buildWave4()
        {
            WaveMob mob1 = new WaveMob("Snail", 1.5f, 13);
            WaveMob mob2 = new WaveMob("Blue_Snail", 1.3f, 26);
            WaveMob mob3 = new WaveMob("Shroom", 1.2f, 17);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildWave5()
        {
            WaveMob mob1 = new WaveMob("Snail", 1.5f, 20);
            WaveMob mob2 = new WaveMob("Blue_Snail", 1.3f, 27);
            WaveMob mob3 = new WaveMob("Shroom", 1.2f, 17);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildBoss()
        {
            WaveMob boss = new WaveMob("Mano", 0f, 1);
            return new List<WaveMob>() { boss };
        }


        private List<WaveMob> getWave1()
        {
            return wave1;
        }
        private List<WaveMob> getWave2()
        {
            return wave2;
        }
        private List<WaveMob> getWave3()
        {
            return wave3;
        }
        private List<WaveMob> getWave4()
        {
            return wave4;
        }
        private List<WaveMob> getWave5()
        {
            return wave5;
        }
        private List<WaveMob> getBoss()
        {
            isBoss = true;
            return boss;
        }
    }
}