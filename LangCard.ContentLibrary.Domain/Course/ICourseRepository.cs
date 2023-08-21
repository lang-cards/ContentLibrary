namespace LangCard.ContentLibrary.Domain.Course
{
    public interface ICourseRepository
    {
        public Task<Course[]> Get(CancellationToken cancellationToken);
        public Task<Course> GetById(int id, CancellationToken cancellationToken);
        public Task<int> Add(Course course, CancellationToken cancellationToken);
        public Task Update(Course course, CancellationToken cancellationToken);
        public Task Delete(int id, CancellationToken cancellationToken);

    }
}
