﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Drawing;
using System.Windows.Forms;
using ToolCache.Storage;

namespace ToolCache.Critters {
    public enum CritterTypes { Humanoid, NonHumanoid }

    public class Critter {
        public CritterTypes CritterType;

        public short ID = -1;
        public string Name = "MONSTAR!";
        public int AIType = 0;

        public int ExperienceGain = 0;
        
        public int Health = 0;
        public int Defense = 0;

        public bool OneOfAKind = false;

        public short MovementSpeed = 125;
        public short AlertRange = 100;
        public short AttackRange = 40;

        public string NodeGroup = "";
        public string AICommands = "";

        public List<LootDrop> Loot = new List<LootDrop>();

        public List<String> Groups = new List<string>();
        public List<String> Types = new List<string>();

        public TreeNode EditorNode = null;

        internal virtual void PackIntoBinaryIO(IStorage f) {
            f.AddByte((byte)CritterType);

            f.AddShort(ID);
            f.AddString(Name);

            f.AddInt(AIType);

            f.AddInt(ExperienceGain);
            
            f.AddInt(Health);
            f.AddInt(Defense);

            f.AddByte(OneOfAKind ? (byte)1 : (byte)0);

            f.AddShort(MovementSpeed);
            f.AddShort(AlertRange);
            f.AddShort(AttackRange);

            f.AddShort((short)Loot.Count);
            foreach (LootDrop l in Loot) l.Pack(f);

            f.AddShort((short)Groups.Count);
            foreach (String s in Groups) f.AddString(s);

            f.AddShort((short)Types.Count);
            foreach (String s in Types) f.AddString(s);

            f.AddString(NodeGroup);
            f.AddString(AICommands);
        }

        public virtual void Draw(LBuffer buffer) { } //Does nothing by design

        ///////////////////////Statics
        internal void BaseLoad(IStorage f) {
            ID = f.GetShort();
            Name = f.GetString();

            AIType = f.GetInt();

            ExperienceGain = f.GetInt();

            Health = f.GetInt();
            Defense = f.GetInt();

            OneOfAKind = f.GetByte()==1;
            
            MovementSpeed = f.GetShort();
            AlertRange = f.GetShort();
            AttackRange = f.GetShort();

            short Total = f.GetShort();
            while (--Total > -1) {
                Loot.Add(LootDrop.Unpack(f));
            }

            Total = f.GetShort();
            while (--Total > -1) {
                Groups.Add(f.GetString());
            }

            Total = f.GetShort();
            while (--Total > -1) {
                Types.Add(f.GetString());
            }

            NodeGroup = f.GetString();
            AICommands = f.GetString();
        }


        public virtual Critter Clone() { throw new NotImplementedException(); }

        public virtual void CloneX(Critter temp) {
            string newName = this.Name + " - Copy";
            int count = 0;
            while (CritterManager.HasCritter(newName)) {
                if (newName.Substring(newName.LastIndexOf(' '), 4).Contains("(")) {
                    newName = newName.Substring(0, newName.LastIndexOf(' '));
                }
                newName = newName + " (" + count++ + ")";
            }
            temp.Name = newName;
            temp.AIType = this.AIType;

            temp.ExperienceGain = this.ExperienceGain;
            temp.Health = this.Health;
            temp.Defense = this.Defense;
            temp.OneOfAKind = this.OneOfAKind;
            temp.MovementSpeed = this.MovementSpeed;
            temp.AlertRange = this.AlertRange;

            temp.NodeGroup = this.NodeGroup;
            temp.AICommands = this.AICommands;

            temp.Loot.AddRange(this.Loot);

            temp.Groups.AddRange(this.Groups);
            temp.Types.AddRange(this.Types);

            //Create this critters node
            TreeNode node = new TreeNode(temp.Name);
            node.ImageIndex = (int)temp.CritterType;
            node.Tag = temp;

            temp.EditorNode = node;
        }
    }
}
