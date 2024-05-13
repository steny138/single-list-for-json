namespace single_list_json_demo;

public class SingleList<T> : List<T>, IEnumerable<T>
{
    public void Validate()
    {
        if (!this.Any())
        {
            throw new ArgumentOutOfRangeException(nameof(SingleList<T>), "cannot be empty");
        }

        if (this.Count > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(SingleList<T>), "should be single");
        }
    }

    public T Item => this.Single();
}