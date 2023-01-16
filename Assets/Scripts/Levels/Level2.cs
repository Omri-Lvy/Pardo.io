using System.Collections.Generic;

namespace Scripts.Levels
{
    public class Level2
    {
        private List<WaveMob> wave1;
        private List<WaveMob> wave2;
        private List<WaveMob> wave3;
        private List<WaveMob> wave4;
        private List<WaveMob> wave5;
        private List<WaveMob> boss;
        private bool isBoss;

        public Level2()
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
            WaveMob mob1 = new WaveMob("Red_Snail", 1.5f, 30);
            WaveMob mob2 = new WaveMob("Shroom", 1f, 18);
             WaveMob mob3 = new WaveMob("Orange_Mashroom", 1f, 18);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildWave2()
        {
            WaveMob mob1 = new WaveMob("Red_Snail", 1.5f, 24);
            WaveMob mob2 = new WaveMob("Shroom", 1.3f, 32);
            WaveMob mob3 = new WaveMob("Orange_Mashroom", 1f, 24);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildWave3()
        {
            WaveMob mob1 = new WaveMob("Shroom", 1.5f, 24);
            WaveMob mob2 = new WaveMob("Orange_Mashroom", 1f, 24);
            WaveMob mob3 = new WaveMob("Blue_Mashroom", 1.3f, 24);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildWave4()
        {
            WaveMob mob1 = new WaveMob("Orange_Mashroom", 1f, 30);
            WaveMob mob2 = new WaveMob("Blue_Mashroom", 1.3f, 30);
            WaveMob mob3 = new WaveMob("Pig", 1.2f, 24);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildWave5()
        {
            WaveMob mob1 = new WaveMob("Blue_Mashroom", 1.5f, 30);
            WaveMob mob2 = new WaveMob("Pig", 1.3f, 30);
            WaveMob mob3 = new WaveMob("Renegade_Shroom", 1f, 24);
            return new List<WaveMob>() { mob1, mob2, mob3 };
        }
        private List<WaveMob> buildBoss()
        {
            WaveMob boss = new WaveMob("Mushmom", 0f, 1);
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