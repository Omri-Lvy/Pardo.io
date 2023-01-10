using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianSkills : MonoBehaviour
{
    private bool _skill2, _skill3;
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject firepillar;
    [SerializeField] private GameObject poisonCloud;
    private Transform _transform;


    // Start is called before the first frame update
    void Start()
    {
        _transform = transform.Find("Aim");
        _skill2 = false;
        _skill3 = false;
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetKeyDown("1")) {
            Fireball();
        }
        if(Input.GetKeyDown("2") && _skill2) {
            Firepillar();
        }
        if(Input.GetKeyDown("3") && _skill3) {
            PoisonCloud();
        }
    }

    private void Fireball() {
        Instantiate(fireball, _transform.position, _transform.rotation);
    }

    private void Firepillar() {

    }

    private void PoisonCloud() {

    }
    
}
