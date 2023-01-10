using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianSkills : MonoBehaviour
{
    private bool _skill2, _skill3;
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject firepillar;
    [SerializeField] private GameObject poisionCloud;
    private Transform _transform;


    // Start is called before the first frame update
    void Start()
    {
        _skill2 = false;
        _skill3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        _transform = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAimWeapon>().transform;
        if(Input.GetKeyDown("1")) {
            Fireball();
        }
        if(Input.GetKeyDown("2") && _skill2) {
            Firepillar();
        }
        if(Input.GetKeyDown("3") && _skill3) {
            PoisionCloud();
        }
    }

    private void Fireball() {
        Instantiate(fireball, _transform.position, _transform.rotation);
    }

    private void Firepillar() {

    }

    private void PoisionCloud() {

    }
    
}
