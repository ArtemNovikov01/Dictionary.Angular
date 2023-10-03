using Specifications.Contracts;

namespace Dictionary.Domain.Specifications
{
    public abstract class ExtendableSpecificationBase<TResult> : ISpecification<TResult> where TResult : class
    {
        private readonly List<Func<IQueryable<TResult>, IQueryable<TResult>>> _queries = new();

        public ExtendableSpecificationBase(Func<IQueryable<TResult>, IQueryable<TResult>> query)
        {
            _queries.Add(query ?? throw new ArgumentNullException(nameof(query)));
        }

        public IQueryable<TResult> ApplyTo(IQueryable<TResult> set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set));
            }

            return _queries.Aggregate(set, (source, query) => query(source));
        }
    }
}
