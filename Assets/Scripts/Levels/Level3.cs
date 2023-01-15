using System.Collections.Generic;

namespace Scripts.Levels
{
    public class Level3
    {
        private List<WaveMob> wave1;
        private List<WaveMob> wave2;
        private List<WaveMob> wave3;
        private List<WaveMob> wave4;
        private List<WaveMob> wave5;
        private List<WaveMob> boss;
        private bool isBoss;

        public Level3()
        {
            wave1 = buildWave1();
            wave2 = buildWave2();
            wave3 = buildWave3();
            wave4 = buildWave4();
            wave5 = buildWave5();
            wave5 = buildWave6();
            wave5 = buildWave7();
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
                6 => getWave6(),
                7 => getWave7(),
                _ => getBoss(),
            };
        }

        public bool getIsBoss()
        {
            return isBoss;
        }

        private List<WaveMob> buildWave1()
        {
            WaveMob mob1 = new WaveMob("Pig", 1.5f, 30);
            WaveMob mob2 = new WaveMob("Ribbon_Pig", 1f, 15);
            WaveMob mob3 = new WaveMob("Renegade_Shroom", 1.25f, 30);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildWave2()
        {
            WaveMob mob1 = new WaveMob("Ribbon_Pig", 1.5f, 30);
            WaveMob mob2 = new WaveMob("Slime", 1.6f, 24);
            WaveMob mob3 = new WaveMob("Green_Mashroom", 1f, 24);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildWave3()
        {
            WaveMob mob1 = new WaveMob("Ribbon_Pig", 1.5f, 18);
            WaveMob mob2 = new WaveMob("Slime", 1f, 33);
            WaveMob mob3 = new WaveMob("Green_Mashroom", 1.3f, 33);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildWave4()
        {
            WaveMob mob1 = new WaveMob("Slime", 1f, 30);
            WaveMob mob2 = new WaveMob("Green_Mashroom", 1.3f, 36);
            WaveMob mob3 = new WaveMob("Fairy", 1.7f, 12);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildWave5()
        {
            WaveMob mob1 = new WaveMob("Slime", 1.5f, 24);
            WaveMob mob2 = new WaveMob("Fairy", 1.3f, 21);
            WaveMob mob3 = new WaveMob("Renegade_Shroom", 1f, 36);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildWave6()
        {
            WaveMob mob1 = new WaveMob("Fairy", 1.8f, 32);
            WaveMob mob2 = new WaveMob("Renegade_Shroom", 1f, 32);
            return new List<WaveMob>() { mob1, mob2 };
        }
        private List<WaveMob> buildWave7()
        {
            WaveMob mob1 = new WaveMob("Slime", 1.5f, 30);
            WaveMob mob2 = new WaveMob("Fairy", 1.3f, 18);
            WaveMob mob3 = new WaveMob("Renegade_Shroom", 1f, 24);
            WaveMob mob4 = new WaveMob("Green_Mashroom", 1.7f, 24);
            return new List<WaveMob>() { mob1, mob2, mob3, mob4 };
        }
        private List<WaveMob> buildBoss()
        {
            WaveMob boss = new WaveMob("King_Slime", 0f, 1);
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
        private List<WaveMob> getWave6()
        {
            return wave5;
        }
        private List<WaveMob> getWave7()
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