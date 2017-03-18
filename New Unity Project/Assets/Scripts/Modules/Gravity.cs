using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    private GameObject planet;
    private Transform _transform;
    private RaycastHit hit;
    private Vector3 direction;

    public float gravity;
    private float acceleration = 2f;
    private bool down;
    private float downTime;
    private float downTimeMax = 10;
    private float downHeight;
    private float inhibition = 1f;

    // Use this for initialization
    void Start() {
        planet = GameObject.FindGameObjectWithTag("Planet");
        _transform = transform;
        downHeight = inhibition * Mathf.Pow(downTimeMax, 2) / 2;
    }

    // Update is called once per frame
    void Update() {
        if (down) Down();
        Gravitation();

    }
    private void Gravitation()
    {
        Vector3 position = _transform.position;
        direction = (transform.position - planet.transform.position).normalized;
        _transform.up = direction;

        if (Physics.Raycast(position, -direction, out hit, 1000f))
        {
            _transform.position = position;
            gravity += acceleration;
            if ((position - hit.point).magnitude > 1 + gravity * Time.deltaTime)
            {
                if (!down) _transform.position -= direction * gravity * Time.deltaTime;
            }
            gravity = 0;
        }
    }
    private void Down()
    {
        if (downTime < downTimeMax)
        {
            downTime++;
            downHeight -= inhibition;
            _transform.position += direction * downHeight * Time.deltaTime;
        }
        else
        {
            down = false;
            downTime = 0;
            downHeight = inhibition * Mathf.Pow(downTimeMax, 2) / 2;

        }
    }
}
