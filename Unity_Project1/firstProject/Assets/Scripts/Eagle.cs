using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{

    [SerializeField]
    Transform player;
    SpriteRenderer spriteRenderer;
    Vector3 startPosition;
    [SerializeField]
    float eagleHight = 2;
    [SerializeField]
    float speed = 2;

    // deltaTime : ????? ?????? ???? ???? ????

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(EagleAnimation());
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > transform.position.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }

    IEnumerator EagleAnimation()
    {

        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y + eagleHight, startPosition.z);

        bool isFlight = true;
        float value = 0;
        
        while(true)
        {
            yield return null;
            if(isFlight)
                transform.position = Vector3.Lerp(startPosition,endPosition,value);
            else
                transform.position = Vector3.Lerp(endPosition, startPosition, value);

            value = value + Time.deltaTime * speed; 
            if(value > 1)
            {
                value = 0;
                isFlight = !isFlight;       
            }
        }
    }
}
