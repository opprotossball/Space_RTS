using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : UnitBase
{
    [SerializeField] private AudioClip _spawnSound;
    // Start is called before the first frame update
    void Start()
    {
        AudioSystem.Instance.PlaySound(_spawnSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
