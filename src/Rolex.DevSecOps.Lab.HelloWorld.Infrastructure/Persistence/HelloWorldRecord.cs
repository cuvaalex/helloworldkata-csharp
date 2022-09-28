namespace Rolex.DevSecOps.Lab.HelloWorld.Infrastructure.Persistence;

public class HelloWorldRecord
{
    public long Id { get; set; }
    public string? Name { get; set; }

    public class Builder
    {
        private readonly HelloWorldRecord _record = new HelloWorldRecord();

        public Builder Id(long id)
        {
            _record.Id = id;
            return this;
        }

        public Builder Name(string name)
        {
            _record.Name = name;
            return this;
        }

        public HelloWorldRecord Build() => _record;
    }
}