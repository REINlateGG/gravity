using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class gravityscript : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;
    public static List<gravityscript> planetLists;

    [SerializeField] bool planet = false;
    [SerializeField] int orbitSpeed = 1000;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (planetLists == null)
        {
            planetLists = new List<gravityscript>();
        }
        planetLists.Add(this);

        if (!planet)
        {rb.AddForce(UnityEngine.Vector3.left * orbitSpeed);}
    }

    private void FixedUpdate()
    {
        foreach (var planet in planetLists)
        {
            if(planet != this)
            Attract(planet);
        }
    }

    void Attract(gravityscript other)
    {
        Rigidbody otherRb = other.rb;
        
        UnityEngine.Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * ((rb.mass * otherRb.mass)/Mathf.Pow(distance,2));
        UnityEngine.Vector3 finalForce = forceMagnitude * direction.normalized;

        otherRb.AddForce(finalForce);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
