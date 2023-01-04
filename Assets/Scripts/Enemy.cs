using System;
using Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _attack = 40;
    [SerializeField] private float _def = 10;
    [SerializeField] private float _health = 100;
    [SerializeField] private int _xpGiven = 10;
    [SerializeField] public Animator _animator;
    private PlayerStats _playerStats;
    private EnemyStats _stats;
    private float timer;
    private float timerLimit = 0.25f;


    // Start is called before the first frame update
    void Start()
    {
        _stats = new EnemyStats(_attack, _speed, _def, _health, _xpGiven);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_stats.getIsHit());
        if (_stats.isDead())
        {
            _player.GetComponent<Player>().getStats().addXp(_xpGiven);
            Debug.Log("XP: " + _player.GetComponent<Player>().getStats().getXp());
            _animator.Play("Snail_die");
            Destroy(gameObject,1f);
        }
        else if (_stats.getIsHit() && !_stats.isDead())
        {
            if (timer < timerLimit)
            {
                timer += 1 * Time.deltaTime;
                _stats.setSpeed(0);
            }
            else
            {
                _stats.setIsHit(false);
                timer = 0;
            }
        }
        else if (!_stats.getIsHit() && !_stats.isDead())
        {
            _stats.setSpeed(_speed);
            _animator.Play("Snail_move");
        }
        if (_player.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (_player.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position, _stats.getSpeed() * Time.deltaTime);
    }

    public EnemyStats getStats()
    {
        return _stats;
    }

    public void getHit(float damage)
    {
        if (!_stats.isDead())
        {
            _stats.getHit(damage);
            timer = 0;
            _stats.setSpeed(0);
            _animator.Play("Snail_hit");
        }
    }

}
