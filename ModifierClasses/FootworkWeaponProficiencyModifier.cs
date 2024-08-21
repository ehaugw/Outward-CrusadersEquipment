using InstanceIDs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proficiencies;

namespace CrusadersEquipment
{
    public class FootworkWeaponProficiencyModifier : IWeaponProficiencyFromItem
    {
        public float Apply(Item item)
        {
            float result = 0f;
            if (item is Equipment equipment && equipment.ActiveEnchantmentIDs.Contains(IDs.footworkEnchantID))
            {
                result = 1;
            }
            return result;
        }
    }
}
