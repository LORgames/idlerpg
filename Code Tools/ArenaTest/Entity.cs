using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArenaTest {
    public class Entity {
        // SOME CONSTATS
        

        //GENERAL STATS
        public string Name;
        public int Level;

        public int UsedStats;
        public int UnusedStats;

        //GOVERNED STATS
        public int RawStr = 1;
        public int RawVit = 1;
        public int RawAgi = 1;
        public int RawDex = 1;
        public int RawLuk = 1;

        //UNGOVERNED STATS
        public int Defence = 1;

        //PASSIVE STATS
        public int MaxHP = 0;
        public int AttackPower = 0;
        public int HitChance = 0;

        public float CriticalHitChance = 0;
        public float DodgeChance = 0;
        public float AttackSpeed = 0;
        public float AttackDelay = 0.5f;

        //SIMULATION STATS
        public int sim_CurrentHP;
        public float sim_NextTurn;

        internal void CalculateLevel() {
            UsedStats = RawStr+RawVit+RawAgi+RawDex+RawLuk;
            Level = UsedStats;
            UnusedStats = Level - UsedStats;

            MaxHP = (int)(Level * Math.Pow(1.0001, RawVit));
            AttackPower = RawStr;//STR (str + str bonus) + Mastery (e.g. sword mastery +40 Attack) + Weapon's Damage + Weapons Refine Bonus
            
            HitChance = Level + RawDex;
            CriticalHitChance = RawLuk * 0.3f + 1;
            DodgeChance = Level + RawAgi;

            AttackSpeed = RawAgi * 0.1f;
        }

        //////////////////////////////////////////////////////////////
        //SIMULATION FUNCTIONS
        //////////////////////////////////////////////////////////////
        internal void ResetForSimulation() {
            sim_CurrentHP = MaxHP;
            sim_NextTurn = 0;
        }

        internal bool isDead() {
            return sim_CurrentHP <= 0;
        }

        internal string HitOther(Entity other) {
            string retVal = "";

            float _HitChance = 80 + HitChance - other.DodgeChance;
            int AttackDamage = AttackPower - AttackPower / (100 / other.Defence) - other.RawVit;

            if (r.NextDouble() * 100 < _HitChance) {
                if (AttackDamage < 1) AttackDamage = 1;

                if (r.NextDouble() * 100 < CriticalHitChance) {
                    retVal += "CRITICAL! ";
                    AttackDamage = AttackPower - other.RawVit/2;
                }

                other.sim_CurrentHP -= AttackDamage;

                retVal += this.Name + " hit " + other.Name + " for " + (int)AttackDamage + " damage. " + other.sim_CurrentHP + "hp remains.\n";
            } else {
                retVal += this.Name + " missed.\n";
            }

            return retVal;
        }


        internal void FastForward(float nextTimeout) {
            sim_NextTurn -= nextTimeout;
        }

        internal string Process(Entity other) {
            string retVal = "";

            if (sim_NextTurn <= 0) {
                retVal += this.HitOther(other);
                sim_NextTurn = AttackDelay;
            }

            return retVal;
        }


        //A static object list
        private static Random r = new Random();
    }
}
