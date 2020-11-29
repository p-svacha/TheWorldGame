﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElectionTactics
{
    public class GeographyPolicy : Policy
    {
        public GeographyTraitType Trait;

        public GeographyPolicy(Party p, GeographyTraitType trait, int maxValue) : base(p, maxValue)
        {
            Trait = trait;
            Name = EnumHelper.GetDescription(trait);
            Type = PolicyType.Geography;
        }
    }
}
