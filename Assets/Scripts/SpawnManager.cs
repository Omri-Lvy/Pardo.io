using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Scripts;
using Scripts.Levels;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Canvas CanvasPrefab;
    [SerializeField] private GameObject Pardo;
    [SerializeField] private GameObject PardoMage;
    [SerializeField] private GameObject PardoArcher;
    [SerializeField] private GameObject PardoAssassin;
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
    private GameObject CanvasInstance;
    private int _lvl;
    private int _wave;
    private float _timer;
    private Dictionary<String, GameObject> MOBS;
    private List<WaveMob> _lvlWave;
    private Levels _levels;
    private CanvasGroup _canvasgroup;


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
        if ((_timer > 2 || (!enemy && _wave > 1)) && !_levels.getIsBoss(_lvl))
        {
            _wave += 1;
            _lvlWave = _levels.getWave(_lvl,_wave);
            _timer = 0;
        }
        else if (_levels.getIsBoss(_lvl) && !enemy)
        {
            _lvl++;
            _wave = 1;
            if (_lvl == 2 && _wave == 1)
            {
                Time.timeScale = 0;
                _canvasgroup = CanvasPrefab.GetComponent<CanvasGroup>();
                _canvasgroup.alpha = 1f;
                _canvasgroup.interactable = true;
            }
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

    public void selectCharacter(int i)
    {

        GameObject[] bulletsArr = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bulletsArr)
        {
            Destroy(bullet);
        }
        
        GameObject pardo = GameObject.FindGameObjectWithTag("Player");

        Vector3 currentPosition = pardo.transform.position;
        Quaternion currentRotation = pardo.transform.rotation;
        PlayerStats currentStats = new PlayerStats(pardo.GetComponent<Player>().getStats().getCurrentHealth(),
            pardo.GetComponent<Player>().getStats().getMaxHealth(),
            pardo.GetComponent<Player>().getStats().isDead(),
            pardo.GetComponent<Player>().getStats().getAttack(),
            pardo.GetComponent<Player>().getStats().getDef(),
            pardo.GetComponent<Player>().getStats().getSpeed(),
            pardo.GetComponent<Player>().getStats().getXp(),
            pardo.GetComponent<Player>().getStats().getMaxXp(),
            pardo.GetComponent<Player>().getStats().getLevel()
            );

        Destroy(pardo);

        GameObject chosenPardo = pardo;

        if (i == 1) {
            chosenPardo = PardoMage;
        } else if (i == 2) {
            chosenPardo = PardoArcher;
        } else if (i == 3) {
            chosenPardo = PardoAssassin;
        }

        GameObject selectedPardo = Instantiate(chosenPardo, currentPosition, currentRotation);
        selectedPardo.transform.position = currentPosition;
        selectedPardo.transform.rotation = currentRotation;
        selectedPardo.GetComponent<Player>().setStats(currentStats);

    }

    public void resume() {
        
        _canvasgroup = CanvasPrefab.GetComponent<CanvasGroup>();
        _canvasgroup.alpha = 0;
        _canvasgroup.interactable = false;
      
        Time.timeScale = 1f;
        //GameObject.FindGameObjectWithTag("Player").GameObject.setActive(false);
    }

}
