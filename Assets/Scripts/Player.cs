using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed = 2.25f;
    [SerializeField] private float _attack = 10;
    [SerializeField] private float _def = 10;
    public Animator animator;
    public PlayerStats stats;

    public Quaternion q;
    // Start is called before the first frame update
    void Start()
    {
        //Reset position to (0,0,0)
        stats = new PlayerStats(_attack, _walkingSpeed, _def);
        transform.position = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        // check if need to level up:
        stats.needLevelup();
    }

    // Levels up the character, updates stats
    // Returns: the new character level.

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            horizontalInput = -horizontalInput;
        }
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * (_walkingSpeed * Time.deltaTime));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.5f, 4.5f), 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.4f, 8.4f), transform.position.y, 0);
    }

    public PlayerStats getStats()
    {
        return stats;
    }

    public void setStats(PlayerStats Pstats)
    {
        this.stats.setCurrenthealth(Pstats.getCurrentHealth());
        this.stats.setAttack(Pstats.getAttack());
        this.stats.setDef(Pstats.getDef());
        this.stats.setLevel(Pstats.getLevel());
        this.stats.setSpeed(Pstats.getSpeed());
        this.stats.setXP(Pstats.getXp());
        this.stats.setMaxXp(Pstats.getMaxXp());
        this.stats.setMaxHealth(Pstats.getMaxHealth());
        bool [] skills = Pstats.getSkills();
        this.stats.setSkill(0, skills[0]);
        this.stats.setSkill(1, skills[1]);
        this.stats.setSkill(2, skills[2]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (!other.gameObject.GetComponent<Enemy>().getStats().isDead())
            {
                stats.getHit(other.gameObject.GetComponent<Enemy>().getStats().getAttack());
            }
            if (stats.isDead())
            {
                Destroy(gameObject);
            }
        }
    }
}