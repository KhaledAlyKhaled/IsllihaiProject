using IsllihaiProjectDAL.Contexts;
using IsllihaiProjectDAL.Reposatories.Classes;
using IsllihaiProjectDAL.Reposatories.Interface;

public class UnitOfWork : IUnitOfWork
{
    private readonly Dictionary<Type, object> _repositores = new();
    private readonly IslahiniDbContext dbContext;

    public UnitOfWork(
    IslahiniDbContext dbContext,
    ITecnicianRepo tecnicianRepo,
    IBookingRepo bookingRepo,
    ICategoreyRepo categoreyRepo,
    IReviewRepo reviewRepo)   
    {
        this.dbContext = dbContext;
        this.tecnicianRepo = tecnicianRepo;
        this.bookingRepo = bookingRepo;
        this.categoreyRepo = categoreyRepo;
        this.reviewRepo = reviewRepo;   
    }

    public ITecnicianRepo tecnicianRepo { get; }
    public IBookingRepo bookingRepo { get; }
    public ICategoreyRepo categoreyRepo { get; }
    public IReviewRepo reviewRepo {  get; }

    public IGenericRepo<T> GetRepo<T>() where T : class, new()
    {
        var entity = typeof(T);
        if (_repositores.TryGetValue(entity, out var Repo))
            return (IGenericRepo<T>)Repo;

        var NewRepo = new GenericRepo<T>(dbContext);
        _repositores[entity] = NewRepo;
        return NewRepo;
    }

    public int SaveChanges()
    {
        return dbContext.SaveChanges();
    }
}