## Setting up the local Angular environment:

### Prerequisites:

Node.js

npm

TypeScript

### Commands:

ng new: Create new app

ng generate: Generate components

ng serve: Run server


### Install the Angular CLI:

```npm
npm install -g @angular/cli
```

### Create a workspace:

```npm
ng new <app-name>
```

### Run the application:

```npm
ng serve --open
```

## .NET Web API:

Diagram:

![](images/architecture.png)

## Generic Repository Interface:

```C#
{
    T GetById(int id);
    IEnumerable<T> List();
    IEnumerable<T> List(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Delete(T entity);
    void Edit(T entity);
}
 
public abstract class EntityBase
{
   public int Id { get; protected set; }
}
```

## Implementation Generic Repository:

```C#
public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual T GetById(int id)
    {
        return _dbContext.Set<T>().Find(id);
    }

    public virtual IEnumerable<T> List()
    {
        return _dbContext.Set<T>().AsEnumerable();
    }

    public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>()
               .Where(predicate)
               .AsEnumerable();
    }

    public void Insert(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChanges();
    }
}
```

# Resources:
MSDN

https://angularjs.org/
