using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform trans;
    public Player player;
    public float offsetY;

    private void Awake()
    {
        trans = this.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = trans.position;
        cameraPos.x = player.trans.position.x;
        cameraPos.y = player.trans.position.y + offsetY;
        trans.position = cameraPos;
    }
}
