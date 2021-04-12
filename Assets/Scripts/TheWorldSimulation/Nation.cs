﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Nation
{
    public string Name;
    public Sprite Flag;
    public Color PrimaryColor;
    public Color SecondaryColor;
    public Region Capital;

    public List<Region> Regions = new List<Region>();
    public List<List<Region>> Clusters = new List<List<Region>>();
    public float Area;

    public List<GameObject> Borders = new List<GameObject>();

    public void AddRegion(Region region)
    {
        if (region.Nation != null) region.Nation.RemoveRegion(region);
        Regions.Add(region);
        region.SetNation(this);
        region.SetColor(PrimaryColor);
        UpdateProperties();
    }

    public void RemoveRegion(Region region)
    {
        Regions.Remove(region);
        region.SetNation(null);
        UpdateProperties();
    }

    private void UpdateProperties()
    {
        foreach (GameObject border in Borders) GameObject.Destroy(border);

        Area = Regions.Sum(x => x.Area);
        Clusters = PolygonMapFunctions.FindClusters(Regions);
        foreach (List<Region> cluster in Clusters)
        {
            List<GameObject> clusterBorders = MeshGenerator.CreatePolygonGroupBorder(cluster.Select(x => x.Polygon).ToList(), PolygonMapGenerator.DefaultCoastBorderWidth, SecondaryColor, onOutside: false, height: 0.0002f);
            foreach (GameObject clusterBorder in clusterBorders) Borders.Add(clusterBorder);
        }
    }
}
