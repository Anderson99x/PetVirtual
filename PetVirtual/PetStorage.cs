public class PetStorage
{
   
    private Pet _pet;

    public PetStorage(Pet pet)
    {
        _pet = pet;
    }

    public Pet GetPet()
    {
        return _pet;
    }

}