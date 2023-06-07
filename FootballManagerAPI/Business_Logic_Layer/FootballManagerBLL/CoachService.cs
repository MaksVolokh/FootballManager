using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Entities;
using FootballManagerDAL.Interfaces;


namespace FootballManagerBLL.FootballManagerBLL
{
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _coachRepository;

        public CoachService(ICoachRepository coachRepository)
        {
            _coachRepository = coachRepository;
        }

        public async Task<List<Coach>> GetAsync()
        {
            return await _coachRepository.GetAsync();
        }
        public async Task<Coach>? GetByIdAsync(int id)
        {
            return await _coachRepository.GetByIdAsync(id);
        }
        public async Task<Coach>? GetByFirstNameAsync(string firstName)
        {
            return await _coachRepository.GetByFirstNameAsync(firstName);
        }
        public async Task<Coach>? GetByLastNameAsync(string lastName)
        {
            return await _coachRepository.GetByLastNameAsync(lastName);
        }
        public async Task<Coach>? AddAsync(Coach coach)
        {
            return await _coachRepository.AddAsync(coach);
        }
        public async Task<Coach>? UpdateAsync(Coach request)
        {
            Coach? coach = await _coachRepository.GetByIdAsync(request.Id);

            if (coach == null)
            {
                return null;
            }

            return await _coachRepository.UpdateAsync(request);
        }
        public async Task<Coach>? PatchUpdateAsync(Coach requestPatch)
        {
            Coach? coach = await _coachRepository.GetByIdAsync(requestPatch.Id);

            if (coach == null)
            {
                return null;
            }

            return await _coachRepository.PatchUpdateAsync(requestPatch);
        }
        public async Task<Coach>? DeleteAsync(int id)
        {
            Coach? coach = await _coachRepository.GetByIdAsync(id);

            if (coach == null)
            {
                return null;
            }
            await _coachRepository.DeleteAsync(coach);

            return coach;
        }
    }
}
