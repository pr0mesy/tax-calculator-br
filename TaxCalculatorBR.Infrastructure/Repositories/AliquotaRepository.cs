using TaxCalculatorBR.Domain.Interfaces;
using TaxCalculatorBR.Infrastructure.Data;

namespace TaxCalculatorBR.Infrastructure.Repositories;

public class AliquotaRepository : IAliquotaRepository
{
    
    private readonly TaxDbContext _context;

    public AliquotaRepository(TaxDbContext context)
    {
        _context = context;
    }
    
private decimal BuscarAliquota(string originState, string destinationState)
{
    return (_context.Aliquotas.FirstOrDefault(
        a => a.OriginState == originState
        && a.DestinationState == destinationState
        && a.TaxType == "ICMS")
        ?? throw new InvalidOperationException(
            $"Alíquota ICMS não encontrada: {originState} → {destinationState}"))
        .AliquotaValue;
}

public decimal GetIcmsAliquota(string state) 
    => BuscarAliquota(state, state);

public decimal GetIcmsInterestaduais(string originState, string destinationState) 
    => BuscarAliquota(originState, destinationState);
}