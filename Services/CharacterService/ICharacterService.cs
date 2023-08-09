using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.Dtos;

using dotnet.Models; // Make sure the namespace is correct

namespace dotnet.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
    }
}
