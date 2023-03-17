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
        public Coach? GetById(int id)
        {
            return _coachRepository.GetById(id);
        }
        public Coach? GetByFirstName(string firstName)
        {
            return _coachRepository.GetByFirstName(firstName);
        }
        public Coach? GetByLastName(string lastName)
        {
            return _coachRepository.GetByLastName(lastName);
        }
        public Coach? Add(Coach coach)
        {
            return _coachRepository.Add(coach);
        }
        public Coach? Update(Coach request)
        {
            Coach? coach = _coachRepository.GetById(request.Id);

            if (coach == null)
            {
                return null;
            }

            return _coachRepository.Update(request);
        }
        public Coach? PatchUpdate(Coach requestPatch)
        {
            Coach? coach = _coachRepository.GetById(requestPatch.Id);

            if (coach == null)
            {
                return null;
            }

            return _coachRepository.PatchUpdate(requestPatch);
        }
        public Coach? Delete(int id)
        {
            Coach? coach = _coachRepository.GetById(id);

            if (coach == null)
            {
                return null;
            }
            _coachRepository.Delete(coach);

            return coach;
        }
    }
}
