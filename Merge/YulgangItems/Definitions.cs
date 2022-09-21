using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ybiLoader
{
    public enum ybClass : int
    {
        // Chars
        None = 0,
        Blader = 1,
        Swordsman = 2,
        Spearman = 3,
        Bowman = 4,
        Healer = 5,
        Ninja = 11,
        Busker = 12, // << iuno why that happened
        // Pets
        Mouse = 7,
        Hawk = 8,
        Leopard = 9,
        Tiger = 10
    }

    public enum ybGender : int
    {
        None = 0,
        Male = 1,
        Female = 2
    }

    public enum ybFaction : int
    {
        None = 0,
        Order = 1,
        Chaos = 2
    }

    public enum ybType : int
    {
        Misc,
        Robe = 1,
        Bracer = 2,
        Weapon = 3,
        Boots = 4,
        Armor = 5,
        Necklace = 6,
        Earring = 7,
        Ring = 8,
        Costume = 9,
        GuildItem = 21,
        Arrows = 30
    }
}
