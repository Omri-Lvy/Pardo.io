using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Levels;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject Snail;
    [SerializeField] private GameObject Blue_Snail;
    [SerializeField] private GameObject Shroom;
    [SerializeField] private GameObject Mano;
    [SerializeField] private GameObject Red_Snail;
    [SerializeField] private GameObject Orange_Mashroom;
    [SerializeField] private GameObject Blue_Mashroom;
    [SerializeField] private GameObject Pig;
    [SerializeField] private GameObject Renegade_Shroom;
    [SerializeField] private GameObject Mushmom;
    [SerializeField] private GameObject Ribbon_Pig;
    [SerializeField] private GameObject Slime;
    [SerializeField] private GameObject Green_Mashroom;
    [SerializeField] private GameObject Fairy;
    [SerializeField] private GameObject King_Slime;
    private int _lvl;
    private int _wave;
    private float _timer;
    private Dictionary<String, GameObject> MOBS;
    private List<WaveMob> _lvlWave;
    private Levels _levels;


    // Start is called before the first frame update
    void Start()
    {
        _lvl = 1;
        _wave = 1;
        _levels = new Levels();
        _timer = 0;
        MOBS = new Dictionary<string, GameObject>()
        {
            {"Snail",Snail},
            {"Blue_Snail",Blue_Snail},
            {"Shroom",Shroom},
            {"Mano",Mano},
            {"Red_Snail",Red_Snail},
            {"Orange_Mashroom",Orange_Mashroom},
            {"Blue_Mashroom",Blue_Mashroom},
            {"Pig",Pig},
            {"Renegade_Shroom",Renegade_Shroom},
            {"Mushmom",Mushmom},
            {"Ribbon_Pig",Ribbon_Pig},
            {"Slime",Slime},
            {"Green_Mashroom",Green_Mashroom},
            {"Fairy",Fairy},
            {"King_Slime",King_Slime}
        };
        _lvlWave = _levels.getWave(_lvl,_wave);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        _timer += 1 * Time.deltaTime;
        if ((_timer > 5 || (!enemy && _wave > 1)) && !_levels.getIsBoss(_lvl))
        {
            Debug.Log(1);
            _wave += 1;
            _lvlWave = _levels.getWave(_lvl,_wave);
            _timer = 0;
        }
        else if (_levels.getIsBoss(_lvl) && !enemy)
        {
            _lvl++;
            _wave = 1;
            Debug.Log("You are now in level: "+_lvl);
        }

        handleSpwan();
    }

    private void handleSpwan()
    {
        if (_levels.getIsBoss(_lvl))
        {
            GameObject[] mobs = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject mob in mobs)
            {
                Destroy(mob);
            }
        }

        if (_lvlWave != null)
        {
            foreach (WaveMob mob in _lvlWave) {
                if (mob.getInterval() < _timer - mob.getLastInstantiate() &&  mob.getInstantiateCounter() < mob.getMax())
                {
                    Instantiate(MOBS[mob.getMonster()],new Vector3(getRandomX(), getRandomY(), 0), Quaternion.identity);
                    mob.increaseInstantiateCounter();
                    mob.setLastInstantiate(_timer);
                }
            }
        }
    }

    private float getRandomX()
    {
        float xPos = Random.Range(-5.5f, 5.5f);
        if (xPos < 0) xPos -= 4.6f;
        else if (xPos >= 0) xPos += 4.6f;
        return xPos;
    }

    private float getRandomY()
    {
        float yPos = Random.Range(-6f, 6f);
        if (yPos < 0) yPos -= 4.6f;
        else if (yPos >= 0) yPos += 4.6f;
        return yPos;
    }
}
