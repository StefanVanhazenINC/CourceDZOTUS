namespace ShootEmUp
{

    public interface ICharacterFacade
    {
        public bool SameTeam(bool isPlayer);
        public void TakeDamage(int value);
    }
}