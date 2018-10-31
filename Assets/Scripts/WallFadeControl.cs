using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFadeControl : MonoBehaviour {

    // Use this for initialization
    public float DrunkLevel = 0.0f;
    [SerializeField]
    private float ImmersionDrunkLevel = 3.0f;
    private List<Material> DullWorldWalls;
    private List<Material> FairyWorldWalls;
	void Start () {
        MeshRenderer[] mrs = GetComponentsInChildren<MeshRenderer>();
        DullWorldWalls = new List<Material>();
        FairyWorldWalls = new List<Material>();
        //Debug.Log(mrs.Length);
        foreach (MeshRenderer mr in mrs)
        {
            Debug.Log(mr.materials[0]);
            Debug.Log(mr.materials[1].name);

            DullWorldWalls.Add(mr.materials[0]);
            FairyWorldWalls.Add(mr.materials[1]);
        }
        //set all fairy world walls transparent
        Debug.Log(FairyWorldWalls);

        foreach (Material Wall in FairyWorldWalls)
        {
            Wall.color = new Color(Wall.color.r, Wall.color.g, Wall.color.b, 0.0f);
        }
        Debug.Log(FairyWorldWalls);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateAlphaLevel(DrunkLevel);
	}

    void UpdateAlphaLevel(float DrunkLevel)
    {
        if (DrunkLevel < 0.0f)
            DrunkLevel = 0.0f;
        if (DrunkLevel > 3.0f)
            DrunkLevel = 3.0f;
        foreach (Material Wall in FairyWorldWalls)
        {
            Wall.color = new Color(Wall.color.r, Wall.color.g, Wall.color.b, DrunkLevel / ImmersionDrunkLevel);
        }
        foreach (Material Wall in DullWorldWalls)
        {
            Wall.color = new Color(Wall.color.r, Wall.color.g, Wall.color.b, 1.0f - DrunkLevel / ImmersionDrunkLevel);
        }
    }
}
