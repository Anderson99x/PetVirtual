using System;

public class PetService
{
    private Pet _pet;

    public PetService(Pet pet)
    {
        _pet = pet;
    }

    public void Alimentar()
    {
        _pet.Alimentar();
        
    }    

    public void Brincar()
    {
        _pet.Brincar();
    }

    public void Dormir()
    {
        _pet.Dormir();
    }

    public void Curar()
    {
        _pet.Curar();
    }

    public void MostrarStatus()
    {
        _pet.MostrarStatus();
    }
}