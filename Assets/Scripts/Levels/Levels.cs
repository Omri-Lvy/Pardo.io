using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Levels
{
    public class Levels
    {

        private readonly Level1 _level1;
        private readonly Level2 _level2;
        private readonly Level3 _level3;
        public Levels()
        {
            _level1 = new Level1();
            _level2 = new Level2();
            _level3 = new Level3();
        }

        public List<WaveMob> getWave(int lvl, int wave)
        {
            return lvl switch
            {
                1 => _level1.getWave(wave),
                2 => _level2.getWave(wave),
                3 => _level3.getWave(wave),
                _ => null
            };
        }

        public bool getIsBoss(int lvl)
        {
            return lvl switch
            {
                1 => _level1.getIsBoss(),
                // 2 => _level2.getWave(wave),
                // 3 => _level3.getWave(wave),
                _ => false
            };
        }
    }
}