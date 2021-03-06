﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElectionTactics
{
    /// <summary>
    /// Modifiers are temporary effects that apply to a party in a specific district.
    /// </summary>
    public class Modifier
    {
        public ModifierType Type;
        public District District;
        public Party Party;
        public int TotalLength;
        public int RemainingLength;
        public string Description;
        public string Source;

        public Modifier(ModifierType type, Party p, int length, string description, string source)
        {
            Type = type;
            Party = p;
            TotalLength = length;
            RemainingLength = length;
            Description = description;
            Source = source;
        }
    }
}
