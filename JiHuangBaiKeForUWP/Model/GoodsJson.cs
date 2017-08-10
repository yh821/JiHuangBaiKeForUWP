﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiHuangBaiKeForUWP.Model
{
    public class GoodMaterial
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public List<string> Science { get; set; }
        public List<string> SourceCreature { get; set; }
        public string Introduction { get; set; }
        public string Console { get; set; }

        public GoodMaterial()
        {
            Science = new List<string>();
            SourceCreature = new List<string>();
        }
    }

    public class Material
    {
        public List<GoodMaterial> Good { get; set; }

        public Material()
        {
            Good = new List<GoodMaterial>();
        }
    }

    public class GoodEquipment
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public double Attack { get; set; }
        public double MinAttack { get; set; }
        public double MaxAttack { get; set; }
        public double AttackOnBoat { get; set; }
        public double AttackWet { get; set; }
        public string Durability { get; set; }
        public string Introduction { get; set; }
        public string Console { get; set; }
        public double Wet { get; set; }
        public double Heat { get; set; }
        public double Sanity { get; set; }
        public double Hunger { get; set; }
        public string DropBy { get; set; }
        public List<string> Ability { get; set; }
        public double Defense { get; set; }

        public GoodEquipment()
        {
            Ability = new List<string>();
        }
    }

    public class Equipment
    {
        public List<Equipment> Good { get; set; }

        public Equipment()
        {
            Good = new List<Equipment>();
        }
    }

    public class GoodSapling
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public List<string> Plants { get; set; }
        public string Introduction { get; set; }
        public string Console { get; set; }

        public GoodSapling()
        {
            Plants = new List<string>();
        }
    }

    public class Sapling
    {
        public List<GoodSapling> Good { get; set; }

        public Sapling()
        {
            Good = new List<GoodSapling>();
        }
    }

    public class GoodCreatures
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public int Fresh { get; set; }
        public List<string> Goods { get; set; }
        public string Console { get; set; }

        public GoodCreatures()
        {
            Goods = new List<string>();
        }
    }

    public class Creatures
    {
        public List<GoodCreatures> Good { get; set; }

        public Creatures()
        {
            Good = new List<GoodCreatures>();
        }
    }

    public class GoodTrinkets
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Console { get; set; }
    }

    public class Trinkets
    {
        public List<Trinkets> Good { get; set; }

        public Trinkets()
        {
            Good = new List<Trinkets>();
        }
    }

    public class GoodTurf
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Make { get; set; }
        public string Texture { get; set; }
        public string Introduction { get; set; }
        public string Console { get; set; }
    }

    public class Turf
    {
        public List<GoodTurf> Good { get; set; }

        public Turf()
        {
            Good = new List<GoodTurf>();
        }
    }

    public class GoodPet
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Dead { get; set; }
        public List<string> Follow { get; set; }
        public string Introduction { get; set; }
        public string Console { get; set; }

        public GoodPet()
        {
            Follow = new List<string>();
        }
    }

    public class Pet
    {
        public List<GoodPet> Good { get; set; }

        public Pet()
        {
            Good = new List<GoodPet>();
        }
    }

    public class GoodUnlock
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public List<string> DropBy { get; set; }
        public string UnlockCharacter { get; set; }
        public string Introduction { get; set; }
        public string Console { get; set; }

        public GoodUnlock()
        {
            DropBy = new List<string>();
        }
    }

    public class Unlock
    {
        public List<GoodUnlock> Good { get; set; }

        public Unlock()
        {
            Good = new List<GoodUnlock>();
        }
    }

    public class Good
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Introduction { get; set; }
        public string Console { get; set; }
    }

    public class HallowedNights
    {
        public List<Good> Good { get; set; }

        public HallowedNights()
        {
            Good = new List<Good>();
        }
    }

    public class WintersFeast
    {
        public List<Good> Good { get; set; }

        public WintersFeast()
        {
            Good = new List<Good>();
        }
    }

    public class YearOfTheGobbler
    {
        public List<Good> Good { get; set; }

        public YearOfTheGobbler()
        {
            Good = new List<Good>();
        }
    }

    public class Component
    {
        public List<Good> Good { get; set; }

        public Component()
        {
            Good = new List<Good>();
        }
    }

    public class GoodOthers
    {
        public List<Good> Good { get; set; }

        public GoodOthers()
        {
            Good = new List<Good>();
        }
    }

    public class GoodsRootObject
    {
        public Material Material { get; set; }
        public Equipment Equipment { get; set; }
        public Sapling Sapling { get; set; }
        public Creatures Creatures { get; set; }
        public Trinkets Trinkets { get; set; }
        public Turf Turf { get; set; }
        public Pet Pet { get; set; }
        public Unlock Unlock { get; set; }
        public HallowedNights HallowedNights { get; set; }
        public WintersFeast WintersFeast { get; set; }
        public YearOfTheGobbler YearOfTheGobbler { get; set; }

        public GoodsRootObject()
        {
            Material = new Material();
            Equipment = new Equipment();
            Sapling = new Sapling();
            Creatures = new Creatures();
            Trinkets = new Trinkets();
            Turf = new Turf();
            Pet = new Pet();
            Unlock = new Unlock();
            HallowedNights = new HallowedNights();
            WintersFeast = new WintersFeast();
            YearOfTheGobbler = new YearOfTheGobbler();
        }
    }
}