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

        public List<Coach> Get()
        {
            return _coachRepository.Get();
        }
        public Coach? GetCoachById(int id)
        {
            return _coachRepository.GetCoachById(id);
        }
        public Coach? GetCoachByFirstName(string firstName)
        {
            return _coachRepository.GetCoachByFirstName(firstName);
        }
        public Coach? GetCoachByLastName(string lastName)
        {
            return _coachRepository.GetCoachByLastName(lastName);
        }
        public Coach? AddCoach(Coach coach)
        {
            return _coachRepository.AddCoach(coach);
        }
        public Coach? UpdateCoach(Coach request)
        {
            return _coachRepository.UpdateCoach(request);
        }
        public Coach? PatchUpdateCoach(Coach requestPatch)
        {
            return _coachRepository.PatchUpdateCoach(requestPatch);
        }
        public void DeleteCoach(int id)
        {
            _coachRepository.DeleteCoach(id);
        }
    }
}
