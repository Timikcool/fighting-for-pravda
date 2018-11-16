using System;
using Expload.Pravda;

[Program]
public class ZooProgram
{

    public struct Fighter
        {            
            public int Stamina { get; set; }
            public int Strength { get; set; }
            public int Agility { get; set; }

            public int Wins {get; set;}

            public int Loses {get; set;}

        }


    public Mapping<String, int> PetToZoo = new Mapping<String, int>();
    public Mapping<String, Bytes> PetSignature = new Mapping<String, Bytes>();
    
    public Mapping<int, Fighter> FighterIdToFighter = new Mapping<int, Fighter>();
    public Mapping<int, Bytes> FighterIdToOwner = new Mapping<int, Bytes>();
    public int FighterId = 1;

    private Bytes GenerateSignature(String pet)
    {
        byte[] sign = new byte[10];
        for (int i = 0; i < 10; i++) {
            sign[i] = Convert.ToByte(pet[i % pet.Length] / 2);
        }
        return new Bytes(sign);
    }

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

    public int NewFighter()
    {
            Fighter fighter = new Fighter();
            
            FighterIdToFighter.put(FighterId, fighter);
            FighterIdToOwner.put(FighterId, Info.Sender());
            // PetSignature.put(fighter, GenerateSignature(fighter));
            FighterId += 1;
  
            return FighterId - 1;
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

    public static void Main() {}
}
