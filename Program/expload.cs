using System;
using System.Linq;
using Expload.Pravda;

public class Fighter
{
    public Fighter(string name)
    {
        Name = name;
        Stamina = 1;
        Strength = 1;
        Agility = 1;
        Wins = 1;
        Loses = 1;
    }

    public string Name { get; set; }

    public int Stamina { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }

    public int Wins { get; set; }
    public int Loses { get; set; }
}

public class Implant
{
    public int AssetId { get; set; }
    public int BodyPart { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public int Rotation { get; set; }

    public int StaminaEffect { get; }
    public int AgilityEffect { get; }
    public int StrengthEffect { get; }

    public Implant(int stamina, int agility, int strength, int assetId)
    {
        StaminaEffect = stamina;
        AgilityEffect = agility;
        StrengthEffect = strength;
        AssetId = assetId;
    }
}

[Program]
public class FightingProgram
{
    FightingProgram()
    {
        ImplantId = 1;
        FighterId = 1;
    }


    private int ImplantId;
    private int FighterId;

    private Mapping<int, Implant> ImplantIdToImplant = new Mapping<int, Implant>();
    private Mapping<int, int[]> FighterIdtoImplantIds = new Mapping<int, int[]>();
    private Mapping<int, Bytes> ImplantIdtoOwner = new Mapping<int, Bytes>();

    private Mapping<Bytes, int[]> OwnerToImplantIds = new Mapping<Bytes, int[]>();

    private Mapping<int, Fighter> FighterIdToFighter = new Mapping<int, Fighter>();
    private Mapping<int, Bytes> FighterIdToOwner = new Mapping<int, Bytes>();

    /* public int _randomQuantity = 5; */

    /* public void TestSystemMethods()
    {
        long balance = Info.Balance(Bytes.VOID_ADDRESS);
        Bytes programAddress = Info.ProgramAddress();

        Actions.Transfer(Bytes.VOID_ADDRESS, 100L);
        Actions.TransferFromProgram(Bytes.VOID_ADDRESS, 200L);

        Bytes nullBytes = null;
    } */
    public int CreateImplant()
    {
        Implant implant = new Implant(RandomGet(), RandomGet(), RandomGet(), RandomGet());
        ImplantIdToImplant.put(ImplantId, implant);
        ImplantIdtoOwner.put(ImplantId, Info.Sender());

        int[] ownerImplantIds = OwnerToImplantIds.getDefault(Info.Sender(), new int[0]);
        int size = ownerImplantIds.Length;

        int[] newImplantsIds = new int[size + 1];

        for (int i = 0; i < size; i++)
        {
            newImplantsIds[i] = ownerImplantIds[i];
        }


        newImplantsIds[size] = ImplantId;
        OwnerToImplantIds.put(Info.Sender(), newImplantsIds);

        return ImplantId++;
    }

    public string GetAccountImplants()
    {
        int[] implants = OwnerToImplantIds.getDefault(Info.Sender(), new int[0]);
        return convertIntArrayToString(implants);
    }

    public string GetFighterImplants(int fighterId)
    {
        int[] implants = FighterIdtoImplantIds.getDefault(fighterId, new int[0]);
        return convertIntArrayToString(implants);
    }

    public string GetImplantStats(int implantId)
    {
        Implant implant = ImplantIdToImplant.get(implantId);
        return Convert.ToString(implant.StrengthEffect) + ',' + Convert.ToString(implant.StaminaEffect) + ',' +
               Convert.ToString(implant.AgilityEffect);
    }

    public string AttachImplantToFighter(
        int implantId,
        int fighterId,
        int rotation,
        int bodyPart,
        int posX,
        int posY)
    {
        Bytes implantOwner = ImplantIdtoOwner.get(implantId);
        Bytes fighterOwner = FighterIdToOwner.get(fighterId);

        if (Info.Sender() == implantOwner && implantOwner == fighterOwner)
        {
            Implant implant = ImplantIdToImplant.get(implantId);

            implant.Rotation = rotation;
            implant.BodyPart = bodyPart;
            implant.PosX = posX;
            implant.PosY = posY;

            int[] fighterImplantIds = FighterIdtoImplantIds.getDefault(fighterId, new int[0]);
            int size = fighterImplantIds.Length;

            int[] newImplantsIds = new int[size + 1];
            string result = "";

            for (int i = 0; i < size; i++)
            {
                newImplantsIds[i] = fighterImplantIds[i];
                if (i != 0)
                {
                    result = result + ",";
                }

                result = result + Convert.ToString(fighterImplantIds[i]);
            }

            result = result + "," + Convert.ToString(implantId);


            newImplantsIds[size] = implantId;
            FighterIdtoImplantIds.put(fighterId, newImplantsIds);

            return result;
        }

        return "";
    }

    private int[] putInArray(int[] arr)
    {
        int size = arr.Length;
        int[] newArr = new int[size + 1];

        for (int i = 0; i < size; i++)
        {
            newArr[i] = arr[i];
        }

        return newArr;
    }

    private string convertIntArrayToString(int[] arr)
    {
        string result = "";

        for (int i = 0; i < arr.Length; i++)
        {
            if (i != 0)
            {
                result = result + ",";
            }

            result = result + Convert.ToString(arr[i]);
        }

        return result;
    }


    private int RandomGet()
    {
        int hash = Convert.ToInt32(Info.LastBlockHash());
/*
        randomPosition++;
        if (randomPosition > 9)
        {
            randomPosition = 0;
        }*/

        return hash % 9;
    }

    private int BattleGetWinner(int fighter0, int fighter1, int randomSeed)
    {
        //RandomSetSeed(randomSeed);

        /*int[] hps = {FighterGetInitialHp(fighter0), FighterGetInitialHp(fighter1)};

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
        }*/

        return randomSeed % 2 <= 0 ? fighter0 : fighter1;
    }


    public string ProceedBattle(int fighterId0, int fighterId1)
    {
        int randomSeed = RandomGet();

        int winner = BattleGetWinner(fighterId0, fighterId1, randomSeed);
        int loser = winner == fighterId0 ? fighterId1 : fighterId0;

        Fighter winnerFighter = FighterIdToFighter.get(winner);
        Fighter loserFighter = FighterIdToFighter.get(loser);

        winnerFighter.Wins++;
        loserFighter.Loses++;

        FighterIdToFighter.put(winner, winnerFighter);
        FighterIdToFighter.put(loser, loserFighter);

        string result = Convert.ToString(winner) + "," + Convert.ToString(loser) + "," + Convert.ToString(randomSeed);

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

    public int createNewFighter(string name)
    {
        Fighter fighter = new Fighter(name);
        FighterIdToFighter.put(FighterId, fighter);
        FighterIdToOwner.put(FighterId, Info.Sender());
        return FighterId++;
    }

    /* public string getLastBlockHash(){
        Bytes hash = Info.LastBlockHash();
        long height = Info.Height();
        return Convert.ToString(hash[0]) + '+' + Convert.ToString(height);
    } */
    public static void Main()
    {
    }
}