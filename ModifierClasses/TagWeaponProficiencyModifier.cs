using InstanceIDs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proficiencies;
using TinyHelper;

namespace CrusadersEquipment
{
    public class TagWeaponProficiencyModifier : IWeaponProficiencyFromItem
    {
        public float Apply(Item item)
        {
            float result = 0f;
            if (item.HasTag(TinyTagManager.GetOrMakeTag(IDs.WeaponProficiency1Tag)))
            {
                result += 1;
            }
            if (item.HasTag(TinyTagManager.GetOrMakeTag(IDs.WeaponProficiency2Tag)))
            {
                result += 2;
            }

            return result;
        }
    }
}
