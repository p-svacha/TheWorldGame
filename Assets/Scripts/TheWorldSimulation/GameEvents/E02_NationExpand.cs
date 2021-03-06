﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class E02_NationExpand : GameEvent
{
    private Nation CapturingNation;
    private Region NewProvince;
    private List<Region> Candidates = new List<Region>();

    public override int GetProbability(WorldSimulation Model)
    {
        Candidates = Model.Map.Regions.Where(x => !x.IsWater && x.Nation == null && x.AdjacentRegions.Any(y => y.Nation != null)).ToList();
        return Candidates.Count;
    }

    public override void InitExecution(WorldSimulation Model)
    {
        base.InitExecution(Model);

        NewProvince = Candidates[Random.Range(0, Candidates.Count)];
        List<Nation> nationCandidates = new List<Nation>();
        foreach(Region r in NewProvince.AdjacentRegions)
        {
            if (r.Nation != null && !nationCandidates.Contains(r.Nation)) nationCandidates.Add(r.Nation);
        }
        CapturingNation = nationCandidates[Random.Range(0, nationCandidates.Count)];

        CameraHandler.MoveToFocusRegion(NewProvince);
    }

    protected override void Execute(WorldSimulation Model, GameEventHandler Handler)
    {
        Model.CaptureRegion(CapturingNation, NewProvince);
        Model.AddLog("The nation " + CapturingNation.Name + " has expanded. It has called its new province " + NewProvince.Name);
    }

    
}