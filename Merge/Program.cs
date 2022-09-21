using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ybiLoader;

namespace YBMerge
{
    class Program
    {

        const string chineseYBIName = "ChineseYBi.cfg.dec";
        const string englishYBIName = "EnglishYBi.cfg.dec";

        static void Main(string[] args)
        {

            byteData chYBI = new byteData();
            chYBI.ybiData = System.IO.File.ReadAllBytes(chineseYBIName);

            byteData engYBI = new byteData();
            engYBI.ybiData = System.IO.File.ReadAllBytes(englishYBIName);

            // status checks for later
            int ItemsTranslated = 0;
            int NPCTranslated = 0;

            // go through every english item in the ybi
            foreach (ybItem Item in engYBI.ybItemList)
            {
                var Query = chYBI.ybItemList.Where(I => I.ItemID == Item.ItemID);
                if (Query.Count() > 0)
                {
                    var chItem = Query.First();
                    chItem.ItemName = Item.ItemName;
                    chItem.ItemDesc = Item.ItemDesc;
                    ItemsTranslated++;

                    // //Probably not needed, because we're translating
                    //chItem.ItemBuyValue = Item.ItemBuyValue;
                    //chItem.ItemSellValue = Item.ItemSellValue;
                    //chItem.ItemLevel = Item.ItemLevel;
                    //chItem.ItemJob = Item.ItemJob;
                    //chItem.ItemGender = Item.ItemGender;
                    //chItem.ItemFaction = Item.ItemFaction;
                    //chItem.ItemType = Item.ItemType;
                    //chItem.ItemAttackMin = Item.ItemAttackMin;
                    //chItem.ItemAttackMax = Item.ItemAttackMax;
                    //chItem.ItemDefense = Item.ItemDefense;
                }
            }
         
            foreach (ybNPC NPC in engYBI.ybNPCList)
            {
                var Query = chYBI.ybNPCList.Where(N => N.npcID == NPC.npcID);
                if (Query.Count() > 0)
                {
                    var chNPC = Query.First();
                    chNPC.npcName = NPC.npcName;
                    chNPC.npcDesc = NPC.npcDesc;
                    NPCTranslated++;

                    // //Probably not needed because we're translating
                    //chNPC.npcLevel = NPC.npcLevel;
                }
            }

            Console.WriteLine("{0} items have been translated successfully!", ItemsTranslated);
            Console.WriteLine("{0} npcs have been translated successfully!", NPCTranslated);
    
            System.IO.File.WriteAllBytes("Chinese.English.MixYBI.dec",chYBI.ybiData);

            // derp
            System.Diagnostics.Process.GetCurrentProcess().WaitForExit();

        }

    }
}
