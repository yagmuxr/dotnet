global using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Dtos;
using dotnet.Models;

namespace dotnet.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static readonly List<Character> characters = new()
        {
            new Character(),
            new Character { Id = 1, Name = "Sam" }
        };
        private readonly IMapper mapper;
    
        public CharacterService(IMapper mapper)
        {
        this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) +1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
          var serviceResponse = new ServiceResponse<GetCharacterDto>();
          var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

          character.Name = updatedCharacter.Name;
          character.Strength = updatedCharacter.Strength;
          character.Defense = updatedCharacter.Defense;
          character.Intelligence = updatedCharacter.Intelligence;
          character.HitPoints = updatedCharacter.HitPoints;

          serviceResponse.Data = mapper.Map<GetCharacterDto>(character);
          return serviceResponse;
        }
    }

}
