namespace RO.DevTest.Persistence.Repositories{
public interface IClienteRepository : IBaseRepository<Cliente> { 

     Task<Cliente?> GetByEmailAsync(string email); 
}

}


