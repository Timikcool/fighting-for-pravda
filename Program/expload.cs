using System;
using Expload.Pravda;

[Program]
public class FightingProgram
{

    FightingProgram()
    {
        RandomSeed = 0;
        
    }

    private class Fighter
        {
            public Fighter(String name)
            {
                Name = name;
                Stamina = 1;
                Strength = 1;
                Agility = 1;
                Wins = 1;
                Loses = 1;
            }
            public int Stamina { get; set; }

            public String Name {get; set;}
            public int Strength { get; set; }
            public int Agility { get; set; }

            public int Wins {get; set;}

            public int Loses {get; set;}

        }
    
    private class Implant {

        public int AssetId {get; set;}
        public int BodyPart {get; set;}
        public int PosX{get;set;}
        public int PosY{get;set;}
        public int Rotation{get;set;}

        public String Creator{get;}
        Implant(String sender){
            this.Creator = sender;
        }
    }
    
    public int ImplantId = 1;

    private Mapping<int, Implant> ImplantIdToImplant = new Mapping<int, Implant>();

    private Mapping<int,int> ImplantIdtoFighterId = new Mapping<int, int>();
    
    private Mapping<int, Fighter> FighterIdToFighter = new Mapping<int, Fighter>();
    private Mapping<int, Bytes> FighterIdToOwner = new Mapping<int, Bytes>();

    public int FighterId = 1;

    private int _randomPosition;
    private int _randomQuantity = 500;
    private int[] _randomValues = new int[]
        {
            13962, 70992, 65172, 28053, 02190, 83634, 66012, 70305, 66761, 88344, 43905, 46941, 72300, 11641, 43548,
            30455, 07686, 31840, 03261, 89139, 00504, 48658, 38051, 59408, 16508, 82979, 92002, 63606, 41078, 86326,
            61274, 57238, 47267, 35303, 29066, 02140, 60867, 39847, 50968, 96719, 43753, 21159, 16239, 50595, 62509,
            61207, 86816, 29902, 23395, 72640, 83503,
            51662, 21636, 68192, 84294, 38754, 84755, 34053, 94582, 29215, 36807, 71420, 35804, 44862, 23577, 79551,
            42003, 58684, 09271, 68396, 19110, 55680, 18792, 41487, 16614, 83053, 00812, 16749, 45347, 88199, 82615,
            86984, 93290, 87971, 60022, 35415, 20852, 02909, 99476, 45568, 05621, 26584, 36493, 63013, 68181, 57702,
            49510, 75304, 38724, 15712, 06936,
            37293, 55875, 71213, 83025, 46063, 74665, 12178, 10741, 58362, 84981, 60458, 16194, 92403, 80951, 80068,
            47076, 23310, 74899, 87929, 66354, 88441, 96191, 04794, 14714, 64749, 43097, 83976, 83281, 72038, 49602,
            94109, 36460, 62353, 00721, 66980, 82554, 90270, 12312, 56299, 78430, 72391, 96973, 70437, 97803, 78683,
            04670, 70667, 58912, 21883, 33331,
            51803, 15934, 75807, 46561, 80188, 78984, 29317, 27971, 16440, 62843, 84445, 56652, 91797, 45284, 25842,
            96246, 73504, 21631, 81223, 19528, 15445, 77764, 33446, 41204, 70067, 33354, 70680, 66664, 75486, 16737,
            01887, 50934, 43306, 75190, 86997, 56561, 79018, 34273, 25196, 99389, 06685, 45945, 62000, 76228, 60645,
            87750, 46329, 46544, 95665, 36160,
            38196, 77705, 28891, 12106, 56281, 86222, 66116, 39626, 06080, 05505, 45420, 44016, 79662, 92069, 27628,
            50002, 32540, 19848, 27319, 85962, 19758, 92795, 00458, 71289, 05884, 37963, 23322, 73243, 98185, 28763,
            04900, 54460, 22083, 89279, 43492, 00066, 40857, 86568, 49336, 42222, 40446, 82240, 79159, 44168, 38213,
            46839, 26598, 29983, 67645, 43626,
            40039, 51492, 36488, 70280, 24218, 14596, 04744, 89336, 35630, 97761, 43444, 95895, 24102, 07006, 71923,
            04800, 32062, 41425, 66862, 49275, 44270, 52512, 03951, 21651, 53867, 73531, 70073, 45542, 22831, 15797,
            75134, 39856, 73527, 78417, 36208, 59510, 76913, 22499, 68467, 04497, 24853, 43879, 07613, 26400, 17180,
            18880, 66083, 02196, 10638, 95468,
            87411, 30647, 88711, 01765, 57688, 60665, 57636, 36070, 37285, 01420, 74218, 71047, 14401, 74537, 14820,
            45248, 78007, 65911, 38583, 74633, 40171, 97092, 79137, 30698, 97915, 36305, 42613, 87251, 75608, 46662,
            99688, 59576, 04887, 02310, 35508, 69481, 30300, 94047, 57096, 10853, 10393, 03013, 90372, 89639, 65800,
            88532, 71789, 59964, 50681, 68583,
            01032, 67938, 29733, 71176, 35699, 10551, 15091, 52947, 20134, 75818, 78982, 24258, 93051, 02081, 83890,
            66944, 99856, 87950, 13952, 16395, 16837, 00538, 57133, 89398, 78205, 72122, 99655, 25294, 20941, 53892,
            15105, 40963, 69267, 85534, 00533, 27130, 90420, 72584, 84576, 66009, 26869, 91829, 65078, 89616, 49016,
            14200, 97469, 88307, 92282, 45292,
            93427, 92326, 70206, 15847, 14302, 60043, 30530, 57149, 08642, 34033, 45008, 41621, 79437, 98745, 84455,
            66769, 94729, 17975, 50963, 13364, 09937, 00535, 88122, 47278, 90758, 23542, 35273, 67912, 97670, 03343,
            62593, 93332, 09921, 25306, 57483, 98115, 33460, 55304, 43572, 46145, 24476, 62507, 19530, 41257, 97919,
            02290, 40357, 38408, 50031, 37703,
            51658, 17420, 30593, 39637, 64220, 45486, 03698, 80220, 12139, 12622, 98083, 17689, 59677, 56603, 93316,
            79858, 52548, 67367, 72416, 56043, 00251, 70085, 28067, 78135, 53000, 18138, 40564, 77086, 49557, 43401,
            35924, 28308, 55140, 07515, 53854, 23023, 70268, 80435, 24269, 18053, 53460, 32125, 81357, 26935, 67234,
            78460, 47833, 20496, 35645
        };

    private int RandomSeed { get; set; }

        private void RandomSetSeed(int seed)
        {
            _randomPosition = seed;
        }

        private int RandomGet()
        {
            int result = _randomValues[_randomPosition];
            _randomPosition = (_randomPosition + 1) % _randomQuantity;
            return result;
        }
    
    private int BattleGetWinner(Fighter fighter0, Fighter fighter1, int randomSeed)
        {
            RandomSetSeed(randomSeed);
                        
            int[] hps = {FighterGetInitialHp(fighter0), FighterGetInitialHp(fighter1)};

            while (hps[0] > 0 && hps[1] > 0)
            {
                int turn = BattleGetTurn();
                int counter = (turn + 1) % 2;
                
                Fighter attacker = turn > 0 ? fighter0 : fighter1;
                Fighter defender = counter > 0 ? fighter0 : fighter1;
                
                bool dodged = FighterGetDodged(attacker);
                bool crited = FighterGetCrited(defender);
                int damage = FighterGetDamage(attacker) * (dodged ? 0 : 1) * (crited ? 2 : 1);

                hps[counter] = hps[counter] - damage;
            }

            return hps[0] <= 0 ? 1 : 0;
        }


    public string ProceedBattle(int FighterId0, int FighterId1)
    {     
        RandomSeed = ++RandomSeed % 500;

        int winner = BattleGetWinner(FighterIdToFighter.get(FighterId0), FighterIdToFighter.get(FighterId1),
            RandomSeed);

        string result = Convert.ToString(winner) + "," + Convert.ToString(RandomSeed);

        return result;
    }
    

        private int BattleGetTurn()
        {
            return RandomGet() < 5000 ? 0 : 1;
        }
        
        private bool FighterGetDodged(Fighter chara)
        {
            return RandomGet() < 400 + chara.Agility * 100;
        }
        
        private bool FighterGetCrited(Fighter chara)
        {
            return RandomGet() < 400 + chara.Agility * 100;
        }
        
        private int FighterGetDamage(Fighter chara)
        {
            return 4 + chara.Strength;
        }

        private int FighterGetInitialHp(Fighter chara)
        {
            return 40 + chara.Stamina * 10;
        }
    
    // private Bytes GenerateSignature(String pet)
    // {
    //    byte[] sign = new byte[10];
    //    for (int i = 0; i < 10; i++) {
    //        sign[i] = Convert.ToByte(pet[i % pet.Length] / 2);
    //    }
    //    return new Bytes(sign);
    // }

    // public int NewZoo()
    // {
    //     ZooToOwner.put(ZooCnt, Info.Sender());
    //     ZooCnt += 1;
    //     return ZooCnt - 1;
    // }

    // public void TransferZoo(Bytes to, int zoo)
    // {
    //     if (ZooToOwner.getDefault(zoo, Bytes.EMPTY) == Info.Sender()) {
    //         ZooToOwner.put(zoo, to);
    //     }
    // }

    public int createNewFighter(String name)
    {
            Fighter fighter = new Fighter(name);
            FighterIdToFighter.put(FighterId, fighter);
            FighterIdToOwner.put(FighterId, Info.Sender());
            return FighterId++;
    }


   
    // public void TransferPet(Bytes to, int zoo, String pet)
    // {
    //     if (PetToOwner.getDefault(pet, Bytes.EMPTY) == Info.Sender() && ZooToOwner.getDefault(zoo, Bytes.EMPTY) == to) {
    //        PetToOwner.put(pet, to);
    //        PetToZoo.put(pet, zoo);
    //     }
    // }

    // public String BreedPets(String pet1, String pet2)
    // {
    //     if (PetToOwner.getDefault(pet1, Bytes.EMPTY) == Info.Sender() &&
    //             PetToOwner.getDefault(pet2, Bytes.EMPTY) == Info.Sender() &&
    //             PetToZoo.getDefault(pet1, -1) == PetToZoo.getDefault(pet2, -1)) {

    //         String newPet = pet1 + pet2;
    //         PetToOwner.put(newPet, Info.Sender());
    //         PetSignature.put(newPet, PetSignature.get(pet1).Concat(PetSignature.get(pet2)));
    //         return newPet;
    //     } else {
    //         return "";
    //     }
    // }

   // public int createNewImplant(){}

  //  public int assignImplantToFighter(int ImplantId, int FighterId){
//
  //  }
    public static void Main() {}
}
