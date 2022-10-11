﻿
// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;

    public partial class ExperiencedFarmhandTalent : Talent
    {
        public override bool Base => true;
    }

    [Serialized]
    [LocDisplayName("Experienced Farmhand: Gathering")]
    public partial class GatheringExperiencedFarmhandTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Increases the yield of farmed plants by 20 percent.");

        public GatheringExperiencedFarmhandTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(GatheringExperiencedFarmhandTalent),
            };
            this.OwningSkill = typeof(FarmingSkill);
            this.Level = 7;
        }
    }

    [Serialized]
    public partial class GatheringExperiencedFarmhandTalent : ExperiencedFarmhandTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(GatheringExperiencedFarmhandTalentGroup); } }
        public GatheringExperiencedFarmhandTalent()
        {
            this.Value = 1.2f;
        }
    }
}
