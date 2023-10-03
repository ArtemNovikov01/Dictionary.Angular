namespace Dictionary.Domain.Data.Entity.Base
{
    public abstract class DictionaryBase<TKey> : EntityBase<TKey>
        where TKey : struct
    {
        protected DictionaryBase() { }

        protected DictionaryBase(string name) 
        {
            Name = name;
        }

        public string Name { get; private set; }

        protected void Update(string name)
        {
            Name = name;
        }
    }
}
