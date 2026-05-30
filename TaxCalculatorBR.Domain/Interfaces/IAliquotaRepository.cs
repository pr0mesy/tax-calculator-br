namespace TaxCalculatorBR.Domain.Interfaces;

public interface IAliquotaRepository
{
    decimal GetIcmsAliquota(string state);
    decimal GetIcmsInterestaduais(string originState, string destinationState);
}